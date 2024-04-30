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
    public class resertvationController : ApiController
    {
        [HttpPost]
        [Route("rest/api/createReservation")]
        public IHttpActionResult CreateReservation (createReservation model)
        {
            return Ok(new csReservationModel().createReservation(model.Total, model.EmitionDate, model.IdClient));
        }
    }
}