namespace PeakPlannerAPI
{
    /// <summary>
    /// The project entity
    /// </summary>
    public class ProjectEntity : StandardEntity
    {
        #region Private Members

        /// <summary>
        /// The member of the <see cref="Name"/> property
        /// </summary>
        private string? mName;

        #endregion

        #region Public Properties

        /// <summary>
        /// The title
        /// </summary>
        public string Name
        {
            get => mName ?? string.Empty;
            set => mName = value;
        }

        #region Relationships

        /// <summary>
        /// The list of the related <see cref="TaskEntity"/>
        /// </summary>
        public IEnumerable<TaskEntity>? Tasks { get; set; }

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public ProjectEntity() : base()
        {

        }

        #endregion
    }
}
