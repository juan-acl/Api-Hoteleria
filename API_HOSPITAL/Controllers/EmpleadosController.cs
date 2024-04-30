using API_HOSPITAL.Models.ReservationModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static API_HOSPITAL.Models.Empleados.csObjectEmpleados;
using System.Web.Http;
using API_HOSPITAL.Models.Empleados;

namespace API_HOSPITAL.Controllers
{
    public class EmpleadosController : ApiController
    {
        [HttpPost]
        [Route("rest/api/createEmployee")]
        public IHttpActionResult CreateReservation(createEmpleado model)
        {
            return Ok(new csEmpleados().CreateEmpleado(model.name, model.lastname, model.email, model.password, model.phone_number, model.id_hotel));
        }
        [HttpPost]
        [Route("rest/api/updateEmploye")]
        public IHttpActionResult UpdateReservation(updateEmpleado model)
        {
            return Ok(new csEmpleados().UpdateEmpleado(model.name, model.lastname, model.email, model.password, model.phone_number, model.id_hotel, model.id_empleado));
        }
        [HttpGet]
        [Route("rest/api/getEmployeById")]
        public IHttpActionResult GetEmployeById(int id_employee)
        {
            return Ok(new csEmpleados().GetEmpleadoById(id_employee));
        }
        [HttpPost]
        [Route("rest/api/getAllEmployees")]
        public IHttpActionResult GetAllReservations()
        {
            return Ok(new csEmpleados().GetEmpleados());
        }
        [HttpPost]
        [Route("rest/api/deleteEmployee")]
        public IHttpActionResult DeleteEmploye(deleteEmpleado model)
        {
            return Ok(new csEmpleados().DeleteEmpleado(model.id_empleado));
        }
    }
}