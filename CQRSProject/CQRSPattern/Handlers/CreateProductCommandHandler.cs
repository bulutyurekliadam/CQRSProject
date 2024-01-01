using CQRSProject.CQRSPattern.Commands;
using CQRSProject.DAL.Context;
using CQRSProject.DAL.Entities;

namespace CQRSProject.CQRSPattern.Handlers
{
    public class CreateProductCommandHandler
    {
        private readonly SaleContext _context;

        public CreateProductCommandHandler(SaleContext context)
        {
            _context = context;
        }
        public void Handle(CreateProductCommand command)
        {
            _context.Add(new Product
            {
                CategoryID = command.CategoryID,
                ProductName = command.ProductName,
                Price = command.Price,
                Stock = command.Stock,

            });
            _context.SaveChanges();
        }
    }
}
