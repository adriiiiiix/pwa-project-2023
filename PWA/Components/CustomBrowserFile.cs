using Microsoft.AspNetCore.Components.Forms;

namespace PWA.Components
{
    public sealed class CustomBrowserFile
    {
        public IBrowserFile File { get; set; }
        public FileStatus Status { get; set; }
        public string Message { get; set; }
    }
}
