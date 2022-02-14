using System.Threading;
using System.Threading.Tasks;

namespace Xamarin.Forms.Implementations
{
    /// <summary>
    /// Reemplaza el recurso por este control en su contenedor
    /// </summary>
    public static class ReplacerCustomControl
    {
        public static async void Replace(View view, string resourceName)
        {
            //Crea un nuevo hilo
            await Task.Run(() =>
            {
                Thread.Sleep(0);
                //Se devuelve al hilo actual UI
                Device.BeginInvokeOnMainThread(() =>
                {
                    ReplaceInContentPage(view, resourceName);
                    ReplaceInFrame(view, resourceName);
                    ReplaceInLayoutOfView(view, resourceName);
                });
            });
        }

        /// <summary>
        /// Remplaza el recurso por este control en el ContentPage
        /// </summary>
        private static void ReplaceInContentPage(View view, string resourceName)
        {
            //Si el padre es ContentPage
            if (view?.Parent?.GetType()?.IsAssignableFrom(typeof(ContentPage)) == true)
            {
                ContentPage contentPage = view?.Parent as ContentPage;
                if (contentPage != null)
                {
                    contentPage.ClearValue(ContentPage.ContentProperty);
                    StackLayout grid = view?.Resources[resourceName] as StackLayout;
                    grid.Children.Add(view);
                    contentPage.Content = grid;
                }
                return;
            }
        }

        /// <summary>
        /// Remplaza el recurso por este control en el Frame
        /// </summary>
        private static void ReplaceInFrame(View view, string resourceName)
        {
            //Si el padre es Frame
            if (view?.Parent?.GetType()?.IsAssignableFrom(typeof(Frame)) == true)
            {
                Frame frame = view?.Parent as Frame;
                if (frame != null)
                {
                    frame.ClearValue(Frame.ContentProperty);
                    StackLayout grid = view?.Resources[resourceName] as StackLayout;
                    grid.Children.Add(view);
                    frame.Content = grid;
                }
                return;
            }
        }

        /// <summary>
        /// Remplaza el recurso por este control en el Grid o StackLayout
        /// </summary>
        private static void ReplaceInLayoutOfView(View view, string resourceName)
        {
            //Si el padre es Grid o StackLayout, o cualquier otro que herede de Layout<View>
            if (view?.Parent?.GetType()?.IsSubclassOf(typeof(Layout<View>)) == true)
            {
                Layout<View> stackPanel = view?.Parent as Layout<View>;
                if (stackPanel != null)
                {
                    int index = stackPanel?.Children?.IndexOf(view) ?? -1;
                    if (index > -1)
                    {
                        ContentView panel = view?.Resources[resourceName] as ContentView;
                        stackPanel.Children[index] = panel;
                        panel.Content = view;
                    }
                }
                return;
            }
        }
    }
}