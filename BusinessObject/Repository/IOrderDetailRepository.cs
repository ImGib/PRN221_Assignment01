using DataAccess.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Repository
{
    public interface IOrderDetailRepository
    {
        IEnumerable<OrderDetail> GetAll();
        IEnumerable<OrderDetail> Get(int OrderID, int ProductID);
        void InsertOrderDetails(OrderDetail orderDetail);
        void UpdateOrderDetails(OrderDetail orderDetail);
        void DeleteOrderDetails(OrderDetail orderDetail);

    }
}
