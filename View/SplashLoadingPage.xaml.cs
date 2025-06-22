using Microsoft.Maui.Controls;
using System;
using System.Threading.Tasks;

namespace MyKaraoke.View
{
    public partial class SplashLoadingPage : ContentPage
    {
        public SplashLoadingPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            // Inicia o processo de carregamento automaticamente
            Task.Run(async () => await SimulateLoading());
        }

        public void UpdateStatus(string status, double progressPercentage)
        {
            MainThread.BeginInvokeOnMainThread(() => 
            {
                StatusLabel.Text = status;
                LoadingProgressBar.Progress = progressPercentage;
            });
        }

        public async Task SimulateLoading()
        {
            // Etapas de carregamento simuladas
            string[] loadingSteps = new string[] {
                "Configurando ambiente...",
                "Carregando recursos gr�ficos...",
                "Inicializando banco de dados...",
                "Carregando prefer�ncias do usu�rio...",
                "Verificando atualiza��es...",
                "Preparando interface...",
                "Finalizando..."
            };

            try
            {
                for (int i = 0; i < loadingSteps.Length; i++)
                {
                    // Atualiza status e barra de progresso
                    UpdateStatus(loadingSteps[i], (double)(i + 1) / loadingSteps.Length);
                    
                    // Simula o tempo de processamento
                    await Task.Delay(500);
                }

                // Ap�s carregamento completo, navega para a SplashPage
                await MainThread.InvokeOnMainThreadAsync(() =>
                {
                    // Use construtor direto j� que n�o h� depend�ncias no construtor
                    Application.Current.MainPage = new SplashPage();
                });
            }
            catch (Exception ex)
            {
                UpdateStatus($"Erro: {ex.Message}", 1.0);
                
                // Aguarda alguns segundos para mostrar o erro
                await Task.Delay(3000);
                
                // Fallback direto para TonguePage em caso de erro
                await MainThread.InvokeOnMainThreadAsync(() =>
                {
                    Application.Current.MainPage = new NavigationPage(new TonguePage());
                });
            }
        }

        // Impede o bot�o voltar durante o loading
        protected override bool OnBackButtonPressed()
        {
            return true; // Bloqueia o bot�o voltar
        }
    }
}