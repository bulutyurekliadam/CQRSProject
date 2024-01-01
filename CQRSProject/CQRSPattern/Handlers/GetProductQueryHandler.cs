using CQRSProject.CQRSPattern.Results;
using CQRSProject.DAL.Context;

namespace CQRSProject.CQRSPattern.Handlers
{
    public class GetProductQueryHandler
    {
        private readonly SaleContext _context;

        public GetProductQueryHandler(SaleContext context)
        {
            _context = context;
        }
        public List<GetProductQueryResult> Handle()
        {
            var values = _context.Products.Select(x => new GetProductQueryResult
            {
                Price = x.Price,
                ProductName = x.ProductName,
                ProductID = x.ProductID,
                Stock = x.Stock,
                CategoryID = x.CategoryID
            }).ToList();
            return values;
        }
    }
}
