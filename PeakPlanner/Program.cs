using AutoMapper;
using AutoMapper.Internal;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

using Newtonsoft.Json.Serialization;

using System.Reflection;

namespace PeakPlannerAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            #region Configure Services

            builder.Services.AddDbContext<PeekPlannerDBContext>(options
                => options.UseMySql("Server=localhost;Database=PeekPlanner;Uid=root;Pwd=12345678;", ServerVersion.Parse("8.0.33 (MySQL Community Server - GPL)")));

            #region AutoMapper

            var configuration = new MapperConfiguration((cfg) =>
            {
                // The request model types
                var requestModelTypes = new List<Type>();

                // The entity types
                var entityTypes = new List<Type>();

                // The response model types
                var responseModelTypes = new List<Type>();

                var assemblies = new List<Assembly?>()
                {
                    // The request model
                    Assembly.GetAssembly(typeof(ProjectRequestModel)),
                    // The entities
                    Assembly.GetAssembly(typeof(ProjectEntity)),
                    // The response models
                    Assembly.GetAssembly(typeof(ProjectResponseModel))
                };

                // For each assembly...
                foreach (var assembly in assemblies)
                {
                    // If the assembly exists...
                    if(assembly is not null)
                        // For each type...
                        foreach (var type in assembly.GetTypes())
                        {
                            // If the type ends with "RequestModel"...
                            if (type.Name.EndsWith(FrameworkConstructionExtensions.RequestModelSuffix))
                                // Add it to the request model types
                                requestModelTypes.Add(type);
                            // Else if the type ends with "Entity"...
                            else if (type.Name.EndsWith(FrameworkConstructionExtensions.EntitySuffix))
                                // Add it to the entity types
                                entityTypes.Add(type);
                            // Else if the type ends with "ResponseModel"...
                            else if (type.Name.EndsWith(FrameworkConstructionExtensions.ResponseModelSuffix))
                                // Add it to the response model types
                                responseModelTypes.Add(type);
                        }

                    // For each request model type...
                    foreach (var requestModelType in requestModelTypes)
                    {
                        // Get the prefix of the model
                        var requestModelNamePrefix = requestModelType.Name.Replace(FrameworkConstructionExtensions.RequestModelSuffix, string.Empty);
                        // Get the entity type if exists with the same prefix
                        var entityType = entityTypes.FirstOrDefault(x => x.Name.Replace(FrameworkConstructionExtensions.EntitySuffix, string.Empty) == requestModelNamePrefix);

                        // If the entity type exists...
                        if (entityType != null)
                            // Create map for request model -> entity
                            cfg.CreateMap(requestModelType, entityType);
                    }

                    // For each entity type
                    foreach (var entityType in entityTypes)
                    {
                        // Get the prefix of the entity
                        var entityNamePrefix = entityType.Name.Replace(FrameworkConstructionExtensions.EntitySuffix, string.Empty);
                        // Get the response model type if exists with the same prefix
                        var responseModelType = responseModelTypes.FirstOrDefault(x => x.Name.Replace(FrameworkConstructionExtensions.ResponseModelSuffix, string.Empty) == entityNamePrefix);

                        // If the response model exists...
                        if (responseModelType != null)
                            // Create map for entity -> response model
                            cfg.CreateMap(entityType, responseModelType);

                        // Set the name of the embedded response model that matches the entity's name 
                        var embeddedResponseModelName = FrameworkConstructionExtensions.EmbeddedPrefix + entityNamePrefix + FrameworkConstructionExtensions.ResponseModelSuffix;
                        // Searches for the embedded model if exists 
                        var embeddedResponseModelType = responseModelTypes.FirstOrDefault(x => x.Name == embeddedResponseModelName);

                        // If the model does not exists...
                        if (embeddedResponseModelType == null)
                            // Continue
                            continue;
                        // Creates a map for entity -> embedded response model
                        cfg.CreateMap(entityType, embeddedResponseModelType);
                    }
                }

                // Do not map values when the values of the properties of the request models are null
                cfg.Internal().ForAllMaps((map, options) =>
                {
                    if (map.SourceType.Name.EndsWith(FrameworkConstructionExtensions.RequestModelSuffix)
                    && map.DestinationType.Name.EndsWith(FrameworkConstructionExtensions.EntitySuffix))
                        options.ForAllMembers(x =>
                        {
                            x.Condition((_, _, sourceValue) => sourceValue is not null);
                            x.UseDestinationValue();
                        });
                });

                cfg.Internal().ForAllPropertyMaps(
                        (map) => map.SourceType is not null
                              && map.DestinationType is not null
                              && map.SourceType.Name.EndsWith(FrameworkConstructionExtensions.RequestModelSuffix)
                              && map.DestinationType.Name.EndsWith(FrameworkConstructionExtensions.EntitySuffix)
                              && map.SourceType is not null
                              && map.SourceType == typeof(IEnumerable<int>),
                        (map, opts) => opts.Ignore());
            });

            // Create the mapper
            var mapper = new Mapper(configuration);

            // Add the mapper to the services
            builder.Services.AddSingleton(mapper);

            #endregion

            builder.Services.AddControllers().AddNewtonsoftJson(s =>
            {
                s.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            });

            #endregion

            // Add services to the container.
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            #region DbContext

            using var scope = app.Services.CreateScope();
            var serviceProvider = scope.ServiceProvider;
            var dbContext = serviceProvider.GetRequiredService<PeekPlannerDBContext>();
            
            var result = dbContext.Database.EnsureCreated();
            
            #endregion

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            
            app.UseRouting();
            
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}