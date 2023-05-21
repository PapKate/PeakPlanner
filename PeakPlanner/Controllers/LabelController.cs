using FoPeakPlannerAPIoli;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using PeakPlannerAPI.Constants;

namespace PeakPlannerAPI
{
    public class LabelController : Controller
    {
        #region Private Members

        /// <summary>
        /// The DB context
        /// </summary>
        private readonly PeakPlannerDBContext mContext;

        #endregion

        #region Protected Properties

        /// <summary>
        /// The query used for retrieving the labels
        /// </summary>
        protected IQueryable<LabelEntity> LabelsQuery => mContext.Labels;

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public LabelController(PeakPlannerDBContext context)
        {
            mContext = context;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Creates a new label
        /// </summary>
        /// <remarks>
        /// POST <code>peakPlanner/labels</code> 
        /// </remarks>
        /// <param name="model">The label request model</param>
        [HttpPost]
        [Route(Routes.LabelsRoute)]
        public Task<ActionResult<LabelResponseModel>> CreateLabelAsync([FromBody] LabelRequestModel model)
            => ControllerHelpers.PostAsync(
                mContext,
                mContext.Labels,
                LabelEntity.FromRequestModel(model),
                x => x.ToResponseModel());

        /// <summary>
        /// Gets all the labels
        /// </summary>
        /// <remarks>
        /// GET <code>peakPlanner/labels</code> 
        /// </remarks>
        [HttpGet]
        [Route(Routes.LabelsRoute)]
        public Task<ActionResult<IEnumerable<LabelResponseModel>>> GetLabelsAsync()
            => ControllerHelpers.GetAllAsync<LabelEntity, LabelResponseModel>(
                LabelsQuery,
                x => true);

        /// <summary>
        /// Gets the label with the specified id
        /// </summary>
        /// <remarks>
        /// GET <code>peakPlanner/labels/14</code> 
        /// </remarks>
        /// <param name="labelId">The label id</param>
        [HttpGet]
        [Route(Routes.LabelRoute)]
        public Task<ActionResult<LabelResponseModel>> GetLabelAsync([FromRoute] int labelId)
            => ControllerHelpers.GetAsync<LabelEntity, LabelResponseModel>(
               LabelsQuery,
               DI.GetMapper,
               x => x.Id == labelId);

        /// <summary>
        /// Updates the data of the label with the specified <paramref name="labelId"/>
        /// </summary>
        /// <remarks>
        /// PUT <code>peakPlanner/labels/14</code> 
        /// </remarks>
        /// <param name="labelId">The label id</param>
        /// <param name="model">The model</param>
        [HttpPut]
        [Route(Routes.LabelRoute)]
        public Task<ActionResult<LabelResponseModel>> UpdateLabelAsync([FromRoute] int labelId, [FromBody] LabelRequestModel model)
            => ControllerHelpers.PutAsync<LabelRequestModel, LabelEntity, LabelResponseModel>(
                mContext,
                LabelsQuery,
                model,
                x => x.Id == labelId);

        /// <summary>
        /// Deletes the label with the specified <paramref name="labelId"/>
        /// </summary>
        /// <remarks>
        /// DELETE <code>peakPlanner/labels/14</code> 
        /// </remarks>
        /// <param name="labelId">The label id</param>
        [HttpDelete]
        [Route(Routes.LabelRoute)]
        public Task<ActionResult<LabelResponseModel>> DeleteLabelAsync([FromRoute] int labelId)
            => ControllerHelpers.DeleteAsync<LabelEntity, LabelResponseModel>(
                mContext,
                mContext.Labels,
                DI.GetMapper,
                x => x.Id == labelId);

        #endregion
    }
}
