using System;
namespace WowSudoko.Utilities.Interface
{
    public interface IEndpointService
    {
        string ApiPortNo { get; set; }

        string ApiServerName { get; set; }

        string GetEndpointService();

        string GetApiServerName();
    }
}
