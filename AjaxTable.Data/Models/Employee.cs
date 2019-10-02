using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AjaxTable.Data.Models
{
    public class Employee
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [StringLength(255)]
        [Column(TypeName = "nvarchar")]
        [Required]
        public string Name { get; set; }
        public double Salary { get; set; }
        [Required]
        public DateTime CreateDate { get; set; }
        public bool Status { get; set; }
    }
}
