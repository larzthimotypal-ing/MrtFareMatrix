using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;


namespace app.domain
{
    public class Destination : BaseEntity
        {
        [DisplayName("Destination ID")]
        public int DestinationID { get; set; }

        public Issue Issue { get; set; }

        [DisplayName("Rail Stations")]
        public string RailStations { get; set; }

        [DisplayName("Departure Time ")]
        public DateTime DepartureTime{ get; set; }

        [DisplayName("Estimated Time of Travel ")]
        public DateTime EstimatedTravelTime { get; set; }

        [DisplayName("Arrival Time ")]
        public DateTime ArrivalTime { get; set; }

        public float Fare { get; set; }
    }
}
