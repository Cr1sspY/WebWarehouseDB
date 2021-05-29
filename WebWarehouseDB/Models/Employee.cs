using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace WebWarehouseDB.Models
{
    public partial class Employee
    {
        public Employee()
        {
            Warehouses = new HashSet<Warehouse>();
        }

        [Display(Name = "Код сотрудника")]
        public long EmployeeId { get; set; }

        [Display(Name = "ФИО")]
        public string FullName { get; set; }

        [Display(Name = "Возраст")]
        public string Age { get; set; }

        [Display(Name = "Пол")]
        public string Sex { get; set; }

        [Display(Name = "Адрес")]
        public string Address { get; set; }

        [Display(Name = "Телефон")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Паспортные данные")]
        public string PassportInformation { get; set; }

        [Display(Name = "Должность")]
        public long PositionId { get; set; }


        [Display(Name = "Должность")]
        public virtual Position Position { get; set; }
        public virtual ICollection<Warehouse> Warehouses { get; set; }
    }
}
