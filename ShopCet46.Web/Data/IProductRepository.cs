using ShopCet46.Web.Data.Entities;
using System.Linq;

namespace ShopCet46.Web.Data
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        IQueryable GetAllWithUsers();
    }
}
