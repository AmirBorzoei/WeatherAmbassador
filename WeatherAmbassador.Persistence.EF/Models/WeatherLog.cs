using System;
using System.ComponentModel.DataAnnotations;

namespace WeatherAmbassador.Persistence.EF.Models
{
    public class WeatherLog
    {
        [Key] 
        public int Id { get; set; }
        [MaxLength(128)] 
        public string ApiCallKey { get; set; }
        [MaxLength(1024)] 
        public string ApiCallResult { get; set; }
        public DateTime ApiCallDate { get; set; }
    }
}