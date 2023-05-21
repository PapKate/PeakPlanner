using FoPeakPlannerAPIoli;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using PeakPlannerAPI.Constants;

namespace PeakPlannerAPI
{
    public class ProjectController : Controller
    {
        #region Private Members

        /// <summary>
        /// The DB context
        /// </summary>
        private readonly PeakPlannerDBContext mContext;

        #endregion

        #region Protected Properties

        /// <summary>
        /// The query used for retrieving the projects
        /// </summary>
        protected IQueryable<ProjectEntity> ProjectsQuery => mContext.Projects.Include(x => x.Tasks!).ThenInclude(t => t.Labels!).ThenInclude(p => p.Label);

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public ProjectController(PeakPlannerDBContext context)
        {
            mContext = context;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Creates a new project
        /// </summary>
        /// <remarks>
        /// POST <code>peakPlanner/projects</code> 
        /// </remarks>
        /// <param name="model">The project request model</param>
        [HttpPost]
        [Route(Routes.ProjectsRoute)]
        public Task<ActionResult<ProjectResponseModel>> CreateProjectAsync([FromBody] ProjectRequestModel model)
            => ControllerHelpers.PostAsync(
                mContext,
                mContext.Projects,
                ProjectEntity.FromRequestModel(model),
                x => x.ToResponseModel());

        /// <summary>
        /// Gets all the projects
        /// </summary>
        /// <remarks>
        /// GET <code>peakPlanner/projects</code> 
        /// </remarks>
        [HttpGet]
        [Route(Routes.ProjectsRoute)]
        public Task<ActionResult<IEnumerable<ProjectResponseModel>>> GetProjectsAsync() 
            => ControllerHelpers.GetAllAsync<ProjectEntity, ProjectResponseModel>(
                ProjectsQuery.AsNoTracking(),
                x => true);

        /// <summary>
        /// Gets the project with the specified id
        /// </summary>
        /// <remarks>
        /// GET <code>peakPlanner/projects/14</code> 
        /// </remarks>
        /// <param name="projectId">The project id</param>
        [HttpGet]
        [Route(Routes.ProjectRoute)]
        public Task<ActionResult<ProjectResponseModel>> GetProjectAsync([FromRoute] int projectId)
            => ControllerHelpers.GetAsync<ProjectEntity, ProjectResponseModel>(
               ProjectsQuery.AsNoTracking(),
               DI.GetMapper,
               x => x.Id == projectId);

        /// <summary>
        /// Updates the data of the project with the specified <paramref name="projectId"/>
        /// </summary>
        /// <remarks>
        /// PUT <code>peakPlanner/projects/14</code> 
        /// </remarks>
        /// <param name="projectId">The project id</param>
        /// <param name="model">The model</param>
        [HttpPut]
        [Route(Routes.ProjectRoute)]
        public Task<ActionResult<ProjectResponseModel>> UpdateProjectAsync([FromRoute] int projectId, [FromBody] ProjectRequestModel model)
            => ControllerHelpers.PutAsync<ProjectRequestModel, ProjectEntity, ProjectResponseModel>(
                mContext,
                ProjectsQuery,
                model,
                x => x.Id == projectId);

        /// <summary>
        /// Deletes the project with the specified <paramref name="projectId"/>
        /// </summary>
        /// <remarks>
        /// DELETE <code>peakPlanner/projects/14</code> 
        /// </remarks>
        /// <param name="projectId">The project id</param>
        [HttpDelete]
        [Route(Routes.ProjectRoute)]
        public Task<ActionResult<ProjectResponseModel>> DeleteProjectAsync([FromRoute] int projectId) 
            => ControllerHelpers.DeleteAsync<ProjectEntity, ProjectResponseModel>(
                mContext,
                mContext.Projects,
                DI.GetMapper,
                x => x.Id == projectId);

        #endregion
    }
}
