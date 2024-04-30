using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_HOSPITAL.Models.Reservation
{
    public class csObjectsReservation
    {
        public class requestReservation
        {
            public int IdReservation { get; set; }
            public decimal Total { get; set; }
            public DateTime EmitionDate { get; set; }
            public int IdClient { get; set; }
        }
    }
}