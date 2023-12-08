namespace Application.Clipboard;

public interface IClipboardService
{
    Task CopyToClipboardAsync(string text);
}