using System;

namespace PeakPlannerAPI
{
    /// <summary>
    /// Helper methods for <see cref="Type"/>
    /// </summary>
    public static class TypeHelpers
    {
        #region Public Methods

        /// <summary>
        /// Gets the T from the <see cref="Nullable{T}"/> of the specified <paramref name="type"/>
        /// when the <paramref name="type"/> is nullable, otherwise it returns the type
        /// </summary>
        /// <param name="type">The type</param>
        /// <returns></returns>
        public static Type GetNonNullableType(Type type)
            => Nullable.GetUnderlyingType(type) ?? type;

        #endregion
    }
}
