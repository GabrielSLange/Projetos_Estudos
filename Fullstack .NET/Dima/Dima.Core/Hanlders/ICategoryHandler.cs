using Dima.Core.Model;
using Dima.Core.Requests.Categories;
using Dima.Core.Responses;

namespace Dima.Core.Hanlders
{
    public interface ICategoryHandler
    {
        Task<PagedResponse<List<Category>>> GetAllAsync(GetAllCategoriesRequest request);
        Task<Response<Category?>> GetByIdAsync(GetCategoryByIdRequest request);
        Task<Response<Category?>> CreateAsync(CreateCategoryRequest request);
        Task<Response<Category?>> UpdateAsync(UpdateCategoryRequest request);
        Task<Response<Category?>> DeleteAsync(DeleteCategoryRequest request);
    }
}