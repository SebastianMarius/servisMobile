namespace servisMobile;
using System;
using servisMobile.Data;
using System.IO;

public partial class App : Application
{
	static CarsDatabase database;
	public static CarsDatabase Database
    {
        get
        {
            if (database == null)
            {
                database = new
               CarsDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.
               LocalApplicationData), "CarsList.db3"));
            }
            return database;
        }
    }
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}
}
