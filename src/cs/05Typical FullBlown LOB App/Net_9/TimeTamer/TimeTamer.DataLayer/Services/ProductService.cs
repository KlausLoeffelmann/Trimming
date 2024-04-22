using TaskTamer.DataLayer.Models;
using TaskTamer.DataLayer.UnitOfWork;

namespace TaskTamer.DataLayer.Services
{
    public class ProductService(IUnitOfWork unitOfWork)
    {
        private readonly IRepository<Project> _productRepository = unitOfWork.Repository<Project>();

        public async Task<IEnumerable<Project>> GetAllProductsAsync()
        {
            return await _productRepository.GetAllAsync();
        }

        public async Task AddProductAsync(Project product)
        {
            // Here, you can include any business logic, validation, etc.
            await _productRepository.AddAsync(product);
            await unitOfWork.SaveChangesAsync();
        }

        // Other CRUD operations...
    }
}
