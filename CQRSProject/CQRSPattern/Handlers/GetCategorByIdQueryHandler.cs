using CQRSProject.CQRSPattern.Queries;
using CQRSProject.CQRSPattern.Results;
using CQRSProject.DAL.Context;

namespace CQRSProject.CQRSPattern.Handlers
{
    public class GetCategorByIdQueryHandler
    {
        private readonly SaleContext _context;

        public GetCategorByIdQueryHandler(SaleContext context)
        {
            _context = context;
        }
        public GetCategoryByIdQueryResult Handle(GetCategoryByIdQuery query)
        {
            var values = _context.Categories.Find(query.Id);
            return new GetCategoryByIdQueryResult
            {
                CategoryID = values.CategoryID,
                CategoryName = values.CategoryName
            };
        }
    }
}
