
namespace PeakPlannerAPI
{
    /// <summary>
    /// The standard request model
    /// </summary>
    public abstract class StandardRequestModel : BaseRequestModel
    {
        #region Public Properties

        /// <summary>
        /// The title
        /// </summary>
        public string? Title { get; set; }

        /// <summary>
        /// The description
        /// </summary>
        public string? Description { get; set; }

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
        public StandardRequestModel() : base()
        {

        }

        #endregion
    }
}
