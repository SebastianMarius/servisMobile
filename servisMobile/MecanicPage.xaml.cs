using servisMobile.models;

namespace servisMobile;

public partial class MecanicPage : ContentPage
{
    Cars car1;
    public MecanicPage(Cars cars)
    {
        InitializeComponent();
        car1 = cars;

    }

    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var mecanic = (Mecanic)BindingContext;
        await App.Database.SaveMecanictAsync(mecanic);
        listView.ItemsSource = await App.Database.GetMecanicAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var mecanic = (Mecanic)BindingContext;
        await App.Database.DeleteProductAsync(mecanic);
        listView.ItemsSource = await App.Database.GetMecanicAsync();
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.Database.GetMecanicAsync();
    }

    async void OnAddButtonClicked(object sender, EventArgs e)
    {
        Mecanic m;
        if (listView.SelectedItem != null)
        {
            m = listView.SelectedItem as Mecanic;
            var lp = new ListMecanics()
            {
                CarsID = car1.ID,
                MecanicID = m.ID
            };
            await App.Database.SaveListMecanicsAsync(lp);
            m.ListMecanics = new List<ListMecanics> { lp };
            await Navigation.PopAsync();
        }

    }
}