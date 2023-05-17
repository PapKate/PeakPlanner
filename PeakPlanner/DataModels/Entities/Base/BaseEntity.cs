using System.ComponentModel.DataAnnotations.Schema;
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

    /// <summary>
    /// The standard entity
    /// </summary>
    public abstract class StandardEntity : BaseEntity
    {
        #region Private Members

        /// <summary>
        /// The member of the <see cref="Title"/> property
        /// </summary>
        private string? mTitle;

        /// <summary>
        /// The member of the <see cref="Description"/> property
        /// </summary>
        private string? mDescription;

        #endregion

        #region Public Properties

        /// <summary>
        /// The title
        /// </summary>
        public string Title 
        { 
            get => mTitle ?? string.Empty;
            set => mTitle = value; 
        }

        /// <summary>
        /// The description
        /// </summary>
        public string Description
        {
            get => mDescription ?? string.Empty;
            set => mDescription = value;
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public StandardEntity() : base()
        {

        }

        #endregion
    }
}
