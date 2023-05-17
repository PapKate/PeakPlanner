namespace PeakPlannerAPI
{
    /// <summary>
    /// The task request model
    /// </summary>
    public class TaskRequestModel : StandardRequestModel
    {
        #region Public Properties

        /// <summary>
        /// The status
        /// </summary>
        public TaskStatus Status { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public TaskRequestModel() : base()
        {

        }

        #endregion
    }
}
