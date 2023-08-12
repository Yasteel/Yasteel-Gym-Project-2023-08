namespace GymApp.API.Controllers
{
    using GymApp.API.Interfaces;
    using Microsoft.AspNetCore.Mvc;


    [Route("api/[controller]")]
    [ApiController]
    public class TrainersController : ControllerBase
    {
        private readonly ITrainersService trainersService;

        public TrainersController(ITrainersService trainersService)
        {
            this.trainersService = trainersService;
        }

        //[HttpGet]
        //public async Task<ActionResult> Get()
        //{
        //    this.trainersService.GetAll();
        //}
    }
}
