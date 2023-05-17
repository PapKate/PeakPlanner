namespace PeakPlannerAPI
{
    /// <summary>
    /// Provides enumerations over the status of a <see cref="TaskEntity"/>
    /// </summary>
    public enum TaskStatus
    {
        /// <summary>
        /// To do
        /// </summary>
        ToDo,
        
        /// <summary>
        /// In progress
        /// </summary>
        InProgress,
        
        /// <summary>
        /// In review
        /// </summary>
        InReview,
        
        /// <summary>
        /// Done
        /// </summary>
        Done
    }
}
