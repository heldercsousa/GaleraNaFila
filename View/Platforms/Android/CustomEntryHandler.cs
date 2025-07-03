using Microsoft.Maui.Handlers;
using Android.Views.InputMethods;
using Android.Text;
using AndroidX.AppCompat.Widget;

namespace MyKaraoke.View.Platforms.Android
{
    public class CustomEntryHandler : EntryHandler
    {
        protected override void ConnectHandler(AppCompatEditText platformView)
        {
            base.ConnectHandler(platformView);
            
            if (platformView != null)
            {
                // For�a suporte a caracteres Unicode independentemente do locale do sistema
                ConfigureInternationalInput(platformView);
            }
        }

        private void ConfigureInternationalInput(AppCompatEditText editText)
        {
            try
            {
                // Define o tipo de entrada como texto com suporte completo a Unicode
                editText.InputType = InputTypes.ClassText | 
                                   InputTypes.TextVariationNormal;

                // Adiciona filtros que permitem caracteres Unicode
                editText.SetFilters(new IInputFilter[] { 
                    new InputFilterLengthFilter(100),
                    new UnicodeInputFilter()
                });

                // Define configura��es adicionais para suporte a caracteres especiais
                editText.SetRawInputType(InputTypes.ClassText);
                editText.ImeOptions = ImeAction.Done;
                
                System.Diagnostics.Debug.WriteLine("Configura��o internacional aplicada ao Entry");
            }
            catch (System.Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Erro ao configurar Entry internacional: {ex.Message}");
            }
        }
    }
}