using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test_store.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using test_store.Models;
using Windows.Storage;

namespace test_store.Controllers
{
    public class MainController : Controller
    {
        public IActionResult Index()
        {
            mainModel mainModel = new mainModel();
            mainModel.Store = GetStore();
            mainModel.Person = GetPerson();
            return View(mainModel);
        }

        SqliteConnection con = new SqliteConnection();

        [HttpGet]
        protected List<Store> GetStore()
        {
            List<Store> storeList = new List<Store>();
            con.ConnectionString = test_store.Properties.Resources.ConnectionString;

            SQLitePCL.Batteries.Init();
            SQLitePCL.raw.sqlite3_win32_set_directory(1, ApplicationData.Current.LocalFolder.Path);
            SQLitePCL.raw.sqlite3_win32_set_directory(2, ApplicationData.Current.TemporaryFolder.Path);
            
            con.Open();
            SqliteCommand com = new SqliteCommand();
            com.Connection = con;
            com.CommandText = "select * from Store";
            SqliteDataReader dr = com.ExecuteReader();
            while (dr.Read())
            {
                storeList.Add(new Store()
                {
                    Id = Convert.ToInt32(dr["Id"]),
                    Shortname = dr["shortname"].ToString(),
                    Fullname = dr["fullname"].ToString(),
                    IdPerson = Convert.ToInt32(dr["idPerson"])
                });
            }
            con.Close();
            
            return storeList;
        }
        [HttpGet]
        protected List<Person> GetPerson()
        {
            List<Person> personList = new List<Person>();
            con.ConnectionString = Properties.Resources.ConnectionString;

            SQLitePCL.Batteries.Init();
            SQLitePCL.raw.sqlite3_win32_set_directory(1, ApplicationData.Current.LocalFolder.Path);
            SQLitePCL.raw.sqlite3_win32_set_directory(2, ApplicationData.Current.TemporaryFolder.Path);
            
            con.Open();
            SqliteCommand com = new SqliteCommand
            {
                Connection = con,
                CommandText = "select * from Person"
            };
            SqliteDataReader dr = com.ExecuteReader();
            while (dr.Read())
            {
                personList.Add(new Person()
                {
                    Id = Convert.ToInt32(dr["id"]),
                    Name = dr["name"].ToString(),
                    Birth = Convert.ToDateTime(dr["birth"]).Date
                });
            }
            con.Close();
            
            return personList;

        }
       
    }
}
