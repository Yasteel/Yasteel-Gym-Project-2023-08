using GymApp.API.Interfaces;
using Models.Models;

namespace GymApp.API.Services
{
    public class MembersService : GenericService<Members>, IMembersService
    {
        private readonly ApplicationDbContext context;

        public MembersService(ApplicationDbContext context)
            : base(context)
        {
            this.context = context;
        }
    }
}
