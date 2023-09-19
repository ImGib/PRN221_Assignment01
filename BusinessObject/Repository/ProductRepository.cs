using DataAccess;
using DataAccess.DataAccess;

namespace BusinessObject.Repository
{
    public class ProductRepository : IProductReposity
    {
        public void DeleteProduct(Product product) => ProductDAO.Instance.RemoveProduct(product);

        public Product GetProduct(int id) => ProductDAO.Instance.GetProductById(id);

        public IEnumerable<Product> GetProducts() => ProductDAO.Instance.GetProducts();

        public void InsertProduct(Product product) => ProductDAO.Instance.InsertProduct(product);

        public void UpdateProduct(Product product) => ProductDAO.Instance.UpdateProduct(product);
    }
}
