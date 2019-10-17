using EasyMeal.Core.Domain;
using EasyMeal.Core.Domain.Services;
using Microsoft.AspNetCore.Identity;

namespace EasyMeal.Infrastructure.Orders
{
    public class EFOrderRepository : IOrderRepository
    {
        private readonly OrderDbContext context;
        private readonly UserManager<Client> userManager;

        public EFOrderRepository(OrderDbContext context)
        {
            this.context = context;
        }
    }
}
