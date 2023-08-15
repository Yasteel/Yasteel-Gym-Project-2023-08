namespace GymApp.API.Controllers
{
    using GymApp.API.Interfaces;
    using Microsoft.AspNetCore.Mvc;
    using Models.Models;

    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private readonly IMembersService membersService;
        private readonly IResponseHelperService responseService;

        public MembersController(IMembersService membersService, IResponseHelperService responseService)
        {
            this.membersService = membersService;
            this.responseService = responseService;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var members = await this.membersService.GetAll();

            return members == null ?
                this.responseService.GetNotFoundResponse() : this.responseService.GetSuccessResponseWithPayload(members);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var member = await this.membersService.Get(id);

            return member == null ?
                this.responseService.GetNotFoundResponse() : this.responseService.GetSuccessResponseWithPayload(member);
        }

        [HttpGet("/trainer/{trainerId}")]
        public async Task<ActionResult> GetTrainers(int trainerId)
        {
            var members = await this.membersService.GetAll();

            return members == null ?
                this.responseService.GetNotFoundResponse() : this.responseService.GetSuccessResponseWithPayload(members);
        }


        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Members newMember)
        {
            if (!this.ModelState.IsValid)
            {
                return this.responseService.GetBadDataResponse();
            }

            var result = await this.membersService.Create(newMember);

            return !result ?
                this.responseService.GetServerErrorResponse() : this.responseService.GetCreateSuccessResponse();
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> Patch(int id, [FromBody] Members member)
        {
            if(id <= 0 || !this.ModelState.IsValid)
            {
                return this.responseService.GetBadDataResponse();
            }

            var memberToUpdate = await this.membersService.Get(id);

            if(memberToUpdate == null)
            {
                return this.responseService.GetNotFoundResponseWithMessage($"Member with id {id} - Not Found");
            }

            // Map the model from Body to the memberwithId

            memberToUpdate.IdNumber = member.IdNumber;
            memberToUpdate.Name = member.Name;
            memberToUpdate.Surname = member.Surname;
            memberToUpdate.Gender = member.Gender;
            memberToUpdate.Age = member.Age;
            memberToUpdate.Height = member.Height;
            memberToUpdate.ContactNumber = member.ContactNumber;
            memberToUpdate.MembershipType = member.MembershipType;

            var result = await this.membersService.Update(memberToUpdate);

            return !result ? this.responseService.GetServerErrorResponse() : this.responseService.GetUpdateSuccessResponse();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int? id)
        {
            if(id is null || id < 1)
            {
                return this.responseService.GetBadDataResponse();
            }

            var result = await this.membersService.Delete((int)id);

            return !result ? this.responseService.GetServerErrorResponse() : this.responseService.GetSuccessResponseWithMessage("Record Deleted Successfully");
        }
    }
}
