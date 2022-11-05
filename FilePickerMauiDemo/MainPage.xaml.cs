namespace FilePickerMauiDemo;

public partial class MainPage : ContentPage
{
    private readonly IFilePicker _filePicker;
    public MainPage(IFilePicker filePicker)
    {
        InitializeComponent();

        _filePicker = filePicker;
    }

    private async void PickPhoto_Clicked(object sender, EventArgs e)
    {
        FileResult result = await _filePicker.PickAsync(new PickOptions
        {
            PickerTitle = "Pick a Photo",
            FileTypes = FilePickerFileType.Images
        });

        if (result == null) return;

        FileName.Text = result.FileName;
    }

    private async void PickFile_Clicked(object sender, EventArgs e)
    {
        var customFileTypes = new FilePickerFileType(new Dictionary<DevicePlatform, IEnumerable<string>>
        {
            {
                DevicePlatform.iOS, new[]
                {

                    "com.microsoft.word.doc",
                    "org.openxmlformats.wordprocessingml.document"
                }
            },
            {
                DevicePlatform.Android, new[]
                {
                    "application/msword",
                    "application/vnd.openxmlformats-officedocument.wordprocessingml.document"
                }
            },
            {
                DevicePlatform.WinUI, new[]
                {
                    "doc","docx",
                }
            },
        });


        FileResult result = await _filePicker.PickAsync(new PickOptions
        {
            PickerTitle = "Pick a File",
            FileTypes = customFileTypes
        });

        if (result == null) return;

        FileName.Text = result.FileName;
    }
}

