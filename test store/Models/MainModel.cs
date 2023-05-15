using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace test_store.Models
{
    public class mainModel
    {
        public  IEnumerable<Store> Store { get; set; }
        public  IEnumerable<Person> Person { get; set; }
    }
}
