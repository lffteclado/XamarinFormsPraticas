using FormAssitControl.Model.Entities;
using FormAssitControl.Storage.Interfaces;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FormAssitControl.Storage
{
    public interface IKeyObject
    {
      string Key { get; set; }
    }

    public class DataBaseManager
    {
        SQLiteConnection dataBase;

        public DataBaseManager()
        {
            dataBase = DependencyService.Get<ISQlite>().GetConnection();
            dataBase.CreateTable<Student>();
        }

        public void SaveValue<T>(T value) where T : IKeyObject, new()
        {
            var all = (from entry in dataBase.Table<T>().AsEnumerable<T>()
                       where entry.Key == value.Key
                       select entry).ToList();
            if (all.Count == 0)
                dataBase.Insert(value);
            else
                dataBase.Update(value);
        }

        public void DeleteValue<T>(T value) where T : IKeyObject, new()
        {
            var all = (from entry in dataBase.Table<T>().AsEnumerable<T>()
                       where entry.Key == value.Key
                       select entry).ToList();
            if (all.Count == 1)
                dataBase.Delete(value);
            else
                throw new Exception("O banco de Dados não contem registro com a informação especificada!");
        }

        public List<TSource> GetAllItem<TSource>() where TSource : IKeyObject, new()
        {
            return dataBase.Table<TSource>().AsEnumerable<TSource>().ToList();
        }

        public TSource GetItem<TSource>(String key) where TSource : IKeyObject, new()
        {
            var result = (from entry in dataBase.Table<TSource>().AsEnumerable<TSource>()
                          where entry.Key == key
                          select entry).FirstOrDefault();
            return result;
        }
    }
}
