using Microsoft.EntityFrameworkCore;

using PeakPlannerAPI.DataModels.Entities;

namespace PeakPlannerAPI
{
    /// <summary>
    /// Represents the database structure
    /// </summary>
    public class PeekPlannerDBContext : DbContext
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

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="options">The options</param>
        public PeekPlannerDBContext(DbContextOptions<PeekPlannerDBContext> options) : base(options)
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
           

        }

        #endregion
    }
}
