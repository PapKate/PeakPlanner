using FoPeakPlannerAPIoli;


namespace PeakPlannerAPI
{
    /// <summary>
    /// The label entity
    /// </summary>
    public class LabelEntity : BaseEntity
    {
        #region Private Members

        /// <summary>
        /// The member of the <see cref="Color"/> property
        /// </summary>
        private string? mColor;

        #endregion

        #region Public Properties

        /// <summary>
        /// The color
        /// </summary>
        public string Color 
        {
            get => mColor ?? string.Empty;
            set => mColor = value;
        }

        #region Relationships

        /// <summary>
        /// The id of the parent
        /// The <see cref="BaseEntity.Id"/> of the related <see cref="LabelEntity"/>
        /// </summary>
        public int? ParentId { get; set; }

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public LabelEntity()
        {
            
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Creates and returns a <see cref="LabelEntity"/> from the specified <paramref name="model"/>
        /// </summary>
        /// <param name="model">The model</param>
        /// <returns></returns>
        public static LabelEntity FromRequestModel(LabelRequestModel model)
            => ControllerHelpers.FromRequestModel<LabelEntity, LabelRequestModel>(model);

        /// <summary>
        /// Creates and returns a <see cref="LabelResponseModel"/> from the current <see cref="LabelEntity"/>
        /// </summary>
        /// <returns></returns>
        public LabelResponseModel ToResponseModel()
            => ControllerHelpers.ToResponseModel<LabelEntity, LabelResponseModel>(this);

        #endregion
    }
}
