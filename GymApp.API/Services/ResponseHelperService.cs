using GymApp.API.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models.Models;
using System.Net;

namespace GymApp.API.Services
{
    public class ResponseHelperService : ControllerBase, IResponseHelperService
    {

        public ActionResult GetSuccessResponseWithPayload(object payload)
        {
            return this.Ok(new ApiResponse()
            {
                Code = HttpStatusCode.OK,
                StatusCode = HttpStatusCode.OK.ToString(),
                Success = true,
                Payload = payload
            });
        }

        public ActionResult GetSuccessResponseWithMessage(string message)
        {
            return this.Ok(new ApiResponse()
            {
                Code = HttpStatusCode.OK,
                StatusCode = HttpStatusCode.OK.ToString(),
                Success = true,
                Message = message
            });
        }

        public ActionResult GetCreateSuccessResponse()
        {
            return this.Ok(new ApiResponse()
            {
                Code = HttpStatusCode.Created,
                StatusCode = HttpStatusCode.Created.ToString(),
                Success = true,
                Message = "Create Successful"
            });
        }

        public ActionResult GetUpdateSuccessResponse()
        {
            return this.Ok(new ApiResponse()
            {
                Code = HttpStatusCode.NoContent,
                StatusCode = HttpStatusCode.NoContent.ToString(),
                Success = true,
                Message = "Update Successful"
            });
        }

        public ActionResult GetBadDataResponse()
        {
            return this.BadRequest(new ApiResponse()
            {
                Code = HttpStatusCode.BadRequest,
                StatusCode = HttpStatusCode.BadRequest.ToString(),
                Success = false,
                Message = "Invalid Request"
            });
        }

        public ActionResult GetNotFoundResponse()
        {
            return this.NotFound(new ApiResponse()
            {
                Code = HttpStatusCode.NotFound,
                StatusCode = HttpStatusCode.NotFound.ToString(),
                Success = false
            });
        }

        public ActionResult GetNotFoundResponseWithMessage(string message)
        {
            return this.NotFound(new ApiResponse()
            {
                Code = HttpStatusCode.NotFound,
                StatusCode = HttpStatusCode.NotFound.ToString(),
                Success = false,
                Message = message
            });
        }

        public ActionResult GetServerErrorResponse()
        {
            return this.BadRequest(new ApiResponse()
            {
                Code = HttpStatusCode.InternalServerError,
                StatusCode = HttpStatusCode.InternalServerError.ToString(),
                Success = false,
                Message = "Something Went Wrong on Our Side"
            });
        }


        
    }
}
