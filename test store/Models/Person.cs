using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace test_store.Models
{
    [Serializable]
    public class JsonResponseViewModel
    {
        public int ResponseCode { get; set; }

        public string ResponseMessage { get; set; } = string.Empty;
    }
    public class Person
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Birth { get; set; }
    }
}
