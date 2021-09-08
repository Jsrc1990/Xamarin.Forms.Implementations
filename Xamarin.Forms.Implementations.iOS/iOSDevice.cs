using Foundation;
using System.Linq;
using UIKit;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Implementations.iOS;

[assembly: Dependency(typeof(iOSDevice))]
namespace Xamarin.Forms.Implementations.iOS
{
    /// <summary>
    /// Define el comportamiento de los dispositivos
    /// </summary>
    public class iOSDevice
    {
        /// <summary>
        /// Establece el color de la barra de estado
        /// </summary>
        /// <param name="hexColor">El color hexadecimal de la barra de estado</param>
        public void SetStatusBarColor(string hexColor)
        {
            if ((Application.Current?.MainPage as NavigationPage)?.CurrentPage != null)
            {
                UIView bar = GetStatusBar();
                bar.BackgroundColor = ColorConverters.FromHex(hexColor).ToPlatformColor();
            }
        }

        /// <summary>
        /// Obtiene la barra de estado
        /// </summary>
        /// <returns>La barra de estado</returns>
        private UIView GetStatusBar()
        {
            UIView statusBar;
            if (UIDevice.CurrentDevice.CheckSystemVersion(13, 0))
            {
                int tag = 123; // Customize this tag as you want so we don't create it over and over
                UIWindow window = UIApplication.SharedApplication.Windows.FirstOrDefault();
                statusBar = window.ViewWithTag(tag);
                if (statusBar == null)
                {
                    statusBar = new UIView(UIApplication.SharedApplication.StatusBarFrame);
                    statusBar.Tag = tag;
                    window.AddSubview(statusBar);
                }
            }
            else
            {
                statusBar = UIApplication.SharedApplication.ValueForKey(new NSString("statusBar")) as UIView;
            }
            return statusBar;
        }

        /// <summary>
        /// Obtiene la altura de la barra de estado
        /// </summary>
        /// <returns>La altura de la barra de estado</returns>
        public int GetStatusBarHeight()
        {
            return (int)UIApplication.SharedApplication.StatusBarFrame.Height;
        }

        /// <summary>
        /// Esconde el teclado
        /// </summary>
        public void HideKeyboard()
        {
        }

        /// <summary>
        /// Minimiza la aplicación
        /// </summary>
        public void MinimizeApp()
        {
        }

        /// <summary>
        /// Cierra la aplicación
        /// </summary>
        public void CloseApp()
        {
        }
    }
}
