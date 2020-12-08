using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NetCoreApiProject.API.DTOs.Error;
using NetCoreApiProject.Core.Entities.Abstract;
using NetCoreApiProject.Core.Services;

namespace NetCoreApiProject.API.Filters
{
    public class NotFoundFilter<TEntity> : IAsyncActionFilter where TEntity : class, IEntity, new()
    {
        private readonly IService<TEntity> _service;

        public NotFoundFilter(IService<TEntity> service)
        {
            _service = service;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)

        {
            var id = (int)context.ActionArguments.Values.FirstOrDefault();

            var entry = await _service.GetByIdAsync(id);

            if (entry != null)
            {
                await next();
            }
            else
            {
                ErrorDto errorDto = new ErrorDto();

                errorDto.StatusCode = 404;
                errorDto.Errors.Add($"Id = '{id}' is Not Found");

                context.Result = new NotFoundObjectResult(errorDto);
            }

        }

    }
}

