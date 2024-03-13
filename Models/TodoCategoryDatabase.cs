using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTodo.Models
{
    class TodoCategoryDatabase
    {
        SQLiteAsyncConnection Database;        

        async Task Init()
        {
            if (Database is not null)
                return;

            Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
            await Database.CreateTableAsync<TodoCategory>(); 
        }

        public async Task<List<TodoCategory>> GetCategoriesAsync()
        {
            await Init();
            return await Database.Table<TodoCategory>().ToListAsync();
        }

        public async Task<TodoCategory> GetCategoryAsync(int id)
        {
            await Init();
            return await Database.Table<TodoCategory>().Where(c => c.Id == id).FirstOrDefaultAsync();
        }

        public async Task<int> SaveCategoryAsync(TodoCategory category)
        {
            await Init();
            if (category.Id != 0)
                return await Database.UpdateAsync(category);
            else
                return await Database.InsertAsync(category);
        }

        public async Task<int> DeleteCategoryAsync(TodoCategory category)
        {
            await Init();
            return await Database.DeleteAsync(category);
        }
    }
}
