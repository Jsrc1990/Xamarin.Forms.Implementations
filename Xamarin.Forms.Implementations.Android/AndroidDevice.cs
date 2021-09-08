using Android.Content;
using Android.Views;
using Android.Views.InputMethods;
using Xamarin.Forms;
using Xamarin.Forms.Implementations.Android;
using Android1 = Android;

[assembly: Dependency(typeof(AndroidDevice))]
namespace Xamarin.Forms.Implementations.Android
{
    public class AndroidDevice
    {
        /// <summary>
        /// Establece el color de la barra de estado
        /// </summary>
        /// <param name="hexColor">El color hexadecimal de la barra de estado</param>
        public void SetStatusBarColor(string hexColor)
        {
            Android1.Graphics.Color currentColor;
            if (hexColor.Equals("#00FFFFFF"))
            {
                currentColor = Android1.Graphics.Color.Transparent;
                BaseActivity.Instance?.Window?.AddFlags(WindowManagerFlags.TranslucentStatus);
                BaseActivity.Instance?.Window?.AddFlags(WindowManagerFlags.TranslucentNavigation);
            }
            else
            {
                currentColor = Android1.Graphics.Color.ParseColor(hexColor);
                BaseActivity.Instance?.Window?.ClearFlags(WindowManagerFlags.TranslucentStatus);
                BaseActivity.Instance?.Window?.ClearFlags(WindowManagerFlags.TranslucentNavigation);
            }
            BaseActivity.Instance?.SetStatusBarColor(currentColor);
        }

        /// <summary>
        /// Obtiene la altura de la barra de estado
        /// </summary>
        /// <returns>La altura de la barra de estado</returns>
        public int GetStatusBarHeight()
        {
            int statusBarHeight = -1;
            int resourceId = BaseActivity.Instance.Resources.GetIdentifier("status_bar_height", "dimen", "android");
            if (resourceId > 0) statusBarHeight = BaseActivity.Instance.Resources.GetDimensionPixelSize(resourceId);
            return statusBarHeight;
        }

        /// <summary>
        /// Esconde el teclado
        /// </summary>
        public void HideKeyboard()
        {
            InputMethodManager inputMethodManager = BaseActivity.Instance?.GetSystemService(Context.InputMethodService) as InputMethodManager;
            if (inputMethodManager != null)
            {
                Android1.OS.IBinder token = BaseActivity.Instance?.CurrentFocus?.WindowToken;
                inputMethodManager.HideSoftInputFromWindow(token, HideSoftInputFlags.None);
                BaseActivity.Instance?.Window.DecorView.ClearFocus();
            }
        }

        /// <summary>
        /// Minimiza la aplicación
        /// </summary>
        public void MinimizeApp()
        {
            Intent main = new Intent(Intent.ActionMain);
            main?.AddCategory(Intent.CategoryHome);
            BaseActivity.Instance?.StartActivity(main);
        }

        /// <summary>
        /// Cierra la aplicación
        /// </summary>
        public void CloseApp()
        {
            BaseActivity.Instance?.FinishAffinity();
        }
    }
}