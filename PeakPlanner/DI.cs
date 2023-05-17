using AutoMapper;

using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace PeakPlannerAPI
{
    /// <summary>
    /// The default application services that should be available everywhere in the application
    /// </summary>
    public static class DI
    {
        #region Private Members

        /// <summary>
        /// The member of the <see cref="GetMapper"/> property
        /// </summary>
        private static IMapper? mMapper;

        #endregion

        #region Public Properties

        /// <summary>
        /// The host
        /// </summary>
        public static IHost? Host { get; set; }

        /// <summary>
        /// The mapper
        /// </summary>
        public static IMapper GetMapper
        {
            get
            {
                if (mMapper is null)
                    mMapper = Host?.Services.GetService<Mapper>();

                return mMapper!;
            }
        }

        #endregion
    }
}
