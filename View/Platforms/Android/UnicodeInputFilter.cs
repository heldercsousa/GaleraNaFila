using Android.Text;
using Java.Lang;

namespace MyKaraoke.View.Platforms.Android
{
    public class UnicodeInputFilter : Java.Lang.Object, IInputFilter
    {
        public ICharSequence? FilterFormatted(ICharSequence? source, int start, int end, 
            ISpanned? dest, int dstart, int dend)
        {
            if (source == null) return null;

            // Permite todos os caracteres Unicode incluindo acentuados
            // Esta implementa��o n�o filtra nada, permitindo entrada completa
            return null; // null significa "aceitar o input"
        }
    }
}