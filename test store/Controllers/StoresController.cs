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

        //private readonly StoreDbContext _context;
        //public StoresController(StoreDbContext context)
        //{
        //    _context = context;
        //}

        //SqliteConnection con = new SqliteConnection("Data Source=C:\\Users\\User\\Desktop\\db.db");
        //SqliteConnection con = new SqliteConnection();
        ////[HttpGet]
        //public IActionResult Index()
        //{
        //    //var test = new Store() { Id = 99, Fullname = "test", Shortname = "TEST" };
        //    //ViewData["Store"] = test;
        //    //return View(test);


        //    //List<Store> storeList = new List<Store>();
        //    //List<Person> personList = new List<Person>();
        //    //con.ConnectionString = test_store.Properties.Resources.ConnectionString;

        //    //SQLitePCL.Batteries.Init();
        //    //SQLitePCL.raw.sqlite3_win32_set_directory(1, ApplicationData.Current.LocalFolder.Path);
        //    //SQLitePCL.raw.sqlite3_win32_set_directory(2, ApplicationData.Current.TemporaryFolder.Path);
        //    //try
        //    //{
        //    //    con.Open();
        //    //    SqliteCommand com = new SqliteCommand();
        //    //    com.Connection = con;
        //    //    com.CommandText = "select * from Store s join Person p on s.id = p.id";
        //    //    SqliteDataReader dr = com.ExecuteReader();
        //    //    while (dr.Read())
        //    //    {
        //    //        storeList.Add(new Store()
        //    //        {
        //    //            Id = Convert.ToInt32(dr["Id"]),
        //    //            Shortname = dr["shortname"].ToString(),
        //    //            Fullname = dr["fullname"].ToString(),
        //    //            IdPerson = Convert.ToInt32(dr["idPerson"])
        //    //        });
        //    //        personList.Add(new Person()
        //    //        {
        //    //            Id = Convert.ToInt32(dr["id"]), 
        //    //            Name = dr["name"].ToString(), 
        //    //            Birth = Convert.ToDateTime(dr["birth"])
        //    //        });
        //    //    }
        //    //    con.Close();
        //    //}
        //    //catch { }



        //    //var stores = _context.Store.ToList();
        //    //List<Store> storeList = new List<Store>();
        //    //foreach (var store in stores)
        //    //{
        //    //    var storeModelView = new Store()
        //    //    {
        //    //        Id = store.Id,
        //    //        Shortname = store.Shortname,
        //    //        Fullname = store.Fullname,
        //    //        IdPerson = store.IdPerson
        //    //    };
        //    //    storeList.Add(storeModelView);

        //    //}
        //    //return View(storeList);
        //}

        //public new IActionResult Index()
        //{
        //    mainModel mainModel = new mainModel();
        //    mainModel.Store = GetStore();
        //    mainModel.Person = GetPerson();
        //    return View(mainModel);
        //    //return View("/Views/Main/Index.cshtml");
        //}

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
            //com.CommandText = $"insert into Store (shortname, fullname, idPerson) values ( '"+newstore.Shortname+"', '"+ newstore.Fullname + "', '"+newstore.IdPerson +"' )" ;
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
            //com.CommandText = $"insert into Store (shortname, fullname, idPerson) values ( '"+newstore.Shortname+"', '"+ newstore.Fullname + "', '"+newstore.IdPerson +"' )" ;
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
