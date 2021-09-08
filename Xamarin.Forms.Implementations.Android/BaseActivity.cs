using Android.OS;

namespace Xamarin.Forms.Implementations.Android
{
    /// <summary>
    /// Define la clase base de la cual heredan las actividades
    /// </summary>
    public class BaseActivity : Platform.Android.FormsAppCompatActivity
    {
        #region "INICIO"

        /// <summary>
        /// Esto es para Forms.Context que ya está obsoleto
        /// </summary>
        public static BaseActivity Instance { get; private set; }

        /// <summary>
        /// Inicializa las propiedades de esta clase
        /// </summary>
        /// <remarks>
        /// Se produce cuando inicia esta clase
        /// </remarks>
        public BaseActivity()
        {
            //Establece esta instancia a una propiedad compartida (estática), Esto es para Forms.Context que ya está obsoleto
            Instance = this;
        }

        /// <summary>
        /// Se produce cuando se crea una instancia de esta clase
        /// </summary>
        /// <param name="savedInstanceState">El estado de la instancia almacenada</param>
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            //*********************** CAMARA

            //Esto es necesario para la cámara, NO quitar
            //https://forums.xamarin.com/discussion/97273/launch-camera-activity-with-saving-file-in-external-storage-crashes-the-app
            StrictMode.VmPolicy.Builder Builder = new StrictMode.VmPolicy.Builder();
            StrictMode.SetVmPolicy(Builder.Build());

            base.OnCreate(savedInstanceState);
            //RadioButton
            Forms.SetFlags(new string[] { "RadioButton_Experimental", "Brush_Experimental", "Shapes_Experimental" });
            Essentials.Platform.Init(this, savedInstanceState);
            Forms.Init(this, savedInstanceState);

            //OxyPlot.Xamarin.Forms.Platform.Android.PlotViewRenderer.Init();
            //Google Maps
            FormsMaps.Init(this, savedInstanceState);
            //Xamarin.FormsGoogleMaps.Init(this, savedInstanceState); // initialize for Xamarin.Forms.GoogleMaps
            //Cambia el color de la barra de estado (Reloj, batería, señal, etc.)
            //Color currentColor = Color.ParseColor("#14AA61");
            //Window.SetStatusBarColor(currentColor);
        }

        #endregion
    }
}