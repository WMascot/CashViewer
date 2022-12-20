using CashViewer_backend.DAL.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace CashViewer_backend.DAL.Entities
{
    public class Product : Entity
    {
        [StringLength(maximumLength: 100, MinimumLength = 5, ErrorMessage = ("The length of product's name can't be less then 5 and more then 100"))]
        public string Name { get; set; }
        [RegularExpression(@"?!^0*$)(?!^0*\.0*$)^\d{1,5}(\.\d{1,3})?$")]
        public double Price { get; set; }
        public virtual Shop Shop { get; set; }
    }
}
