using BusinessObjects;
using Repository.Interface;
using System.Collections.Generic;
using Repository.Implement;

namespace DataAccessObjects
{
    public class CategoryDAO(IUnitOfWork unitOfWork)
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public IEnumerable<Category> GetAllCategories()
        {
            return _unitOfWork.CategoryRepository.GetAll();
        }
        
        public void Add(Category cate)
        {
            _unitOfWork.CategoryRepository.Add(cate);
            _unitOfWork.SaveChanges();
        }
        
        public void Update(Category cate)
        {
            _unitOfWork.CategoryRepository.Update(cate);
            _unitOfWork.SaveChanges();
        }
        
        public void Remove(Category cate)
        {
            _unitOfWork.CategoryRepository.Remove(cate);
            _unitOfWork.SaveChanges();
        }
        
        public Category? GetCategoryById(short id)
        {
            return _unitOfWork.CategoryRepository.FindEnityByConditionn(x => x.CategoryId == id);
        }
        public int GetId()
        {
            
            return _unitOfWork.CategoryRepository.GetAll().Select(x => x.CategoryId).Max() + 1;
        }
    }
}
