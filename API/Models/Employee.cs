using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace API.Models
{
    [Table("Tb_M_Employee")]
    public class Employee
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }

        [DataType(DataType.Date)]
        [Column(TypeName = "DateTime2")]
        public DateTime? BirthDate { get; set; }
        public string Address { get; set; }

        public string Email { get; set; }
        public string Phone { get; set; }

        public virtual Account Account { get; set; }
    }
}