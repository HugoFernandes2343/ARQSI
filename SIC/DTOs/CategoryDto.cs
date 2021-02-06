using SIC.Models;

namespace SIC.DTOs
{
    public class CategoryDto
    {
        public string name { get; set; }

        public int categoryId { get; set; }

        public CategoryDto(Category category)
        {
            this.categoryId = category.CategoryId;
            this.name = convertToTaxonomy(category.name, category);
        }

        public CategoryDto()
        {
        }

        public string convertToTaxonomy(string name, Category cate)
        {
            if (cate.fatherCat == null)
            {
                return name;
            }
            name = cate.fatherCat.name + ";" + name;
            return convertToTaxonomy(name, cate.fatherCat);
        }

        public Category toCategory()
        {
            string[] names = name.Split(";");
            Category grandFather = new Category(names[0]);
            Category cate = new Category(names[1], grandFather);
            for (int i = 2; i < names.Length; i++)
            {
                Category cat = cate;
                cate = new Category(names[i], cat);
            }
            return cate;
        }
    }
}