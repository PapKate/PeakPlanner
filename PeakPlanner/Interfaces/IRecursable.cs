namespace PeakPlannerAPI
{
    /// <summary>
    /// Provides abstractions for an object that has recursion in itself
    /// </summary>
    public interface IRecursable<T>
        where T : class, IIdentifiable
    {
        #region Properties

        /// <summary>
        /// The id of the parent
        /// The <see cref="IIdentifiable.Id"/> of the related <see cref="T"/>
        /// </summary>
        int? ParentId { get; set; }

        /// <summary>
        /// The related <see cref="T"/>
        /// </summary>
        T? Parent { get; set; }

        /// <summary>
        /// The children
        /// </summary>
        IEnumerable<T>? Children { get; set; }

        #endregion
    }
}
