using System;
using System.IO;
using System.Threading.Tasks;
using TransversalLibrary.Standard;
using Xamarin.Essentials;

namespace Xamarin.Forms.Implementations
{
    /// <summary>
    /// Define la implementación de la librería Essentials para usar las capacidades de los dispositivos
    /// </summary>
    public static class EssentialsDevice
    {
        /// <summary>
        /// Captura una foto
        /// </summary>
        /// <returns>El Stream de la foto</returns>
        public static async Task<Response<Stream>> CapturePhotoAsync()
        {
            Response<Stream> response = new Response<Stream>();
            try
            {
                FileResult photo = await MediaPicker.CapturePhotoAsync();
                response.Data = await photo.OpenReadAsync();
            }
            catch (Exception ex)
            {
                response.Exception = ex;
            }
            return response;
        }

        /// <summary>
        /// Escoge la foto desde la galería
        /// </summary>
        /// <returns>El Stream de la foto</returns>
        public static async Task<Response<Stream>> PickPhotoAsync()
        {
            Response<Stream> response = new Response<Stream>();
            try
            {
                FileResult photo = await MediaPicker.PickPhotoAsync();
                response.Data = await photo.OpenReadAsync();
            }
            catch (Exception ex)
            {
                response.Exception = ex;
            }
            return response;
        }
    }
}