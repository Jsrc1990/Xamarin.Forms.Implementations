namespace Xamarin.Forms.Implementations
{
    /// <summary>
    /// Define la implementación de los dispositivos
    /// </summary>
    public sealed class XamarinDevice : IDevice
    {
        #region SINGLETON

        /// <summary>
        /// https://www.c-sharpcorner.com/UploadFile/8911c4/singleton-design-pattern-in-C-Sharp/
        /// </summary>
        public XamarinDevice()
        {
        }
        private static readonly object padlock = new object();
        private static XamarinDevice instance = null;
        public static XamarinDevice Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new XamarinDevice();
                    }
                    return instance;
                }
            }
        }

        #endregion

        /// <summary>
        /// Establece el color de la barra de estado
        /// </summary>
        /// <param name="hexColor">El color hexadecimal de la barra de estado</param>
        public void SetStatusBarColor(string hexColor)
        {
            IDevice iDevice = DependencyService.Get<IDevice>();
            iDevice?.SetStatusBarColor(hexColor);
        }

        /// <summary>
        /// Obtiene la altura de la barra de estado
        /// </summary>
        /// <returns>La altura de la barra de estado</returns>
        public int GetStatusBarHeight()
        {
            IDevice iDevice = DependencyService.Get<IDevice>();
            return iDevice.GetStatusBarHeight();
        }

        /// <summary>
        /// Esconde el teclado
        /// </summary>
        public void HideKeyboard()
        {
            IDevice iDevice = DependencyService.Get<IDevice>();
            iDevice?.HideKeyboard();
        }

        /// <summary>
        /// Minimiza la aplicación
        /// </summary>
        public void MinimizeApp()
        {
            IDevice iDevice = DependencyService.Get<IDevice>();
            iDevice?.MinimizeApp();
        }

        /// <summary>
        /// Cierra la aplicación
        /// </summary>
        public void CloseApp()
        {
            IDevice iDevice = DependencyService.Get<IDevice>();
            iDevice?.CloseApp();
        }
    }
}