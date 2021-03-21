using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLibrary.Models
{
    public class TransportationModel
    {
        public int id { get; set; }
        public string CompanyName { get; set; }
        public string TransportationName { get; set; }
        public string TransportationType { get; set; }
        public string TransportationCharacteristics { get; set; }
        public DateTime? Registered { get; set; }

    }
}
