using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using News24.Data.Infrastructure;
using News24.Data.Repositories;
using News24.Model;

namespace News24.Service
{
    public interface ICategoryService
    {
        Category GetCategory(int id);

        List<Category> GetCategories();

        void CreateCategory(Category category);

        void DeleteCategory(Category category);

        void UpdateCategory(Category category);

        IEnumerable<ValidationResult> CanAddCategory(Category newCategory);

    }
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(IUnitOfWork unitOfWork, ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<ValidationResult> CanAddCategory(Category newCategory)
        {
            Category category;
            if (newCategory.Id == 0)
            {
                category = _categoryRepository.Get(x => x.Name == newCategory.Name);
            }
            else
            {
                category = _categoryRepository.Get(
                    x => x.Name == newCategory.Name && x.Id != newCategory.Id);
            }

            if (category != null)
            {
                yield return new ValidationResult("Категория с данным названием уже существует");
            }
        }

        public void CreateCategory(Category category)
        {
            _categoryRepository.Add(category);
            _unitOfWork.Commit();
        }

        public void DeleteCategory(Category category)
        {
            _categoryRepository.Delete(category);
            _unitOfWork.Commit();
        }

        public List<Category> GetCategories()
        {
            var categories = _categoryRepository.GetAll().OrderBy(x=>x.Name).ToList();
            return categories;
        }

        public Category GetCategory(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateCategory(Category category)
        {
            throw new NotImplementedException();
        }
    }
}
