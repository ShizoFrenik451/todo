using SQLite;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using SQLiteNetExtensions.Attributes;

namespace SimpleTodo.Models
{
    public class TodoCategory
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Name { get; set; }
       
        public string Description { get; set; }

        [OneToMany]
        public ICollection<TodoItem> TodoItems { get; set; }

        public int Priority { get; set; }
    }
}
