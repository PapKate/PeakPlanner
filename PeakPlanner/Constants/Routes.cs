﻿namespace PeakPlannerAPI.Constants
{
    /// <summary>
    /// The strings that represent the API routes
    /// </summary>
    public static class Routes
    {
        /// <summary>
        /// The home route
        /// </summary>
        /// <remarks>
        /// <code>
        /// peakPlanner
        /// </code>
        /// </remarks>
        public const string HomeRoute = "peakPlanner";

        /// <summary>
        /// The labels route
        /// </summary>
        /// <remarks>
        /// <code>
        /// peakPlanner/labels
        /// </code>
        /// </remarks>
        public const string LabelsRoute = HomeRoute + "/labels";

        /// <summary>
        /// The label route
        /// </summary>
        /// <remarks>
        /// <code>
        /// peakPlanner/labels/{labelId}
        /// </code>
        /// </remarks>
        public const string LabelRoute = LabelsRoute + "/{labelId}";

        #region Project Routes

        /// <summary>
        /// The projects route
        /// </summary>
        /// <remarks>
        /// <code>
        /// peakPlanner/projects
        /// </code>
        /// </remarks>
        public const string ProjectsRoute = HomeRoute + "/projects";

        /// <summary>
        /// The project route
        /// </summary>
        /// <remarks>
        /// <code>
        /// peakPlanner/projects/{projectId}
        /// </code>
        /// </remarks>
        public const string ProjectRoute = ProjectsRoute + "/{projectId}";

        #region Task Routes

        /// <summary>
        /// The projects route
        /// </summary>
        /// <remarks>
        /// <code>
        /// peakPlanner/projects/{projectId}/tasks
        /// </code>
        /// </remarks>
        public const string TasksRoute = ProjectRoute + "/tasks";

        /// <summary>
        /// The project route
        /// </summary>
        /// <remarks>
        /// <code>
        /// peakPlanner/projects/{projectId}/tasks/{taskId}
        /// </code>
        /// </remarks>
        public const string TaskRoute = TasksRoute + "/{taskId}";

        #endregion

        #endregion
    }
}
