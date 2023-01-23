using Microsoft.AspNetCore.Components;
using MudBlazor;
using PWA.Components;

namespace PWA.Pages
{
    public partial class Index : ComponentBase
    {
        [Inject]
        IDialogService DialogService { get; set; }
        async Task ShowFileUploadComponent()
        {
            var options = new DialogOptions
            {
                MaxWidth = MaxWidth.ExtraExtraLarge,
                CloseButton = true,
            };

            var dialog = await DialogService.ShowAsync<FileUploadDialog>("Selectare fisiere", options);
            var result = await dialog.Result;
        }

    }
}
