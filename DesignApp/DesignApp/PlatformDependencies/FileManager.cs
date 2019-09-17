using System.Threading.Tasks;
using Xamarin.Forms;

namespace DesignApp.PlatformDependencies
{
    public interface IFileManager
    {
        byte[] ReadFile(string filePath);
        void SaveFile(string filename, byte[] bytes);
        void DeleteFile(string filePath);
        string GetExternalStoragePublicDirectory();
    }

    public class FileManager
    {
        public static async Task<byte[]> ReadFileAsync(string filePath)
        {
            return await Task.Run(() => DependencyService.Get<IFileManager>().ReadFile(filePath));
        }

        public static async Task SaveFileAsync(string filePath, byte[] bytes)
        {
            await Task.Run(() => DependencyService.Get<IFileManager>().SaveFile(filePath, bytes));
        }

        public static async Task DeleteFileAsync(string filePath)
        {
            await Task.Run(() => DependencyService.Get<IFileManager>().DeleteFile(filePath));
        }
        public static string GetExternalStoragePublicDirectory()
        {
            return DependencyService.Get<IFileManager>().GetExternalStoragePublicDirectory();
        }
        public static async Task<string> GetExternalStoragePublicDirectoryAsync()
        {
            return await Task.Run(() => DependencyService.Get<IFileManager>().GetExternalStoragePublicDirectory());
        }
    }
}
