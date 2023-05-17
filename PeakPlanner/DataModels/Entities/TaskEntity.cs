namespace PeakPlannerAPI
{
    /// <summary>
    /// The task entity
    /// </summary>
    public class TaskEntity : StandardEntity
    {
        #region Public Properties

        /// <summary>
        /// The status
        /// </summary>
        public TaskStatus Status { get; set; }

        #region Relationships

        /// <summary>
        /// The <see cref="BaseEntity.Id"/> of the related <see cref="ProjectEntity"/>
        /// </summary>
        public int ProjectId { get; set; }

        /// <summary>
        /// The related <see cref="ProjectEntity"/>
        /// </summary>
        public ProjectEntity? Project { get; set; }

        #endregion
        
        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public TaskEntity() : base()
        {

        }

        #endregion
    }
}
