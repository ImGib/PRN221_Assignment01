using DataAccess;
using DataAccess.DataAccess;

namespace BusinessObject.Repository
{
    public class OrderRepository : IOrderRepository
    {
        public void DeleteOrder(Order order) => OrderDAO.Instance.RemoveOrder(order);

        public IEnumerable<Order> filterOrder(DateTime start, DateTime end)
            => OrderDAO.Instance.filterOrder(start, end);

        public IEnumerable<Order> GetAll() => OrderDAO.Instance.GetOrders();

        public Order GetOrder(int id) => OrderDAO.Instance.GetOrderByOrderId(id);

        public void InsertOrder(Order order) => OrderDAO.Instance.AddOrder(order);

        public void UpdateOrder(Order order) => OrderDAO.Instance.UpdateOrder(order);
    }
}
