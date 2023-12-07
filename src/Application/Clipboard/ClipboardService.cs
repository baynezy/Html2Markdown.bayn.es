using Microsoft.JSInterop;

namespace Application.Clipboard;

public class ClipboardService(IJSRuntime jsInterop) : IClipboardService
{
    public async Task CopyToClipboardAsync(string text)
    {
        await jsInterop.InvokeVoidAsync("navigator.clipboard.writeText", text);
    }
}