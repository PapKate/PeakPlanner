using FoPeakPlannerAPIoli;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using PeakPlannerAPI.Constants;

namespace PeakPlannerAPI
{
    public class TaskController : Controller
    {
        #region Private Members

        /// <summary>
        /// The DB context
        /// </summary>
        private readonly PeakPlannerDBContext mContext;

        /// <summary>
        /// The repository
        /// </summary>
        private readonly TaskRepository mRepository;

        #endregion

        #region Protected Properties

        /// <summary>
        /// The query used for retrieving the projects
        /// </summary>
        protected IQueryable<TaskEntity> TasksQuery => mContext.Tasks.Include(x => x.Labels!).ThenInclude(y => y.Label);

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public TaskController(PeakPlannerDBContext context, TaskRepository repository)
        {
            mContext = context;
            mRepository = repository;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Creates a new task for the project with the specified <paramref name="projectId"/>
        /// </summary>
        /// <remarks>
        /// POST <code>peakPlanner/projects/12/tasks</code> 
        /// </remarks>
        /// <param name="model">The task request model</param>
        [HttpPost]
        [Route(Routes.TasksRoute)]
        public async Task<ActionResult<TaskResponseModel>> CreateTaskAsync([FromRoute] int projectId, [FromBody] TaskRequestModel model)
        {
            var entity = await mRepository.AddTaskAsync(projectId, model);

            return entity.ToResponseModel();
        }

        /// <summary>
        /// Gets all the tasks for the project with the specified <paramref name="projectId"/>
        /// </summary>
        /// <remarks>
        /// GET <code>peakPlanner/projects/12/tasks</code> 
        /// </remarks>
        [HttpGet]
        [Route(Routes.TasksRoute)]
        public Task<ActionResult<IEnumerable<TaskResponseModel>>> GetTasksAsync()
            => ControllerHelpers.GetAllAsync<TaskEntity, TaskResponseModel>(
                TasksQuery.AsNoTracking(),
                x => true);

        /// <summary>
        /// Gets the task with the specified id
        /// </summary>
        /// <remarks>
        /// GET <code>peakPlanner/projects/14/tasks/2</code> 
        /// </remarks>
        /// <param name="projectId">The project id</param>
        /// <param name="taskId">The task id</param>
        [HttpGet]
        [Route(Routes.TaskRoute)]
        public Task<ActionResult<TaskResponseModel>> GetTaskAsync([FromRoute] int projectId, [FromRoute] int taskId)
            => ControllerHelpers.GetAsync<TaskEntity, TaskResponseModel>(
               TasksQuery.AsNoTracking(),
               DI.GetMapper,
               x => x.Id == taskId && x.ProjectId == projectId);

        /// <summary>
        /// Updates the data of the task with the specified <paramref name="taskId"/>
        /// </summary>
        /// <remarks>
        /// PUT <code>peakPlanner/projects/14/tasks/2</code> 
        /// </remarks>
        /// <param name="projectId">The project id</param>
        /// <param name="taskId">The task id</param>
        /// <param name="model">The model</param>
        [HttpPut]
        [Route(Routes.TaskRoute)]
        public async Task<ActionResult<TaskResponseModel>> UpdateTaskAsync([FromRoute] int projectId, [FromRoute] int taskId, [FromBody] TaskRequestModel model)
        {
            // Updates the entity
            var entity = await mRepository.UpdateTaskAsync(projectId, taskId, model);

            // If the entity does not exist...
            if (entity is null)
                return NotFound();

            return entity.ToResponseModel();
        }

        /// <summary>
        /// Deletes the task with the specified <paramref name="taskId"/>
        /// </summary>
        /// <remarks>
        /// DELETE <code>peakPlanner/projects/14/tasks/2</code> 
        /// </remarks>
        /// <param name="projectId">The project id</param>
        /// <param name="taskId">The task id</param>
        [HttpDelete]
        [Route(Routes.TaskRoute)]
        public Task<ActionResult<TaskResponseModel>> DeleteTaskAsync([FromRoute] int projectId, [FromRoute] int taskId)
            => ControllerHelpers.DeleteAsync<TaskEntity, TaskResponseModel>(
                mContext,
                mContext.Tasks,
                DI.GetMapper,
                x => x.Id == taskId && x.ProjectId == projectId);

        #endregion
    }
}
