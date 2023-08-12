using GymApp.API.Interfaces;
using Models.Models;

namespace GymApp.API.Services
{
    public class MemberTrainerLinkService : GenericService<MemberTrainerLink>, IMemberTrainerLinkService
    {
        private readonly ApplicationDbContext context;

        public MemberTrainerLinkService(ApplicationDbContext context)
            : base(context)
        {
            this.context = context;
        }
    }
}
