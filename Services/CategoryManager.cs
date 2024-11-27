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

        public async Task ShowAllCategories()
        {
            Console.WriteLine(@"
            
            Categorieën:

             ID  | Categorienaam       | Beschrijving       
            ------------------------------------------------");
            List<Category> categories = await _categoryDatabaseService.GetAllCategories();

            foreach (Category category in categories)
            {
                string name = category.Name.PadRight(20);
                string id = category.Id.ToString().PadRight(4);
                string description = category.Description.Length > 40 ? category.Description.Substring(0, 40) + "..." : category.Description; // if length > 40 dan substring anders hele description.

                Console.WriteLine($@"
                {id}| {name}|{description}");
            }


        }

    }

}