using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Firstcod.FC.BlazorService.Web.Components
{
    public class ToastrComponent : ComponentBase
    {
        private readonly IJSRuntime _jsRuntime;

        public ToastrComponent(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public async Task ShowToast(string type, string title, string message)
        {
            await _jsRuntime.InvokeVoidAsync("showToast", type, title, message);
        }
    }

    public enum ToastType
    {
        Success,
        Error,
        Warning,
        Info
    }
}
