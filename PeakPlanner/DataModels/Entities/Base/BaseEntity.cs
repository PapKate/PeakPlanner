﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PeakPlannerAPI
{
    /// <summary>
    /// The base entity with the date created and modified properties
    /// </summary>
    public abstract class BaseEntity : IIdentifiable, IDateable
    {
        #region Public Properties

        /// <summary>
        /// The id
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// The date it was created
        /// </summary>
        public DateTimeOffset DateCreated { get; set; } = DateTimeOffset.Now;

        /// <summary>
        /// The date it was last modified
        /// </summary>
        public DateTimeOffset DateModified { get; set; } = DateTimeOffset.Now;

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public BaseEntity() : base()
        {

        }

        #endregion
    }
}
