using GymApp.API.Interfaces;
using Models.Models;

namespace GymApp.API.Services
{
    public class TrainersService : GenericService<Trainers>, ITrainersService
    {
        private readonly ApplicationDbContext context;

        public TrainersService(ApplicationDbContext context)
            : base(context)
        {
            this.context = context;
        }
    }
}
