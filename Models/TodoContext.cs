using Microsoft.EntityFrameworkCore;

namespace ServiceSandec.Models
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options)
            : base(options)
        {
        }

        public DbSet<Todo> TodoItems { get; set; }
    }
}
