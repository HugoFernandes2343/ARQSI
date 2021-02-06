using System.Collections.Generic;

namespace SIC.Models
{
    public class Category
    {
        public Category()
        {
        }

        public Category(string name)
        {
            this.name = name;
        }

        public Category(string name, Category fatherCat)
        {
            this.fatherCat = fatherCat;
            this.name = name;
        }

        public int CategoryId { get; set; }

        public string name { get; set; }

        public virtual Category fatherCat { get; set; }

        public void updateName(string name)
        {
            this.name = name;
        }

        public void updateFather(Category father)
        {
            this.fatherCat = father;
        }

        public List<Category> getFathers()
        {
            if (fatherCat == null)
            {
                return new List<Category>();
            }

            return searchFathers(new List<Category>(), this.fatherCat);
        }

        private List<Category> searchFathers(List<Category> cats, Category cate)
        {
            cats.Add(cate);
            if (cate.fatherCat == null)
            {
                return cats;
            }
            return searchFathers(cats, cate.fatherCat);
        }
    }
}