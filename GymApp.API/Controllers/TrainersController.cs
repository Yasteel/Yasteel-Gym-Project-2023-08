namespace GymApp.API.Controllers
{
    using GymApp.API.Interfaces;
    using Microsoft.AspNetCore.Mvc;
    using Models.Models;

    [Route("api/[controller]")]
    [ApiController]
    public class TrainersController : ControllerBase
    {
        private readonly ITrainersService trainersService;
        private readonly IResponseHelperService responseService;

        public TrainersController(ITrainersService trainersService, IResponseHelperService responseService)
        {
            this.trainersService = trainersService;
            this.responseService = responseService;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var trainers = await this.trainersService.GetAll();

            return trainers == null ?
                this.responseService.GetNotFoundResponse() : this.responseService.GetSuccessResponseWithPayload(trainers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var trainer = await this.trainersService.Get(id);

            return trainer == null ?
                this.responseService.GetNotFoundResponse() : this.responseService.GetSuccessResponseWithPayload(trainer);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Trainers newTrainer)
        {
            if (!this.ModelState.IsValid)
            {
                return this.responseService.GetBadDataResponse();
            }

            var result = await this.trainersService.Create(newTrainer);

            return !result ?
                this.responseService.GetServerErrorResponse() : this.responseService.GetCreateSuccessResponse();
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> Patch(int id, [FromBody] Trainers trainer)
        {
            if (id <= 0 || !this.ModelState.IsValid)
            {
                return this.responseService.GetBadDataResponse();
            }

            var trainerToUpdate = await this.trainersService.Get(id);

            if (trainerToUpdate == null)
            {
                return this.responseService.GetNotFoundResponseWithMessage($"Trainer with id {id} - Not Found");
            }

            // Map the model from Body to the memberwithId

            trainerToUpdate.IdNumber = trainer.IdNumber;
            trainerToUpdate.Name = trainer.Name;
            trainerToUpdate.Surname = trainer.Surname;
            trainerToUpdate.ContactNumber = trainer.ContactNumber;
            trainerToUpdate.TrainerClass = trainer.TrainerClass;
            trainerToUpdate.Salary = trainer.Salary;

            var result = await this.trainersService.Update(trainerToUpdate);

            return !result ? this.responseService.GetServerErrorResponse() : this.responseService.GetUpdateSuccessResponse();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int? id)
        {
            if (id is null || id < 1)
            {
                return this.responseService.GetBadDataResponse();
            }

            var result = await this.trainersService.Delete((int)id);

            return !result ? this.responseService.GetServerErrorResponse() : this.responseService.GetSuccessResponseWithMessage("Record Deleted Successfully");
        }

    }
}
