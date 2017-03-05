using FormAssitControl.Storage.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.IO;
using Xamarin.Forms;
using FormAssitControl.iOS.Storage.Implementation;

[assembly:Dependency(typeof(SQliteIOS))]
namespace FormAssitControl.iOS.Storage.Implementation
{
    public class SQliteIOS : ISQlite
    {
        public SQliteIOS()
        {

        }
        public SQLiteConnection GetConnection()
        {
            var sqliteFileName = "TodoSQlite.db3";
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libraryPath = Path.Combine(documentsPath, "..", "Library"); // Library Folder
            var path = Path.Combine(libraryPath, sqliteFileName);
            //Criando a conexão
            var conn = new SQLite.SQLiteConnection(path);
            //Retornando a conexão com o Banco
            return conn;

        }
    }
}
