using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;


namespace PeakPlannerAPI
{
    /// <summary>
    /// Represents the database structure
    /// </summary>
    public class PeakPlannerDBContext : DbContext
    {
        #region Public Properties

        /// <summary>
        /// The projects
        /// </summary>
        public DbSet<ProjectEntity> Projects { get; set; }

        /// <summary>
        /// The tasks
        /// </summary>
        public DbSet<TaskEntity> Tasks { get; set; }

        /// <summary>
        /// The project labels
        /// </summary>
        public DbSet<LabelEntity> Labels { get; set; }

        /// <summary>
        /// The project labels
        /// </summary>
        public DbSet<ProjectLabelEntity> ProjectLabels { get; set; }

        /// <summary>
        /// The task labels
        /// </summary>
        public DbSet<TaskLabelEntity> TaskLabels { get; set; }

        /// <summary>
        /// The task and label pairs
        /// </summary>
        public DbSet<TaskAndLabelEntity> TaskAndLabels { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="options">The options</param>
        public PeakPlannerDBContext(DbContextOptions<PeakPlannerDBContext> options) : base(options)
        {
        }

        #endregion

        #region Protected Methods

        /// <summary>
        /// Override this method to further configure the model that was discovered by convention
        /// from the entity types exposed in <see cref="DbSet{TEntity}"/> properties
        /// on your derived context. The resulting model may be cached and re-used for subsequent
        /// instances of your derived context.
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Projects
            
            modelBuilder.Entity<ProjectEntity>()
                    .HasMany(x => x.Tasks)
                    .WithOne()
                    .HasPrincipalKey(x => x.Id)
                    .HasForeignKey(x => x.ProjectId)
                    .OnDelete(DeleteBehavior.Cascade); 

            #endregion

            #region Labels

            modelBuilder.Entity<LabelEntity>()
                .UseTpcMappingStrategy()
                .HasMany<LabelEntity>()
                .WithOne()
                .HasPrincipalKey(x => x.Id)
                .HasForeignKey(x => x.ParentId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<LabelEntity>()
                .HasMany<TaskAndLabelEntity>()
                .WithOne(x => x.Label)
                .HasPrincipalKey(x => x.Id)
                .HasForeignKey(x => x.LabelId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ProjectLabelEntity>()
                .UseTpcMappingStrategy();

            modelBuilder.Entity<TaskLabelEntity>()
                .UseTpcMappingStrategy();

            #endregion

            #region Tasks

            modelBuilder.Entity<TaskEntity>()
                .HasMany(x => x.Labels)
                .WithOne()
                .HasPrincipalKey(x => x.Id)
                .HasForeignKey(x => x.TaskId)
                .OnDelete(DeleteBehavior.Cascade);

            #endregion
        }

        #endregion
    }
}
