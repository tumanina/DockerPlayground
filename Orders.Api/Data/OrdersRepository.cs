using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Orders.Api.Data
{
    public class OrdersRepository : IOrdersRepository
    {
        private readonly OrdersContext _context;

        public OrdersRepository(OrdersContext context)
        {
            _context = context;
        }

        public async Task<List<Order>> GetAllAsync()
        {
            return await _context.Orders.ToListAsync();
        }
    }

    public interface IOrdersRepository
    {
        Task<List<Order>> GetAllAsync();
    }
}
