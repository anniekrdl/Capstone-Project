namespace OnlineWebshop
{

    public class CategoryManager {
       private List<Category> _categories;


       public CategoryManager(){
        _categories = new List<Category>();
       }

       public void AddCategory(Category category){
        _categories.Add(category);
       }


    }
    
}