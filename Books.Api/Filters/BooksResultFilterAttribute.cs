using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading.Tasks;

namespace Books.Api.Filters
{
    public class BooksResultFilterAttribute : ResultFilterAttribute
    {
        //private readonly IMapper _mapper;
        //public BooksResultFilterAttribute()
        //{

        //}

        //public BooksResultFilterAttribute(IMapper mapper)
        //{
        //    _mapper = mapper;
        //}

        public override async Task OnResultExecutionAsync(
            ResultExecutingContext context,
            ResultExecutionDelegate next)
        {

            var resultFromAction = context.Result as ObjectResult;
            if (resultFromAction?.Value == null
                || resultFromAction.StatusCode < 200
                || resultFromAction.StatusCode >= 300)
            {
                await next();
                return;
            }

            //resultFromAction.Value = Mapper.Map<IEnumerable<Models.Book>>(resultFromAction.Value);
            //resultFromAction.Value = _mapper.Map<IEnumerable<Models.Book>>(resultFromAction.Value);

            await next();
        }
    }

}
