//using SQLite.Net;
//using SQLite.Net.Interop;
//using SQLite.Net.Platform.XamarinIOS;
using Xamarin.Forms;

[assembly: Dependency(typeof(B4.EE.AlderweireldR.AfsprakenApp.iOS.Services.SQLiteConnectionFactory))]
namespace B4.EE.AlderweireldR.AfsprakenApp.iOS.Services
{
    internal class SQLiteConnectionFactory //: ISQLiteConnectionFactory
    {
        //public SQLiteConnection CreateConnection(string databaseFileName)
        //{
        //    string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        //    path = Path.Combine(path, databaseFileName);

        //    return new SQLiteConnection(
        //        new SQLitePlatformIOS(),
        //        path,
        //        SQLiteOpenFlags.Create | SQLiteOpenFlags.ReadWrite,
        //        storeDateTimeAsTicks: false
        //        );
        //}
    }
}