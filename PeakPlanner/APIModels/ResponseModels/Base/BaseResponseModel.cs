namespace PeakPlannerAPI
{
    public abstract class BaseResponseModel : IIdentifiable, IDateable
    {
        #region Public Properties

        /// <summary>
        /// The id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The date it was created
        /// </summary>
        public DateTimeOffset DateCreated { get; set; } = DateTimeOffset.Now;

        /// <summary>
        /// The date it was last modified
        /// </summary>
        public DateTimeOffset DateModified { get; set; } = DateTimeOffset.Now;

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public BaseResponseModel() : base()
        {

        }

        #endregion
    }
}
