namespace PeakPlannerAPI
{
    /// <summary>
    /// The base request model
    /// </summary>
    public abstract class BaseRequestModel
    {
        #region Private Members

        /// <summary>
        /// The member of the <see cref="Title"/> property
        /// </summary>
        private string? mTitle;

        #endregion

        #region Public Properties

        /// <summary>
        /// The title
        /// </summary>
        public string Title
        {
            get => mTitle ?? string.Empty;
            set => mTitle = value;
        }

        /// <summary>
        /// The description
        /// </summary>
        public string Description { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public BaseRequestModel() : base()
        {

        }

        #endregion
    }
}
