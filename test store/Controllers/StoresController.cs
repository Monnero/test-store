using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using test_store.Models;
using Windows.Storage;

namespace test_store.Controllers
{
    public class StoresController :   MainController
    {
        SqliteConnection con = new SqliteConnection();

        [HttpGet]
        public IActionResult Add()
        {            
            return View();
        }
        [HttpPost]
        public IActionResult Add(Store addStoreRequest)
        {
            var newstore = new Store()
            {
                Shortname = addStoreRequest.Shortname,
                Fullname = addStoreRequest.Fullname,
                IdPerson = addStoreRequest.IdPerson
            };

            con.ConnectionString = Properties.Resources.ConnectionString;

            SQLitePCL.Batteries.Init();
            SQLitePCL.raw.sqlite3_win32_set_directory(1, ApplicationData.Current.LocalFolder.Path);
            SQLitePCL.raw.sqlite3_win32_set_directory(2, ApplicationData.Current.TemporaryFolder.Path);

            con.Open();
            SqliteCommand com = new SqliteCommand();
            com.Connection = con;
            com.CommandText = $"insert into Store (shortname, fullname, idPerson) values ('{newstore.Shortname}', '{ newstore.Fullname}', '{ newstore.IdPerson}' )" ;

            com.ExecuteNonQuery();
            
            con.Close();

            return Redirect("/Main/Index");
        }
        public IActionResult Delete()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Delete(Store addStoreRequest)
        {
            var newstore = new Store()
            {
                Id = addStoreRequest.Id
            };

            con.ConnectionString = Properties.Resources.ConnectionString;

            SQLitePCL.Batteries.Init();
            SQLitePCL.raw.sqlite3_win32_set_directory(1, ApplicationData.Current.LocalFolder.Path);
            SQLitePCL.raw.sqlite3_win32_set_directory(2, ApplicationData.Current.TemporaryFolder.Path);

            con.Open();
            SqliteCommand com = new SqliteCommand();
            com.Connection = con;
            com.CommandText = $"delete from Store where id = {newstore.Id}";

            com.ExecuteNonQuery();

            con.Close();

            return Redirect("/Main/Index");
        }
        public IActionResult Update()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Update(Store addStoreRequest)
        {
            var newstore = new Store()
            {
                Id = addStoreRequest.Id, 
                Shortname = addStoreRequest.Shortname,
                Fullname = addStoreRequest.Fullname,
                IdPerson = addStoreRequest.IdPerson
            };

            con.ConnectionString = Properties.Resources.ConnectionString;

            SQLitePCL.Batteries.Init();
            SQLitePCL.raw.sqlite3_win32_set_directory(1, ApplicationData.Current.LocalFolder.Path);
            SQLitePCL.raw.sqlite3_win32_set_directory(2, ApplicationData.Current.TemporaryFolder.Path);

            con.Open();
            SqliteCommand com = new SqliteCommand();
            com.Connection = con;
            com.CommandText = $"update Store set shortname = '{newstore.Shortname}', fullname = '{newstore.Fullname}', idPerson = '{newstore.IdPerson}'" +
                $" where id = {newstore.Id}";

            com.ExecuteNonQuery();

            con.Close();

            return Redirect("/Main/Index");
        }
       
    }
}
