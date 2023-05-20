namespace PeakPlannerAPI
{
    /// <summary>
    /// The standard entity
    /// </summary>
    public abstract class StandardEntity : BaseEntity
    {
        #region Private Members

        private uint mProgressPercentage = 0;

        #endregion

        #region Public Properties

        /// <summary>
        /// The progress percentage
        /// </summary>
        /// <remarks>Default : 0</remarks>
        /// <value>Min: 0 - Max: 100</value>
        public uint ProgressPercentage 
        {
            get => mProgressPercentage; 
            set
            {
                mProgressPercentage = value;
                // If the value is greater than 100...
                if (mProgressPercentage > 100)
                    mProgressPercentage = 100;
            }
        } 

        /// <summary>
        /// The start date
        /// </summary>
        public DateTimeOffset DateStart { get; set; }

        /// <summary>
        /// A flag indicating whether it has a <see cref="DateEnd"/> or not
        /// </summary>
        public bool HasDateEnd { get; set; }

        /// <summary>
        /// The finish date
        /// </summary>
        public DateTimeOffset? DateEnd { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public StandardEntity() : base()
        {

        }

        #endregion
    }
}
