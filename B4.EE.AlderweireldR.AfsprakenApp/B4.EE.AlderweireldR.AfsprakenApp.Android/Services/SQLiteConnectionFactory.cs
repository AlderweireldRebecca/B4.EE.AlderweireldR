using System;
using System.IO;
using Android.OS;
//using SQLite.Net;
//using SQLite.Net.Interop;
//using SQLite.Net.Platform.XamarinAndroid;
using Xamarin.Forms;

[assembly: Dependency(typeof(B4.EE.AlderweireldR.AfsprakenApp.Droid.Services.SQLiteConnectionFactory))]
namespace B4.EE.AlderweireldR.AfsprakenApp.Droid.Services
{
    internal class SQLiteConnectionFactory //: ISQLiteConnectionFactory
    {
        //public SQLiteConnection CreateConnection(string databaseFileName)
        //{
        //    string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        //    path = Path.Combine(path, databaseFileName);

        //    return new SQLiteConnection(
        //        new SQLitePlatformAndroid(),
        //        path,
        //        SQLiteOpenFlags.Create | SQLiteOpenFlags.ReadWrite,
        //        storeDateTimeAsTicks: false
        //        );
        //}
    }
}