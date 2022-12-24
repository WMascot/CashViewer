namespace CashViewer_backend.BAL.DTO
{
    public class ShopDetailsDTO : ShopDTO
    {
        public ICollection<ProductShopDTO> Products { get; set; }
    }
}
