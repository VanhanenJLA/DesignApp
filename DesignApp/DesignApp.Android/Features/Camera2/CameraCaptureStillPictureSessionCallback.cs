using Android.Hardware.Camera2;
using System;

namespace DesignApp.Droid.Camera2
{
    public class CameraCaptureStillPictureSessionCallback : CameraCaptureSession.CaptureCallback
    {
        public Action<CameraCaptureSession> OnCaptureCompletedAction;

        public override void OnCaptureCompleted(CameraCaptureSession session, CaptureRequest request, TotalCaptureResult result)
        {
            OnCaptureCompletedAction?.Invoke(session);
        }
    }
}
