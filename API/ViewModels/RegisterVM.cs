using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class RegisterVM
    {
        public int Id { get; set; }
        public string EmployeeName { get; set; }
  
        [DataType(DataType.Date)]
        [Column(TypeName = "DateTime2")]
        public DateTime? BirthDate { get; set; }
        public string Address { get; set; }

        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
    }
}