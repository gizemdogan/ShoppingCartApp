using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShoppingCartProject.Interfaces;
using ShoppingCartProject.Models;
using System.Collections.Generic;

namespace ShoppingCartTest.CategoryTest
{
    [TestClass]
    public class CategoryUnitTest
    {
        [TestMethod]
        public void GetParentCategoriesTest()
        {
            List<Category> categories = new List<Category>();

            Category parentCategory = new Category("Food&Drinks");
            Category category = new Category("Food")
            {
                ParentCategory = parentCategory
            };

            categories.Add(category);
            categories.Add(parentCategory);

            List<ICategory> list = category.GetParentCategories();

            CollectionAssert.AreEqual(list, categories);
        }
    }
}
