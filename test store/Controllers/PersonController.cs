using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Data.Sqlite;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test_store.Models;
using Windows.ApplicationModel.Contacts;
using Windows.Storage;

namespace test_store.Controllers
{
    public class PersonController : Controller
    {
        public IActionResult Index()
        {            
            return View();
        }
        SqliteConnection con = new SqliteConnection();
        //List<Person> personList = new List<Person>();

        //[HttpGet]
        //protected List<Person> GetPersons(int id)
        //{

        //    var newperson = new Person()
        //    {
        //        Id = id
        //    };

        //    con.ConnectionString = Properties.Resources.ConnectionString;

        //    SQLitePCL.Batteries.Init();
        //    SQLitePCL.raw.sqlite3_win32_set_directory(1, ApplicationData.Current.LocalFolder.Path);
        //    SQLitePCL.raw.sqlite3_win32_set_directory(2, ApplicationData.Current.TemporaryFolder.Path);

        //    con.Open();
        //    SqliteCommand com = new SqliteCommand
        //    {
        //        Connection = con,
        //        CommandText = $"select * from Person where id = {newperson.Id}"
        //    };

        //    SqliteDataReader dr = com.ExecuteReader();

        //    while (dr.Read())
        //    {
        //        personList.Add(new Person()
        //        {
        //            Id = Convert.ToInt32(dr["id"]),
        //            Name = dr["name"].ToString(),
        //            Birth = Convert.ToDateTime(dr["birth"]).Date
        //        });
        //    }
        //    con.Close();

        //    return personList;

        //}
        //[HttpPost]
        //public PartialViewResult Details(int personId)
        //{
        //    mainModel mainModel = new mainModel();

        //    mainModel.Person = GetPersons(2);

        //    return PartialView(mainModel.Person);
        //}
        //public IActionResult Test()
        //{
        //    Person person = new Person()
        //    {
        //        Id = 5,
        //        Name = "test",
        //        Birth = DateTime.Now
        //    };
        //    return View(person);
        //}
        //public PartialViewResult GetDetails()
        //{
        //    personList = GetPersons(1);
        //    return new PartialViewResult
        //    {
        //        ViewName = "_Details",
        //        ViewData = new ViewDataDictionary<List<Person>>(ViewData, personList)
        //    };
        //}
        //[HttpPost]
        //public ActionResult PeopleSearch(int id)
        //{
        //    var personList = GetPersons(id);
        //    return PartialView(personList);
        //}
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Person addPersonRequest)
        {
            var newperson = new Person()
            {
                Name = addPersonRequest.Name,
                Birth = addPersonRequest.Birth
            };

            con.ConnectionString = Properties.Resources.ConnectionString;

            SQLitePCL.Batteries.Init();
            SQLitePCL.raw.sqlite3_win32_set_directory(1, ApplicationData.Current.LocalFolder.Path);
            SQLitePCL.raw.sqlite3_win32_set_directory(2, ApplicationData.Current.TemporaryFolder.Path);

            con.Open();
            SqliteCommand com = new SqliteCommand();
            com.Connection = con;
            com.CommandText = $"insert into Person (name, birth) values ('{newperson.Name}', '{ newperson.Birth}')";

            com.ExecuteNonQuery();

            con.Close();

            return Redirect("/Main/Index");
        }
        public IActionResult Delete()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Delete(Person addPersonRequest)
        {
            var newperson = new Person()
            {
                Id = addPersonRequest.Id
            };

            con.ConnectionString = Properties.Resources.ConnectionString;

            SQLitePCL.Batteries.Init();
            SQLitePCL.raw.sqlite3_win32_set_directory(1, ApplicationData.Current.LocalFolder.Path);
            SQLitePCL.raw.sqlite3_win32_set_directory(2, ApplicationData.Current.TemporaryFolder.Path);

            con.Open();
            SqliteCommand com = new SqliteCommand();
            com.Connection = con;
            com.CommandText = $"delete from Person where id = {newperson.Id}";

            com.ExecuteNonQuery();

            con.Close();

            return Redirect("/Main/Index");
        }
        public IActionResult Update()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Update(Person addPersonRequest)
        {
            var newperson = new Person()
            {
                Id = addPersonRequest.Id,
                Name = addPersonRequest.Name,
                Birth = addPersonRequest.Birth
            };

            con.ConnectionString = Properties.Resources.ConnectionString;

            SQLitePCL.Batteries.Init();
            SQLitePCL.raw.sqlite3_win32_set_directory(1, ApplicationData.Current.LocalFolder.Path);
            SQLitePCL.raw.sqlite3_win32_set_directory(2, ApplicationData.Current.TemporaryFolder.Path);

            con.Open();
            SqliteCommand com = new SqliteCommand();
            com.Connection = con;
            com.CommandText = $"update Person set name = '{newperson.Name}', birth = '{newperson.Birth}'" +
                $" where id = {newperson.Id}";

            com.ExecuteNonQuery();

            con.Close();

            return Redirect("/Main/Index");
        }
    }
}
