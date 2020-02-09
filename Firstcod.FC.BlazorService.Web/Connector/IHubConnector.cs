using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Firstcod.FC.BlazorService.Web.Connector
{
    public interface IHubConnector
    {
        Task ShowToast(string type, string title, string message);
    }
}
