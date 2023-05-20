using FoPeakPlannerAPIoli;

namespace PeakPlannerAPI
{
    /// <summary>
    /// The task entity
    /// </summary>
    public class TaskEntity : StandardEntity
    {
        #region Public Properties

        /// <summary>
        /// The status
        /// </summary>
        public TaskStatus Status { get; set; }

        #region Relationships

        /// <summary>
        /// The <see cref="BaseEntity.Id"/> of the related <see cref="ProjectEntity"/>
        /// </summary>
        public int ProjectId { get; set; }

        /// <summary>
        /// The list containing related <see cref="TaskAndLabelEntity"/>
        /// </summary>
        public IEnumerable<TaskAndLabelEntity>? Labels { get; set; }

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public TaskEntity() : base()
        {

        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Creates and returns a <see cref="TaskEntity"/> from the specified <paramref name="model"/>
        /// </summary>
        /// <param name="projectId">The company's id</param>
        /// <param name="model">The model</param>
        /// <returns></returns>
        public static TaskEntity FromRequestModel(int projectId, TaskRequestModel model)
            => ControllerHelpers.FromRequestModel(model, (TaskEntity entity) => { entity.ProjectId = projectId; });

        /// <summary>
        /// Creates and returns a <see cref="TaskResponseModel"/> from the current <see cref="TaskEntity"/>
        /// </summary>
        /// <returns></returns>
        public TaskResponseModel ToResponseModel()
            => ControllerHelpers.ToResponseModel<TaskEntity, TaskResponseModel>(this);

        #endregion
    }
}
