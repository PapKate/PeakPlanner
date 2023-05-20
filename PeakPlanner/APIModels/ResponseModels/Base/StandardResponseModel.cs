namespace PeakPlannerAPI
{
    public abstract class StandardResponseModel : BaseResponseModel
    {
        #region Public Properties

        /// <summary>
        /// The progress percentage
        /// </summary>
        /// <remarks>Default : 0</remarks>
        /// <value>Min: 0 - Max: 100</value>
        public uint ProgressPercentage { get; set; } 

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
