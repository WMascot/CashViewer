using CashViewer_backend.DAL.Entities;
using CashViewer_backend.DAL.Interfaces;

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
        public IQueryable<Shop> GetAllShops() => _shopsRepository.Items;
        public Shop GetShopById(int id)
        {
            var shop = _shopsRepository.Get(id);
            if (shop == null) throw new ArgumentNullException(nameof(shop));
            return shop;
        }
        public void AddShop(Shop shop) => _shopsRepository.Add(shop);
        public void RemoveShopById(int id) => _shopsRepository.Remove(id);
        public void UpdateShop(Shop shop) => _shopsRepository.Update(shop);
        public Shop SearchShop(string name, ShopType? type)
        {
            if (type != null)
            {
                var shop = _shopsRepository.Items.FirstOrDefault(x => x.Name.Contains(name) && x.Type == type);
                if (shop == null) throw new ArgumentNullException(nameof(shop));
                return shop;
            }
            else
            {
                var shop = _shopsRepository.Items.FirstOrDefault(x => x.Name.Contains(name));
                if (shop == null) throw new ArgumentNullException(nameof(shop));
                return shop;
            }
        }
        public IQueryable<ShopType> GetAllTypes() => _shopTypesRepository.Items;
        public void AddType(ShopType type) => _shopTypesRepository.Add(type);
        public void RemoveTypeById(int id) => _shopTypesRepository.Remove(id);
    }
}
