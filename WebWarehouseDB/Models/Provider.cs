using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace WebWarehouseDB.Models
{
    public partial class Provider
    {
        public Provider()
        {
            Warehouses = new HashSet<Warehouse>();
        }

        [Display(Name = "Код поставщика")]
        public long ProviderId { get; set; }

        [Display(Name = "Наименование")]
        public string Name { get; set; }

        [Display(Name = "Адрес")]
        public string Address { get; set; }

        [Display(Name = "Телефон")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Поставляемый товар 1")]
        public long SuppliedProduct1Id { get; set; }

        [Display(Name = "Поставляемый товар 2")]
        public long SuppliedProduct2Id { get; set; }

        [Display(Name = "Поставляемый товар 3")]
        public long SuppliedProduct3Id { get; set; }


        [Display(Name = "Поставляемый товар 1")]
        public virtual Product SuppliedProduct1 { get; set; }

        [Display(Name = "Поставляемый товар 2")]
        public virtual Product SuppliedProduct2 { get; set; }

        [Display(Name = "Поставляемый товар 3")]
        public virtual Product SuppliedProduct3 { get; set; }
        public virtual ICollection<Warehouse> Warehouses { get; set; }
    }
}
