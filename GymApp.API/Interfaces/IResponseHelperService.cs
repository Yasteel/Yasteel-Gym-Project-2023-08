using Microsoft.AspNetCore.Mvc;
using Models.Models;
using System.Net;

namespace GymApp.API.Interfaces
{
    public interface IResponseHelperService
    {
        ActionResult GetSuccessResponseWithPayload(object payload);

        ActionResult GetSuccessResponseWithMessage(string message);

        ActionResult GetCreateSuccessResponse();

        ActionResult GetUpdateSuccessResponse();

        ActionResult GetBadDataResponse();

        ActionResult GetNotFoundResponse();

        ActionResult GetNotFoundResponseWithMessage(string message);

        ActionResult GetServerErrorResponse();

    }
}
