using BLL.Services.Interfaces;
using DAL.Data.Interfaces;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Concrete
{
	class CategoryService : ICategoryService
	{
		ICategoryRepository _categoryRepository;

		public CategoryService(ICategoryRepository categoryRepository)
		{
			_categoryRepository = categoryRepository;
		}

		public IEnumerable<CategoryOfReminder> GetAllCategories()
		{
			return _categoryRepository.GetAll();
		}

		public CategoryOfReminder Read(int? id)
		{
			return _categoryRepository.Read(id);
		}
	}
}
