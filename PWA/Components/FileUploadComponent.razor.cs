using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using Microsoft.AspNetCore.Components.Authorization;
using PWA.Shared.DTOs;
using PWA.Utilities;
using PWA.Services;

namespace PWA.Components
{
    public partial class FileUploadComponent : ComponentBase
    {
        [Parameter]
        public string FileTypes { get; set; }

        [Parameter]
        public int MaxFiles { get; set; } = 10;

        [Parameter]
        public int MaxSize { get; set; } = 1024 * 5;

        [Parameter]
        public EventCallback<bool> CanSelect { get; set; }

        [Inject]
        AuthenticationStateProvider GetAuthStateProvider { get; set; }
        [Inject]
        IHttpService HttpService { get; set; }

        MudMessageBox? msgBoxCapacityError, msgBoxDuplicateWarning;
        List<CustomBrowserFile> Files = new();
        List<IBrowserFile> Duplicates = new();
        string path, username;
        int mainProgress = 0, filesUploaded = 0, fileCount;
        bool isLoading;

        Stream _fileStream = null;
        string _selectedFileName = null;

        protected override async Task OnInitializedAsync()
        {
            var authstate = await GetAuthStateProvider.GetAuthenticationStateAsync();
            username = authstate?.User?.Identity.Name;
        }

        void OnInputFileChange(InputFileChangeEventArgs e)
        {
            isLoading = true;

            try
            {
                fileCount = e.FileCount;
                var browserFiles = e.GetMultipleFiles(MaxFiles);

                foreach (var file in browserFiles)
                {
                    // Check if the file is null then return from the method
                    if (file == null)
                        return;

                    // Validate the extension if requried (Client-Side)

                    // Set the value of the stream by calling OpenReadStream and pass the maximum number of bytes allowed because by default it only allows 512KB
                    // I used the value 5000000 which is about 50MB
                    using (var stream = file.OpenReadStream(50000000))
                    {
                        _fileStream = stream;
                        _selectedFileName = file.Name;
                    }

                    var customBrowserFile = new CustomBrowserFile() { File = file };

                    if (file.Size > MaxSize)
                    {
                        customBrowserFile.Status = FileStatus.Error;
                        customBrowserFile.Message = "This file is too large";
                    }
                    else if (!FileTypes.Contains(Path.GetExtension(file.Name)))
                    {
                        customBrowserFile.Status = FileStatus.Error;
                        customBrowserFile.Message = $"This file has the wrong extension. Only the files of type(s) {FileTypes} are allowed.";
                    }
                    else
                    {
                        customBrowserFile.Status = FileStatus.Loaded;
                        customBrowserFile.Message = "File selected";
                    }

                    Files.Add(customBrowserFile);
                }
            }
            catch (Exception)
            {
                msgBoxCapacityError?.Show();
                return;
            }

            if (Duplicates.Count > 0)
                msgBoxDuplicateWarning?.Show();

            isLoading = false;
            StateHasChanged();
        }

        async Task UploadOne(CustomBrowserFile file)
        {
            file.Status = FileStatus.Uploading;
            await InvokeAsync(StateHasChanged);

            try
            {
                var content = new MultipartFormDataContent();

                // Create an instance of ProgressiveStreamContent that we just created and we will pass the stream of the file for it
                // and the 40096 which are 40KB per packet and the third argument which as a callback for the OnProgress event (u, p) are u = Uploaded bytes and P is the percentage
                var streamContent = new ProgressiveStreamContent(_fileStream, 40096, (u, p) =>
                {
                    // Call StateHasChanged() to notify the component about this change to re-render the UI
                    StateHasChanged();
                });

                // Add the streamContent with the name to the FormContent variable
                content.Add(streamContent, "File");

                // Submit the request
                var response = await HttpService.PostAsync<ImagineDto>("fileUpload", streamContent);
                var test = response.Message;

                file.Status = FileStatus.Uploaded;
                file.Message = "File uploaded";

                filesUploaded++;
                mainProgress = (filesUploaded / fileCount) * 10;

                await CanSelect.InvokeAsync(true);
            }
            catch (Exception ex)
            {
                file.Status = FileStatus.Error;
                file.Message = ex.Message;
            }

            await InvokeAsync(StateHasChanged);
        }

        async Task UploadAll()
        {
            foreach (var file in Files)
            {
                if (file.Status != FileStatus.Error)
                    await UploadOne(file);
            }
        }

        public string[] GetCurrentFiles() => Files.Where(f => f.Status == FileStatus.Uploaded).Select(f => f.File.Name).ToArray();

        void RemoveOne(CustomBrowserFile file)
        {
            Files.Remove(file);
            StateHasChanged();
        }

        void RemoveAll()
        {
            Files.Clear();
            StateHasChanged();
        }

        void DeleteOne(CustomBrowserFile file)
        {
            File.Delete(Path.Combine(path, file.File.Name));
            RemoveOne(file);
            StateHasChanged();
        }

        Color GetColor(FileStatus status)
        {
            switch (status)
            {
                case FileStatus.Loaded: return Color.Info;
                case FileStatus.Uploading: return Color.Transparent;
                case FileStatus.Uploaded: return Color.Success;
                default: return Color.Error;
            }
        }

        string GetSizeText(long size)
        {
            string[] sizeLabels = { "B", "KB", "MB", "GB", "TB" };
            int order = 0;
            while (size >= 1024 && order < sizeLabels.Length - 1)
            {
                order++;
                size /= 1024;
            }

            return String.Format("{0:0.##} {1}", size, sizeLabels[order]);
        }

        bool IsSelectDisabled() => Files.Count >= MaxFiles;
        bool isUploadDisabled(CustomBrowserFile file) => file.Status == FileStatus.Error;
        bool ShowUploadAll() => Files.Count < 0;
    }
}
