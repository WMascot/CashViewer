using CashViewer_backend.DAL.Entities;
using CashViewer_backend.DAL.Interfaces;

namespace CashViewer_backend.BAL.Services
{
    public class ServiceShop
    {
        private readonly IRepository<Shop> _shopsRepository;
        public ServiceShop(IRepository<Shop> repository) => _shopsRepository = repository;
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
    }
}
