using Android.Content;
using DesignApp.Droid.DependencyImplementations;
using DesignApp.PlatformDependencies;
using System;
using System.IO;

[assembly: Xamarin.Forms.Dependency(typeof(FileManagerAndroid))]
namespace DesignApp.Droid.DependencyImplementations
{

    public class FileManagerAndroid : IFileManager
    {
        public string GetExternalStoragePublicDirectory()
        {
            return Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryDcim).AbsolutePath;
        }

        public byte[] ReadFile(string filePath)
        {
            return File.ReadAllBytes(filePath);
        }

        public void DeleteFile(string filePath)
        {
            File.Delete(filePath);
        }


        public void SaveFile(string filePath, byte[] bytes)
        {

            File.WriteAllBytes(filePath, bytes);
            var mediaScanIntent = new Intent(Intent.ActionMediaScannerScanFile);
            mediaScanIntent.SetData(Android.Net.Uri.FromFile(new Java.IO.File(filePath)));
            Android.App.Application.Context.SendBroadcast(mediaScanIntent);

        }

    }

}