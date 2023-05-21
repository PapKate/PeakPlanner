using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;
using System.Linq.Expressions;

namespace PeakPlannerAPI
{
    public class TaskRepository
    {
        #region Private Members

        /// <summary>
        /// The context
        /// </summary>
        private readonly PeakPlannerDBContext mDbContext;

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public TaskRepository(PeakPlannerDBContext context) : base()
        {
            mDbContext = context;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Creates and adds a task to the data base
        /// </summary>
        /// <param name="projectId">The project id</param>
        /// <param name="model">The model</param>
        /// <returns></returns>
        public async Task<TaskEntity> AddTaskAsync(int projectId, TaskRequestModel model)
        {
            // Creates the entity from the request model
            var taskEntity = TaskEntity.FromRequestModel(projectId, model);

            // Adds it to the context
            mDbContext.Tasks.Add(taskEntity);
            
            // Saves the changes in the database
            await mDbContext.SaveChangesAsync();
            
            // If there are label ids...
            if (model.LabelIds is not null)
            {
                // Gets the labels from the context
                var labels = await mDbContext.Labels.Where(x => model.LabelIds.Contains(x.Id)).ToListAsync();

                // Creates a new pair for each label and the task entity
                var pairsToAdd = labels.Select(x => new TaskAndLabelEntity() { TaskId = taskEntity.Id, Label = x }).ToList();
             
                // Adds the pairs to the context
                mDbContext.TaskAndLabels.AddRange(pairsToAdd);
            
                // Saves the changes in the database
                await mDbContext.SaveChangesAsync();
            }

            // Returns the task entity
            return taskEntity;
        }

        /// <summary>
        /// Updates a task entity
        /// </summary>
        /// <param name="projectId">The project id</param>
        /// <param name="taskId">The task id</param>
        /// <param name="model">The model</param>
        /// <returns></returns>
        public async Task<TaskEntity?> UpdateTaskAsync(int projectId, int taskId, TaskRequestModel model)
        {
            // Gets the entity if exists
            var taskEntity = await mDbContext.Tasks.Include(x => x.Labels).FirstOrDefaultAsync(x => x.Id == taskId && x.ProjectId == projectId);

            // If no entity is found...
            if (taskEntity is null)
                // Return not found
                return null;

            // Copy the non-null values from the request model to the entity
            DI.GetMapper.Map(model, taskEntity);

            // Sets the date the entity was last modified as now
            taskEntity.DateModified = DateTimeOffset.Now;

            // Saves the changes in the database
            await mDbContext.SaveChangesAsync();

            // If there are label ids...
            if (model.LabelIds is not null)
            {
                // If the entity has labels...
                if(taskEntity.Labels is not null && model.LabelIds != taskEntity.Labels.Select(x => x.LabelId))
                {
                    // Gets the pairs where the label id does not exist in the model label ids
                    var pairsToRemove = taskEntity.Labels.Where(x => !model.LabelIds.Contains(x.LabelId)).ToList();
                    
                    // Removes the pairs from the context
                    mDbContext.TaskAndLabels.RemoveRange(pairsToRemove);

                    // Gets the label ids that do not exist in the labels of the task entity...
                    // And creates the pairs
                    var pairsToAdd = model.LabelIds.Where(x => !taskEntity.Labels.Any(y => x == y.LabelId)).Select(x => new TaskAndLabelEntity() { TaskId = taskEntity.Id, LabelId = x});
                
                    // Adds the pairs to the context
                    mDbContext.TaskAndLabels.AddRange(pairsToAdd);
                }

                var pairs = model.LabelIds.Select(x => new TaskAndLabelEntity() { TaskId = taskEntity.Id, LabelId = x });

                // Adds the pairs to the context
                mDbContext.TaskAndLabels.AddRange(pairs);


                // Saves the changes in the database
                await mDbContext.SaveChangesAsync();
            }

            // Returns the entity
            return taskEntity;
        }

        #endregion
    }
}
