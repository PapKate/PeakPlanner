namespace PeakPlannerAPI
{
    public class TaskAndLabelEntity : IIdentifiable
    {
        #region Public Properties

        /// <summary>
        /// The id
        /// </summary>
        public int Id { get; set; }

        #region Relationships

        /// <summary>
        /// The <see cref="BaseEntity.Id"/> of the related <see cref="LabelEntity"/>
        /// </summary>
        public int LabelId { get; set; }

        /// <summary>
        /// The related <see cref="LabelEntity"/>
        /// </summary>
        public LabelEntity? Label { get; set; }

        /// <summary>
        /// The <see cref="BaseEntity.Id"/> of the related <see cref="TaskEntity"/>
        /// </summary>
        public int TaskId { get; set; }

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Deefault constructor
        /// </summary>
        public TaskAndLabelEntity() : base()
        {
            
        }

        #endregion
    }
}
