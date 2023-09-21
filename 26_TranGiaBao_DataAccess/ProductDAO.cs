using DataAccess.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ProductDAO
    {
        public ProductDAO() { }
        private static ProductDAO instance;
        private static readonly object instanceLock = new object();
        public static ProductDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new ProductDAO();
                    }
                    return instance;
                }
            }
        }
        public Product? GetProductById(int id)
        {
            Product? pro = null;
            try
            {
                var salesManage = new SalesManagementContext();
                pro = salesManage.Products.SingleOrDefault(pro => pro.ProductId == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return pro;
        }
        public IEnumerable<Product> GetProducts()
        {
            List<Product> products = new List<Product>();
            try
            {
                var salesManage = new SalesManagementContext();
                products = salesManage.Products.ToList();
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return products;
        }
        public void InsertProduct(Product product)
        {
            try
            {
                Product? pro = GetProductById(product.ProductId);
                if (pro == null)
                {
                    var salesManage = new SalesManagementContext();
                    salesManage.Products.Add(product);
                    salesManage.SaveChanges();
                }
                else
                {
                    throw new Exception("Product already exist!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Product already exist!");
            }
        }
        public void UpdateProduct(Product product)
        {
            try
            {
                Product? pro = GetProductById(product.ProductId);
                if (pro != null)
                {
                    var salesManage = new SalesManagementContext();
                    salesManage.Entry<Product>(product).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    salesManage.SaveChanges();
                }
                else
                {
                    throw new Exception("Product does not already exist!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Productdoes not already exist!");
            }
        }
        public void RemoveProduct(Product product)
        {
            try
            {
                Product? pro = GetProductById(product.ProductId);
                if (pro != null)
                {
                    var salesManage = new SalesManagementContext();
                    salesManage.Products.Remove(product);
                    salesManage.SaveChanges();
                }
                else
                {
                    throw new Exception("Product does not already exist!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Productdoes not already exist!");
            }
        }
        public IEnumerable<Product> filterProduct(int proId, string proName, decimal uniPrice, int unitInStock)
        {
            List<Product> products = new List<Product>();
            try
            {
                var salesManagement = new SalesManagementContext();
                products = salesManagement.Products.Where(pro => 
                    (proId != -1 ? pro.ProductId == proId : pro.ProductId > proId) &&
                                                    pro.ProductName.Contains(proName) &&
                    (uniPrice != -1 ? pro.UnitPrice == uniPrice : pro.UnitPrice > uniPrice) &&
                    (unitInStock != -1 ? pro.UnitsInStock == unitInStock : pro.UnitsInStock > unitInStock)
                                                    ).ToList();
            } catch (Exception ex)
            {
                throw new Exception("Can't filter product!");
            }
            return products;
        }
    }
}
