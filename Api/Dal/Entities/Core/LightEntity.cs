using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Dal.Entities.Core
{
    public class LightEntity
    {
        [Key]
        public int Id { get; private set; }
        public int LightId { get; private set; }
        public int Brightness { get; private set; }
        public int ColorTemp { get; private set; }
        public string Effect { get; private set; }
        public int Color { get; private set; }
        public bool IsOn { get; private set; }
    }
}
