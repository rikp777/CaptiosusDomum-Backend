using Api.Dal.Interface;
using Api.Logic.Hue.Interfaces;
using Q42.HueApi;
using Q42.HueApi.Interfaces;
using Q42.HueApi.Models.Bridge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Logic
{
    public class HueService: IHueService
    {
        private readonly ILocalHueClient _client;
        private readonly IUserContext _userContext;


        public HueService(ILocalHueClient client, IUserContext userContext)
        {
            _client = client;
            _userContext = userContext;
        }

        public async Task<IEnumerable<LocatedBridge>> DiscoverBridgesAsync()
        {
            IBridgeLocator locator = new HttpBridgeLocator(); //Or: LocalNetworkScanBridgeLocator, MdnsBridgeLocator, MUdpBasedBridgeLocator
            return await locator.LocateBridgesAsync(TimeSpan.FromSeconds(5));
        }

        public async Task<string> RegisterHueBridge(string HueBridgeIp)
        {
            ILocalHueClient client = new LocalHueClient(HueBridgeIp);
            //Make sure the user has pressed the button on the bridge before calling RegisterAsync
            //It will throw an LinkButtonNotPressedException if the user did not press the button
            var appkey = await client.RegisterAsync("CaptiosusDomum", "ThinkpadT470");
            //Save the app key for later use

            await _userContext.AddBridgeToUser(new Dal.Entities.HueBridgeEntity(HueBridgeIp, appkey));

            return appkey;
        }

        public void InitializeHueBridge(string PersonalAppKey)
        {
            _client.Initialize(PersonalAppKey);
        }
    }
}
