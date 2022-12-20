using CashViewer_backend.DAL.Interfaces;

namespace CashViewer_backend.DAL.Entities.Base
{
    public abstract class Entity: IEntity
    {
        public int Id { get; set; }
    }
}
