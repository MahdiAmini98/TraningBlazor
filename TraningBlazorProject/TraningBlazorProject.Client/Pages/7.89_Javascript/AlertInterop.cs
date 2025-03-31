using Microsoft.JSInterop;

namespace TraningBlazorProject.Client.Pages._7._89_Javascript
{
    public class AlertInterop(IJSRuntime jsRuntime) : IDisposable
    {

        public async Task ShowAnimatedAlert(string message)
        {
            await jsRuntime.InvokeVoidAsync("showAnimatedAlert", message);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
