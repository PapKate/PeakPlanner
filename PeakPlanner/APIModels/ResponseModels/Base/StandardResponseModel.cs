namespace PeakPlannerAPI
{
    public abstract class StandardResponseModel : BaseResponseModel
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
        /// The progress percentage
        /// </summary>
        /// <remarks>Default : 0</remarks>
        /// <value>Min: 0 - Max: 100</value>
        public uint ProgressPercentage { get; set; } = 0;

        /// <summary>
        /// The start date
        /// </summary>
        public DateTimeOffset DateStart { get; set; }

        /// <summary>
        /// The finish date
        /// </summary>
        public DateTimeOffset? DateEnd { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public StandardResponseModel() : base()
        {

        }

        #endregion
    }
}
