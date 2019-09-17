using System;
using Xamarin.Forms;

namespace DesignApp.Camera
{
    public partial class CameraView : ContentPage
    {
        public CameraView()
        {
            InitializeComponent();
            CameraPreview.PictureFinished += OnPictureFinished;
        }

        void OnCameraClicked(object sender, EventArgs e)
        {
            CameraPreview.CameraClick.Execute(null);
        }

        private void OnPictureFinished()
        {
            DisplayAlert("Confirm", "Picture Taken", "", "Ok");
        }

    }
}