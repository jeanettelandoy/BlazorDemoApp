using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlazorDemoApp.Models
{
    public class DisplayTransportationModel
    {
        public int id { get; set; }
        [Required]
        [StringLength(20, ErrorMessage = "Company name is too long")]
        [MinLength(1, ErrorMessage = "Company name is too short")]
        public string CompanyName { get; set; }
        public string TransportationName { get; set; }
        public string TransportationType { get; set; }
        public string TransportationCharacteristics { get; set; }
        public DateTime? Registered { get; set; }

    }
}
