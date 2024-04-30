using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_HOSPITAL.Models.Empleados
{
    public class csObjectEmpleados
    {
        public class createEmpleado
        {
            public string name { get; set; }
            public string lastname { get; set; }
            public string email { get; set; }
            public string password { get; set; }
            public string phone_number { get; set; }
            public string id_hotel { get; set; }
        }
        public class updateEmpleado
        {
            public string name { get; set; }
            public string lastname { get; set; }
            public string email { get; set; }
            public string password { get; set; }
            public string phone_number { get; set; }
            public string id_hotel { get; set; }
            public int id_empleado { get; set; }
        }
        public class deleteEmpleado
        {
            public int id_empleado { get; set; }
        }
        public class responseEmpleado
        {
            public int status { get; set; }
            public string message { get; set; }
        }
    }
}