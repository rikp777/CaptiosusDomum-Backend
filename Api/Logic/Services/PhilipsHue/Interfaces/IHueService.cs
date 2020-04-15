using Q42.HueApi.Models.Bridge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Logic.Hue.Interfaces
{
    public interface IHueService
    {
        Task<IEnumerable<LocatedBridge>> DiscoverBridgesAsync();
        Task<string> RegisterHueBridge(string HueBridgeIp);
        //Task<IEnumerable<LocatedBridge>> FindBridge();
        //Task<string> RegisterApplication(string BridgeIp);
        //void IntializeBridge(string BridgeIp, string PersonalAppKey);


    }
}
