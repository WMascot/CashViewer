using CashViewer_backend.DAL.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace CashViewer_backend.DAL.Entities
{
    public class Shop : Entity
    {
        [StringLength(maximumLength: 50, MinimumLength = 4, ErrorMessage = "The length of the shop's name cant be less then 4 and more then 50")]
        [RegularExpression(@"^[a-zA-Zа-яА-Я]*")]
        public string Name { get; set; }
        public Type Type { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
    public enum Type
    {
        Product,
        Service,
        Online,
        Delivery
    }
}
