using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Dal.Entities.Core
{
    public class ClimateEntity
    {
        [Key]
        public int Id { get; private set; }

        [Required]
        public string Name { get; private set; }
        public string TemperatureUnit { get; private set; }
        public float CurrentTemperature { get; private set; }
        public float CurrentHumidity { get; private set; }
        public float TargetTemperature { get; private set; }
        public float TargetHumidity { get; private set; }

        public ClimateEntity(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
