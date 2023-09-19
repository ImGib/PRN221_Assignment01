using DataAccess;
using DataAccess.DataAccess;

namespace BusinessObject.Repository
{
    public class OrderDetailsRepository : IOrderDetailRepository
    {
        public void DeleteOrderDetails(OrderDetail orderDetail) => OrderDetailDAO.Instance.RemoveOrderDetails(orderDetail);

        public IEnumerable<OrderDetail> Get(int OrderID, int ProductID) => OrderDetailDAO.Instance.GetOrderDetailByID(OrderID, ProductID);

        public IEnumerable<OrderDetail> GetAll() => OrderDetailDAO.Instance.GetOrderDetails();

        public void InsertOrderDetails(OrderDetail orderDetail) => OrderDetailDAO.Instance.AddOrderDetails(orderDetail);

        public void UpdateOrderDetails(OrderDetail orderDetail) => OrderDetailDAO.Instance.UpdateOrderDetails(orderDetail);
    }
}
