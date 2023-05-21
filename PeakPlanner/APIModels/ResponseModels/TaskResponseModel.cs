namespace PeakPlannerAPI
{
    /// <summary>
    /// The task response model
    /// </summary>
    public class TaskResponseModel : StandardResponseModel
    {
        #region Public Properties

        /// <summary>
        /// The status
        /// </summary>
        public TaskStatus Status { get; set; }

        /// <summary>
        /// The <see cref="BaseResponseModel.Id"/> of the related <see cref="ProjectResponseModel"/>
        /// </summary>
        public int ProjectId { get; set; }

        /// <summary>
        /// The labels
        /// </summary>
        public IEnumerable<EmbeddedLabelResponseModel>? Labels { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public TaskResponseModel() : base()
        {

        }

        #endregion
    }
}
