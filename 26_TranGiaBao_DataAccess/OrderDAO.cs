using DataAccess.DataAccess;

namespace DataAccess
{
    public class OrderDAO
    {
        private static OrderDAO instance;
        private static readonly object instanceLock = new object();
        public OrderDAO() { }
        public static OrderDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new OrderDAO();
                    }
                    return instance;
                }

            }
        }
        //GetById
        public Order? GetOrderByOrderId(int id)
        {
            Order? order = null;
            try
            {
                var salesManage = new SalesManagementContext();
                order = salesManage.Orders.SingleOrDefault(order => order.OrderId == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return order;
        }
        //GetAll
        public IEnumerable<Order> GetOrders()
        {
            List<Order> order = new List<Order>();
            try
            {
                var salesManage = new SalesManagementContext();
                order = salesManage.Orders.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
            return order;
        }
        //Insert
        public void AddOrder(Order order)
        {
            try
            {
                //check exist
                Order? ord = GetOrderByOrderId(order.OrderId);
                if (ord == null)
                {
                    var salesManage = new SalesManagementContext();
                    salesManage.Orders.Add(order);
                    salesManage.SaveChanges();
                }
                else
                {
                    throw new Exception("Order already exist!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }
        //Update
        public void UpdateOrder(Order order)
        {
            try
            {
                //check exist
                Order? ord = GetOrderByOrderId(order.OrderId);
                if (ord != null)
                {
                    var salesManage = new SalesManagementContext();
                    salesManage.Entry<Order>(order).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    salesManage.SaveChanges();
                }
                else
                {
                    throw new Exception("Order dose not already exist!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }
        //Delete
        public void RemoveOrder(Order order)
        {
            try
            {
                //check exist
                Order? ord = GetOrderByOrderId(order.OrderId);
                if (ord != null)
                {
                    var salesManage = new SalesManagementContext();
                    salesManage.Orders.Remove(order);
                    salesManage.SaveChanges();
                }
                else
                {
                    throw new Exception("Order does not already exist!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }
        public IEnumerable<Order> filterOrder(DateTime start, DateTime end)
        {
            List<Order> orders = new List<Order>();
            try
            {
                var salesManage = new SalesManagementContext();
                orders = salesManage.Orders.Where(ord => ord.OrderDate >= start && ord.OrderDate <= end)
                                            .OrderBy(ord => ord.OrderDate).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Faile to filter Order!");
            }
            return orders;
        }
    }
}
