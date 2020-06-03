using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Dal.Entities
{
    public class HueBridgeEntity
    {
        [Key]
        public int Id { get; private set; }
        [Required]
        public string BridgeIp { get; private set; }
        [Required]
        public string AppKey { get; private set; }

        public HueBridgeEntity()
        {}

        public HueBridgeEntity(string bridgeIp, string appKey)
        {
            BridgeIp = bridgeIp ?? throw new ArgumentNullException(nameof(bridgeIp));
            AppKey = appKey ?? throw new ArgumentNullException(nameof(appKey));
        }
    }
}
