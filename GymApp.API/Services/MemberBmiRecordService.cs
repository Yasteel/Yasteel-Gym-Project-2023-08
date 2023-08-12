using GymApp.API.Interfaces;
using Models.Models;

namespace GymApp.API.Services
{
    public class MemberBmiRecordService : GenericService<MemberBmiRecord>, IMemberBmiRecordService
    {
        private readonly ApplicationDbContext content;

        public MemberBmiRecordService(ApplicationDbContext content)
            : base(content)
        {
            this.content = content;
        }
    }
}
