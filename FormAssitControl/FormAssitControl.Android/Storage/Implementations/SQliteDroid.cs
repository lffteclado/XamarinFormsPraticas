using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using FormAssitControl.Storage.Interfaces;
using SQLite;
using System.IO;
using FormAssitControl.Droid.Storage.Implementations;

[assembly: Dependency(typeof(SQliteDroid))]
namespace FormAssitControl.Droid.Storage.Implementations
{
    public class SQliteDroid : ISQlite
    {
        public SQliteDroid()
        {

        }

        public SQLiteConnection GetConnection()
        {
            SQLitePCL.Batteries.Init();
            var sqliteFileName = "TodoSQlite.db3";
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, sqliteFileName);
            //Criando a Conexão com o Banco
            var conn = new SQLite.SQLiteConnection(path);
            //Retornando a Conexão com o banco
            return conn;
        }
    }
}