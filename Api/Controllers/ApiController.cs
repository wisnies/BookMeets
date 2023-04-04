using Api.Common.HttpContext;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Api.Controllers
{
  [Route("api")]
  [ApiController]
  public class ApiController : ControllerBase
  {
    private IActionResult ValidationProblem(List<Error> errors)
    {
      var modelStateDictiondary = new ModelStateDictionary();
      foreach (var error in errors)
      {
        modelStateDictiondary.AddModelError(
          error.Code,
          error.Description);
      }
      return ValidationProblem(modelStateDictiondary);
    }

    private IActionResult Problem(Error error)
    {
      var statusCode = error.Type switch
      {
        ErrorType.Conflict => StatusCodes.Status409Conflict,
        ErrorType.NotFound => StatusCodes.Status404NotFound,
        ErrorType.Validation => StatusCodes.Status400BadRequest
      };

      return Problem(statusCode: statusCode, title: error.Description);

    }

    protected IActionResult Problem(List<Error> errors)
    {
      if (errors.Count is 0)
      {
        return Problem();
      }
      if (errors.All(error => error.Type == ErrorType.Validation))
      {
        return ValidationProblem(errors);
      }
      HttpContext.Items[HttpContextItemKeys.Errors] = errors;
      return Problem(errors[0]);
    }
  }
}
