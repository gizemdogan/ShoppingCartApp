using ShoppingCartProject.Interfaces;
using System.Collections.Generic;

namespace ShoppingCartProject.Models
{
    public class Category : ICategory
    {
        public string Title { get; set; }
        public ICategory ParentCategory { get; set; }

        public Category()
        {
            ParentCategory = new Category();
        }

        public Category(string title)
        {
            this.Title = title;
        }

        public List<ICategory> GetParentCategories()
        {
            List<ICategory> categories = new List<ICategory>();

            ICategory category = this;
            categories.Add(this);

            while (category.ParentCategory != null)
            {
                category = category.ParentCategory;
                categories.Add(category);
            }

            return categories;
        }
    }
}