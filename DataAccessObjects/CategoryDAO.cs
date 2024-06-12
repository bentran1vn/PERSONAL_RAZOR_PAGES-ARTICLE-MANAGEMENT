using BusinessObjects;
using Repository.Interface;
using System.Collections.Generic;

namespace DataAccessObjects
{
    public class CategoryDAO(IUnitOfWork unitOfWork)
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public IEnumerable<Category> GetAllCategories()
        {
            return _unitOfWork.CategoryRepository.GetAll();
        }

    }
}
