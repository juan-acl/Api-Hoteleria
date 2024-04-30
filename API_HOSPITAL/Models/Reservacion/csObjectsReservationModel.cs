using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_HOSPITAL.Models.ReservationModel
{
    public class csObjectsReservationModel
    {
        public class createReservation
        {
            public decimal Total { get; set; }
            public DateTime EmitionDate { get; set; }
            public int IdClient { get; set; }
        }
        public class responseReservation
        {
            public int status { get; set; }
            public string message { get; set; }
        }
    }
}