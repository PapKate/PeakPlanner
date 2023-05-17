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

    /// <summary>
    /// Provides abstractions for an object that has a date created and date modified
    /// </summary>
    public interface IDateable
    {
        #region Properties

        /// <summary>
        /// The date it was created
        /// </summary>
        DateTimeOffset DateCreated { get; set; }

        /// <summary>
        /// The date it was last modified
        /// </summary>
        DateTimeOffset DateModified { get; set; }
        
        #endregion
    }
}
