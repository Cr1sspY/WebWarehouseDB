using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace WebWarehouseDB.Models
{
    public partial class Warehouse
    {
        public long WarehouseId { get; set; }
        [Display(Name = "Дата поступления")]
        public DateTime SupplyDate { get; set; }

        [Display(Name = "Дата заказа")]
        public DateTime OrderDate { get; set; }

        [Display(Name = "Дата отправки")]
        public DateTime ShipmentDate { get; set; }

        [Display(Name = "Объём")]
        public int Volume { get; set; }

        [Display(Name = "Цена")]
        public long Price { get; set; }

        [Display(Name = "Способ доставки")]
        public string TypeOfDelivery { get; set; }

        [Display(Name = "Заказчик")]
        public long CustomerId { get; set; }

        [Display(Name = "Товар")]
        public long ProductId { get; set; }

        [Display(Name = "Сотрудник")]
        public long EmployeeId { get; set; }

        [Display(Name = "Поставщик")]
        public long ProviderId { get; set; }

        [Display(Name = "Заказчик")]
        public virtual Customer Customer { get; set; }

        [Display(Name = "Сотрудник")]
        public virtual Employee Employee { get; set; }

        [Display(Name = "Товар")]
        public virtual Product Product { get; set; }

        [Display(Name = "Поставщик")]
        public virtual Provider Provider { get; set; }
    }
}
