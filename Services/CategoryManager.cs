namespace OnlineWebshop
{

    public class CategoryManager : ICategoryManager
    {


        private readonly CategoryDatabaseService _categoryDatabaseService;

        public CategoryManager(CategoryDatabaseService categoryDatabaseService)
        {
            _categoryDatabaseService = categoryDatabaseService;

        }

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