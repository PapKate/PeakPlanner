namespace PeakPlannerAPI
{
    /// <summary>
    /// The label response model
    /// </summary>
    public class LabelResponseModel : BaseResponseModel
    {
        #region Private Members

        /// <summary>
        /// The member of the <see cref="Color"/> property
        /// </summary>
        private string? mColor;

        #endregion

        #region Private Members

        /// <summary>
        /// The color
        /// </summary>
        public string Color
        {
            get => mColor ?? string.Empty;
            set => mColor = value;
        }

        /// <summary>
        /// The id of the parent
        /// The <see cref="BaseEntity.Id"/> of the related <see cref="LabelEntity"/>
        /// </summary>
        public int? ParentId { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public LabelResponseModel()
        {

        }

        #endregion
    }

    /// <summary>
    /// The label response model
    /// </summary>
    public class EmbeddedLabelResponseModel : IIdentifiable
    {
        #region Private Members

        /// <summary>
        /// The member of the <see cref="Color"/> property
        /// </summary>
        private string? mColor;

        /// <summary>
        /// The member of the <see cref="Title"/> property
        /// </summary>
        private string? mTitle;

        #endregion

        #region Public Properties

        /// <summary>
        /// The id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The title
        /// </summary>
        public string Title
        {
            get => mTitle ?? string.Empty;
            set => mTitle = value;
        }

        /// <summary>
        /// The color
        /// </summary>
        public string Color
        {
            get => mColor ?? string.Empty;
            set => mColor = value;
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public EmbeddedLabelResponseModel()
        {

        }

        #endregion
    }
}
