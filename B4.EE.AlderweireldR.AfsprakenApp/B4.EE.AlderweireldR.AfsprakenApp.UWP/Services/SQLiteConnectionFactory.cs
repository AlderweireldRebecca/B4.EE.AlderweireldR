//using B4.EE.AlderweireldR.AfsprakenApp.Services.Abstract;
//using SQLite.Net;
//using SQLite.Net.Interop;
//using SQLite.Net.Platform.WinRT;
using System.IO;
using Windows.Storage;
using Xamarin.Forms;

[assembly: Dependency(typeof(B4.EE.AlderweireldR.AfsprakenApp.UWP.Services.SQLiteConnectionFactory))]
namespace B4.EE.AlderweireldR.AfsprakenApp.UWP.Services
{
    internal class SQLiteConnectionFactory //: ISQLiteConnectionFactory
    {
        //public SQLiteConnection CreateConnection(string databaseFileName)
        //{
        //    string path = ApplicationData.Current.LocalFolder.Path;
        //    path = Path.Combine(path, databaseFileName);

        //    return new SQLiteConnection(
        //        new SQLitePlatformWinRT(),
        //        path,
        //        SQLiteOpenFlags.Create | SQLiteOpenFlags.ReadWrite,
        //        storeDateTimeAsTicks: false
        //        );
        //}
    }
}
