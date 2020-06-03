using System.Collections.Generic;

namespace ShoppingCartProject.Interfaces
{
    public interface ICategory
    {
        string Title { get; set; }
        ICategory ParentCategory { get; set; }
        List<ICategory> GetParentCategories();
    }
}
