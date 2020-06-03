using ShoppingCartProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartProject.Interfaces
{
    public interface ICategory
    {
         string Title { get; set; }
         ICategory ParentCategory { get; set; }

        List<ICategory> GetParentCategories();
    }
}
