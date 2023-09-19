using DataAccess.DataAccess;

namespace DataAccess
{
    public class OrderDetailDAO
    {
        public OrderDetailDAO() { }
        private static OrderDetailDAO instance;
        private static readonly object instanceLock = new object();
        public static OrderDetailDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new OrderDetailDAO();
                    }
                    return instance;
                }
            }
        }

        public IEnumerable<OrderDetail> GetOrderDetailByID(int OrderID, int ProductID)
        {
            List<OrderDetail> orderDetail = new List<OrderDetail>();
            try
            {
                var salesManage = new SalesManagementContext();
                orderDetail = salesManage.OrderDetails.Where(od => (od.OrderId == OrderID) && (od.ProductId == ProductID)).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return orderDetail;
        }
        public IEnumerable<OrderDetail> GetOrderDetails()
        {
            List<OrderDetail> orderDetail = new List<OrderDetail>();
            try
            {
                var salesManage = new SalesManagementContext();
                orderDetail = salesManage.OrderDetails.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return orderDetail;
        }
        public void AddOrderDetails(OrderDetail orderDetail)
        {
            try
            {
                OrderDetail? orderCheck = GetOrderDetailByID(orderDetail.OrderId, orderDetail.ProductId).First();
                if (orderCheck == null)
                {
                    var salesManage = new SalesManagementContext();
                    salesManage.OrderDetails.Add(orderDetail);
                    salesManage.SaveChanges();
                }
                else
                {
                    throw new Exception("Order Details already exist!");
                }
            }
            catch (Exception)
            {
                throw new Exception("Order Details already exist!");
            }
        }
        public void UpdateOrderDetails(OrderDetail orderDetail)
        {
            try
            {
                OrderDetail? orderCheck = GetOrderDetailByID(orderDetail.OrderId, orderDetail.ProductId).First();
                if (orderCheck != null)
                {
                    var salesManage = new SalesManagementContext();
                    salesManage.Entry<OrderDetail>(orderDetail).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    salesManage.SaveChanges();
                }
                else
                {
                    throw new Exception("Order Details does not exist!");
                }
            }
            catch (Exception)
            {
                throw new Exception("Order Details does not exist!");
            }
        }
        public void RemoveOrderDetails(OrderDetail orderDetail)
        {
            try
            {
                OrderDetail? orderCheck = GetOrderDetailByID(orderDetail.OrderId, orderDetail.ProductId).First();
                if (orderCheck != null)
                {
                    var salesManage = new SalesManagementContext();
                    salesManage.OrderDetails.Remove(orderDetail);
                    salesManage.SaveChanges();
                }
                else
                {
                    throw new Exception("Order Details does not exist!");
                }
            }
            catch (Exception)
            {
                throw new Exception("Order Details does not exist!");
            }
        }
    }
}
