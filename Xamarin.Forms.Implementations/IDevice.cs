namespace Xamarin.Forms.Implementations
{
    /// <summary>
    /// Define el comportamiento de los dispositivos
    /// </summary>
    public interface IDevice
    {
        /// <summary>
        /// Establece el color de la barra de estado
        /// </summary>
        /// <param name="hexColor">El color hexadecimal de la barra de estado</param>
        void SetStatusBarColor(string hexColor);

        /// <summary>
        /// Obtiene la altura de la barra de estado
        /// </summary>
        /// <returns>La altura de la barra de estado</returns>
        int GetStatusBarHeight();

        /// <summary>
        /// Esconde el teclado
        /// </summary>
        void HideKeyboard();

        /// <summary>
        /// Minimiza la aplicación
        /// </summary>
        void MinimizeApp();

        /// <summary>
        /// Cierra la aplicación
        /// </summary>
        void CloseApp();
    }
}