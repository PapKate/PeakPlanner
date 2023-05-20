namespace PeakPlannerAPI
{
    /// <summary>
    /// The label request model
    /// </summary>
    public class LabelRequestModel : BaseRequestModel
    {
        #region Public Properties

        /// <summary>
        /// The color
        /// </summary>
        public string? Color { get; set; }

        /// <summary>
        /// The id of the parent
        /// </summary>
        public int? ParentId { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public LabelRequestModel()
        {

        }

        #endregion
    }
}
