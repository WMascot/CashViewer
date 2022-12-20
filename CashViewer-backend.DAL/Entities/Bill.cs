using CashViewer_backend.DAL.Entities.Base;

namespace CashViewer_backend.DAL.Entities
{
    public class Bill : Entity
    {
        public ICollection<BillProduct> ProductList { get; set; }
        public DateOnly Date { get; set; }
        public double TotalPrice { get; set; }
    }
}
