using Domain;
using Domain.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Orders
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
