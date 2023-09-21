using DataAccess.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Repository
{
    public interface IProductReposity
    {
        Product GetProduct(int id);
        IEnumerable<Product> GetProducts();
        void InsertProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(Product product);
        IEnumerable<Product> filterProduct(int proId, string proName, decimal uniPrice, int unitInStock);
    }
}
