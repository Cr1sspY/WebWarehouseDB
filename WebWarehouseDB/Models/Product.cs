using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace WebWarehouseDB.Models
{
    public partial class Product
    {
        public Product()
        {
            CustomerConsumedProduct1s = new HashSet<Customer>();
            CustomerConsumedProduct2s = new HashSet<Customer>();
            CustomerConsumedProduct3s = new HashSet<Customer>();
            ProviderSuppliedProduct1s = new HashSet<Provider>();
            ProviderSuppliedProduct2s = new HashSet<Provider>();
            ProviderSuppliedProduct3s = new HashSet<Provider>();
            Warehouses = new HashSet<Warehouse>();
        }

        [Display(Name = "Код товара")]
        public long ProductId { get; set; }

        [Display(Name = "Производитель")]
        public string Manufacturer { get; set; }

        [Display(Name = "Наименование")]
        public string Name { get; set; }

        [Display(Name = "Условия хранения")]
        public string StorageConditions { get; set; }

        [Display(Name = "Упаковка")]
        public string Package { get; set; }

        [Display(Name = "Срок годности")]
        public DateTime ShelfLife { get; set; }

        [Display(Name = "Тип товара")]
        public long TypeId { get; set; }


        [Display(Name = "Тип товара")]
        public virtual ProductType Type { get; set; }
        public virtual ICollection<Customer> CustomerConsumedProduct1s { get; set; }
        public virtual ICollection<Customer> CustomerConsumedProduct2s { get; set; }
        public virtual ICollection<Customer> CustomerConsumedProduct3s { get; set; }
        public virtual ICollection<Provider> ProviderSuppliedProduct1s { get; set; }
        public virtual ICollection<Provider> ProviderSuppliedProduct2s { get; set; }
        public virtual ICollection<Provider> ProviderSuppliedProduct3s { get; set; }
        public virtual ICollection<Warehouse> Warehouses { get; set; }
    }
}
