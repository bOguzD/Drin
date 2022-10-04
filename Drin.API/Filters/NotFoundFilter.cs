using Drin.Core.Entities;
using Drin.Core.Responses;
using Drin.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Drin.API.Filters
{
    public class NotFoundFilter<T> : IAsyncActionFilter where T : BaseEntity
    {
        private readonly IService<T> _service;

        public NotFoundFilter(IService<T> service)
        {
            _service = service;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var idVal = context.ActionArguments.Values.FirstOrDefault();

            if (idVal == null)
            {
                await next.Invoke();
                return;
            }

            var id = (int)idVal;
            var anyEntity = await _service.AnyAsync(x=>x.Id == id);
            
            if (anyEntity)
            {
                await next.Invoke();
                return;
            }

            context.Result = new NotFoundObjectResult(ServiceResponse.Failure(404, $"{typeof(T).Name} (id: {id}) not found"));
        }
    }
}
