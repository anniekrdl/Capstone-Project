namespace OnlineWebshop
{

    public class CategoryManager
    {
        private CategoryDatabaseService _categoryDatabaseService = new CategoryDatabaseService();


        public async void AddCategory(Category category)
        {
            await _categoryDatabaseService.AddCategory(category);
        }

        public async void RemoveCategory(Category category)
        {
            await _categoryDatabaseService.RemoveCategory(category);
        }

        public async Task<List<Category>> GetCategories()
        {

            return await _categoryDatabaseService.GetAllCategories();
        }

        public async Task<List<Category>> SearchCategorie(string searchTerm)
        {
            return await _categoryDatabaseService.SearchCategory(searchTerm);
        }

    }

}