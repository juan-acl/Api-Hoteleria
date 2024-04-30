using API_HOSPITAL.Models.ReservationModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;
using static API_HOSPITAL.Models.ReservationModel.csObjectsReservationModel;

namespace API_HOSPITAL.Controllers
{
    public class ReservationsController : ApiController
    {
        [HttpPost]
        [Route("rest/api/createReservation")]
        public IHttpActionResult CreateReservation (createReservation model)
        {
            return Ok(new csReservationModel().CreateReservation(model.Total, model.EmitionDate, model.IdClient));
        }
        [HttpPost]
        [Route("rest/api/updateReservation")]
        public IHttpActionResult UpdateReservation(updateReservation model)
        {
            return Ok(new csReservationModel().UpdateReservation(model.Total, model.EmitionDate, model.IdClient, model.IdReservation));
        }
        [HttpPost]
        [Route("rest/api/getAllReservations")]
        public IHttpActionResult GetAllReservations()
        {
            return Ok(new csReservationModel().GetAllReservations());
        }
    }
}