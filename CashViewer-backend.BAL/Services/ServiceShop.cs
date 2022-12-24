using CashViewer_backend.DAL.Entities;
using CashViewer_backend.DAL.Interfaces;
using CashViewer_backend.BAL.DTO;

namespace CashViewer_backend.BAL.Services
{
    public class ServiceShop
    {
        private readonly IRepository<Shop> _shopsRepository;
        private readonly IRepository<ShopType> _shopTypesRepository;
        public ServiceShop(IRepository<Shop> shopsRepository, IRepository<ShopType> shopTypesRepository)
        {
            _shopsRepository = shopsRepository;
            _shopTypesRepository = shopTypesRepository;
        }
        public IQueryable<ShopDTO> GetAllShops() => _shopsRepository.Items.Select(x => ShopToDTO(x));
        public ShopDetailsDTO GetShopDetails(int id)
        {
            var shop = _shopsRepository.Get(id);
            if (shop == null) throw new ArgumentNullException(nameof(shop));
            ShopDetailsDTO dto = ShopDetailsToDTO(shop);
            return dto;
        }
        public void AddShop(Shop shop) => _shopsRepository.Add(shop);
        public void RemoveShopById(int id) => _shopsRepository.Remove(id);
        public void UpdateShop(Shop shop) => _shopsRepository.Update(shop);
        public ShopDTO SearchShop(string name, string? type)
        {
            if (type != null && type != "")
            {
                var shop = _shopsRepository.Items.FirstOrDefault(x => x.Name.Contains(name) && x.Type.Name == type);
                if (shop == null) throw new ArgumentNullException(nameof(shop));
                ShopDTO dto = ShopToDTO(shop);
                return dto;
            }
            else
            {
                var shop = _shopsRepository.Items.FirstOrDefault(x => x.Name.Contains(name));
                if (shop == null) throw new ArgumentNullException(nameof(shop));
                ShopDTO dto = ShopToDTO(shop);
                return dto;
            }
        }
        public IQueryable<ShopType> GetAllTypes() => _shopTypesRepository.Items;
        public void AddType(ShopType type) => _shopTypesRepository.Add(type);
        public void RemoveTypeById(int id) => _shopTypesRepository.Remove(id);
        private static ShopDTO ShopToDTO(Shop shop) => new ShopDTO
        {
            Id = shop.Id,
            Name = shop.Name,
            Type = shop.Type.Name
        };
        private static ShopDetailsDTO ShopDetailsToDTO(Shop shop) => new ShopDetailsDTO
        {
            Id = shop.Id,
            Name = shop.Name,
            Type = shop.Type.Name,
            Products = shop.Products.Select(x => ProductToDTO(x)).ToList()
        };
        private static ProductShopDTO ProductToDTO(Product product) => new ProductShopDTO
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price
        };
    }
}
