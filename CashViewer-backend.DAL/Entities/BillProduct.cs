using CashViewer_backend.DAL.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace CashViewer_backend.DAL.Entities
{
    public class BillProduct : Entity
    {
        public Product Product { get; set; }

        [Range(1, 100, ErrorMessage = "Quantity cant be less then 1 and more then 100")]
        public int Quantity { get; set; }
        [Range(1, 100, ErrorMessage = "Discount cant be less then 1 and more then 100")]
        public int? Discount { get; set; }
    }
}
