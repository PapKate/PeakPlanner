using FoPeakPlannerAPIoli;

namespace PeakPlannerAPI
{
    /// <summary>
    /// The project entity
    /// </summary>
    public class ProjectEntity : StandardEntity
    {
        #region Private Members

        /// <summary>
        /// The member of the <see cref="Name"/> property
        /// </summary>
        private string? mName;

        #endregion

        #region Public Properties

        /// <summary>
        /// The name
        /// </summary>
        public string Name
        {
            get => mName ?? string.Empty;
            set => mName = value;
        }

        #region Relationships

        /// <summary>
        /// The list of the related <see cref="TaskEntity"/>
        /// </summary>
        public IEnumerable<TaskEntity>? Tasks { get; set; }

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public ProjectEntity() : base()
        {

        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Creates and returns a <see cref="ProjectEntity"/> from the specified <paramref name="model"/>
        /// </summary>
        /// <param name="projectId">The company's id</param>
        /// <param name="model">The model</param>
        /// <returns></returns>
        public static ProjectEntity FromRequestModel(ProjectRequestModel model)
            => ControllerHelpers.FromRequestModel<ProjectEntity, ProjectRequestModel>(model);

        /// <summary>
        /// Creates and returns a <see cref="ProjectResponseModel"/> from the current <see cref="ProjectEntity"/>
        /// </summary>
        /// <returns></returns>
        public ProjectResponseModel ToResponseModel()
            => ControllerHelpers.ToResponseModel<ProjectEntity, ProjectResponseModel>(this);

        #endregion
    }
}
