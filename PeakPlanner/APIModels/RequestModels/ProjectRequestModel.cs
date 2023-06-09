﻿namespace PeakPlannerAPI
{
    public class ProjectRequestModel : StandardRequestModel
    {
        #region Public Properties

        /// <summary>
        /// The name
        /// </summary>
        public string? Name { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public ProjectRequestModel() : base()
        {

        }

        #endregion
    }
}
