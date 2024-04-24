namespace SimpleTodo;

public partial class TodoItemPage : ContentPage
{
    Models.TodoItemDatabase database;
    public Models.TodoItem Item { get; set; }

    public TodoItemPage(Models.TodoItemDatabase todoItemDatabase)
    {
        InitializeComponent();
        database = todoItemDatabase;

        Item = new Models.TodoItem();

        this.BindingContext = Item;
    }

    async void OnSaveClicked(object sender, EventArgs e)
    {
        Item = (Models.TodoItem)this.BindingContext;
        await database.SaveItemAsync(Item);
        await Shell.Current.GoToAsync("..");
    }

    async void OnDeleteClicked(object sender, EventArgs e)
    {
        Item = (Models.TodoItem)this.BindingContext;
        await database.DeleteItemAsync(Item);
        await Shell.Current.GoToAsync("..");
    }


    async void OnCancelClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }

    async void OnCameraClicked(object sender, EventArgs e)
    {
        if (MediaPicker.Default.IsCaptureSupported)
        {
            //TAKE PHOTO OR CAPTURE PHOTO
            FileResult myPhoto = await MediaPicker.Default.CapturePhotoAsync();

            //LOAD PHOTO
            //FileResult myPhoto = await MediaPicker.Default.PickPhotoAsync();
            if (myPhoto != null)
            {
                //save the image captured in the application.
                string localFilePath = Path.Combine(FileSystem.CacheDirectory, myPhoto.FileName);
                using Stream sourceStream = await myPhoto.OpenReadAsync();
                using FileStream localFileStream = File.OpenWrite(localFilePath);
                await sourceStream.CopyToAsync(localFileStream);
                capturedImage.Source = ImageSource.FromFile(localFilePath); 
                await Shell.Current.DisplayAlert("OOPS", localFileStream.Name, "Ok");
            }


        }

    }
}