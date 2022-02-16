using System.ComponentModel.DataAnnotations;

namespace WeatherAmbassador.Persistence.EF.Models
{
    public class Setting
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(256)]
        public string SettingKey { get; set; }

        [MaxLength(1024)]
        public string SettingValue { get; set; }
    }
}