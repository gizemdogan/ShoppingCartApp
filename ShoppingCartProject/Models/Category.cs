using ShoppingCartProject.Interfaces;
using System.Collections.Generic;

namespace ShoppingCartProject.Models
{
    /// <summary>
    /// Kategori
    /// </summary>
    public class Category : ICategory
    {
        /// <summary>
        /// Kategori Adı
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Ana Kategori bilgisi
        /// </summary>
        public ICategory ParentCategory { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Category()
        {
            ParentCategory = new Category();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="title"></param>
        public Category(string title)
        {
            this.Title = title;
        }

        /// <summary>
        /// Kategorinin kendisini ve üst kategorilerinin listesini getirir.
        /// </summary>
        /// <returns></returns>
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