namespace servisMobile;

using Plugin.LocalNotification;
using servisMobile.models;
using System.Net;

public partial class ListPage : ContentPage
{
	public ListPage()
	{
		InitializeComponent();
	}

    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var slist = (Cars)BindingContext;
        slist.FixDate = DateTime.UtcNow;
        await App.Database.SaveCarsAsync(slist);
        await Navigation.PopAsync();

        var request = new NotificationRequest
        {
            NotificationId = 0, // Unique ID for the notification
            Title = "Car was added succesfully",
            Description = "Masina inregistrata cu success",
            Schedule = new NotificationRequestSchedule
            {
                // Set the scheduled time for the notification
                NotifyTime = DateTime.Now.AddSeconds(5) // Schedules the notification 5 seconds from now
            }
        };
        await LocalNotificationCenter.Current.Show(request);

    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var slist = (Cars)BindingContext;
        await App.Database.DeleteCarsAsync(slist);
        await Navigation.PopAsync();
    }

    async void OnChooseButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MecanicPage((Cars)
       this.BindingContext)
        {
            BindingContext = new Mecanic()
        });;

    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        var shopl = (Cars)BindingContext;

        listView.ItemsSource = await App.Database.GetListMecanicsAsync(shopl.ID);
    }

}