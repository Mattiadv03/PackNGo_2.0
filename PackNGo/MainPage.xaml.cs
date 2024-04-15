namespace PackNGo
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();

            // Preparo l'evento di pressione della buttonCreaValigia
            buttonCreaVacanza_MainPage.Clicked += ButtonCreaVacanza_Clicked;

            // Preparo l'evento di pressione della buttonLeMiePrenotazioni
            buttonLeMieVacanze_MainPage.Clicked += ButtonLeMieVacanze_Clicked;
        }

        private void ButtonCreaVacanza_Clicked(object? sender, EventArgs e)
        {
            // Lo mando nella pagina di creazione della vacanza
            Navigation.PushAsync(new CreaVacanza());
        }

        private void ButtonLeMieVacanze_Clicked(object? sender, EventArgs e)
        {
            // Lo mando nella pagina di visualizzazione delle sue vacanze
            Navigation.PushAsync(new LeMieVacanze());
        }
    }

}
