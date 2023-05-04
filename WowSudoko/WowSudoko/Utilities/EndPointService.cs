using System;
using WowSudoko.Utilities.Interface;

namespace WowSudoko.Utilities
{
    public class EndPointService: IEndpointService
    {
        public EndPointService()
        {
        }

        public string ApiPortNo { get { return GetEndpointService(); } set { } }
        public string ApiServerName { get { return GetApiServerName(); } set { } }

        public string GetApiServerName()
        {
            return "";
        }

        public string GetEndpointService()
        {
            return "";
        }
    }
}
