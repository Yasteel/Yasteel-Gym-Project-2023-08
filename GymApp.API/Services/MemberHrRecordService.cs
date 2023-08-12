using GymApp.API.Interfaces;
using Models.Models;

namespace GymApp.API.Services
{
    public class MemberHrRecordService : GenericService<MemberHrRecord>, IMemberHrRecordService
    {
        private readonly ApplicationDbContext context;

        public MemberHrRecordService(ApplicationDbContext context)
            : base(context)
        {
            this.context = context;
        }
    }
}
