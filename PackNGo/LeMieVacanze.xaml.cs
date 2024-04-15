namespace PackNGo;

public partial class LeMieVacanze : ContentPage
{
	public LeMieVacanze()
	{
		InitializeComponent();

        buttonTornaIndietro_LeMieVacanze.Clicked += ButtonTornaIndietro_LeMieVacanze_Clicked;


	}

    private void ButtonTornaIndietro_LeMieVacanze_Clicked(object? sender, EventArgs e)
    {
        // Torno alla MainPage
        Navigation.PushAsync(new MainPage());
    }
}