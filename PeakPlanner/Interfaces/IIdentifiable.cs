namespace PeakPlannerAPI
{
    /// <summary>
    /// Provides abstractions for an object that has an id
    /// </summary>
    public interface IIdentifiable
    {
        #region Properties

        /// <summary>
        /// The id
        /// </summary>
        int Id { get; set; }
        
        #endregion
    }
}
