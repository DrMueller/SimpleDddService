using Microsoft.AspNetCore.Mvc;
using SimpleDddService.Infrastructure.LanguageExtensions.Maybes;

namespace SimpleDddService.Areas.IndividualManagement.Web.Infrastructure.Extensions
{
    internal static class MaybeExtensions
    {
        internal static IActionResult ToGetActionResult<T>(this Maybe<T> maybe)
        {
            var result = maybe.Evaluate<IActionResult>(
                f => new OkObjectResult(f),
                () => new NoContentResult());

            return result;
        }
    }
}