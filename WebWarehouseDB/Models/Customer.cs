using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace WebWarehouseDB.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Warehouses = new HashSet<Warehouse>();
        }


        [Display(Name = "Код заказчика")]
        public long CustomerId { get; set; }

        [Display(Name = "Наименование")]
        public string Name { get; set; }

        [Display(Name = "Адрес")]
        public string Address { get; set; }

        [Display(Name = "Телефон")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Потребляемый товар 1")]
        public long ConsumedProduct1Id { get; set; }

        [Display(Name = "Потребляемый товар 2")]
        public long ConsumedProduct2Id { get; set; }

        [Display(Name = "Потребляемый товар 3")]
        public long ConsumedProduct3Id { get; set; }


        [Display(Name = "Потребляемый товар 1")]
        public virtual Product ConsumedProduct1 { get; set; }

        [Display(Name = "Потребляемый товар 2")]
        public virtual Product ConsumedProduct2 { get; set; }

        [Display(Name = "Потребляемый товар 3")]
        public virtual Product ConsumedProduct3 { get; set; }

        public virtual ICollection<Warehouse> Warehouses { get; set; }
    }
}
