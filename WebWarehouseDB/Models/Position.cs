using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace WebWarehouseDB.Models
{
    public partial class Position
    {
        public Position()
        {
            Employees = new HashSet<Employee>();
        }


        [Display(Name = "Код должности")]
        public long PositionId { get; set; }

        [Display(Name = "Наименование должности")]
        public string Name { get; set; }

        [Display(Name = "Оклад")]
        public long Salary { get; set; }

        [Display(Name = "Обязанности")]
        public string Duties { get; set; }

        [Display(Name = "Требования")]
        public string Requests { get; set; }


        public virtual ICollection<Employee> Employees { get; set; }
    }
}
