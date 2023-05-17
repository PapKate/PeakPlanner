namespace PeakPlannerAPI
{
    /// <summary>
    /// The project response model
    /// </summary>
    public class ProjectResponseModel : StandardResponseModel
    {
        #region Private Members

        /// <summary>
        /// The member of the <see cref="Name"/> property
        /// </summary>
        private string? mName;

        #endregion

        #region Public Properties

        /// <summary>
        /// The name
        /// </summary>
        public string Name
        {
            get => mName ?? string.Empty;
            set => mName = value;
        }

        /// <summary>
        /// The tasks
        /// </summary>
        public IEnumerable<TaskResponseModel>? Tasks { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public ProjectResponseModel() : base()
        {

        }

        #endregion
    }
}
