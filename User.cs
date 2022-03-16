using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CRUD2.Data
{
    public class User
    {
        // Id er key i databasen
        [Key]
        // Id felt
        public int Id { get; set; }
        // Name felt
        public string? Name { get; set; }
        // Address felt
        public string? Address { get; set; }
    }
}
