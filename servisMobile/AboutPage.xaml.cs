using Plugin.LocalNotification;

namespace servisMobile;

public partial class AboutPage : ContentPage
{
    public AboutPage()
    {
        InitializeComponent();
    }

    private void OnCounterClicked(object sender, EventArgs e)
    {
        DisplayAlert("Not working now", "We are still working for this feature", "OK");
        var request = new NotificationRequest
        {
            Title = "it isn't much but it's honest work",
            Schedule = new NotificationRequestSchedule
            {
                NotifyTime = DateTime.Now.AddSeconds(5)
            }
        };
        LocalNotificationCenter.Current.Show(request);
    }
}