using System.Collections.Generic;
using System.Linq;
using ServiceSandec.Models;

namespace ServiceSandec.Repositories
{
    public class TodoRepository : ITodoRepository<Todo>
    {
        private readonly TodoContext _todoContext;

        public TodoRepository(TodoContext context)
        {
            _todoContext = context;
        }

        public IEnumerable<Todo> GetAll()
        {
            return _todoContext.TodoItems.OrderByDescending(c => c.Id).ToList();
        }

        public Todo Get(long id)
        {
            return _todoContext.TodoItems
                .FirstOrDefault(e => e.Id == id);
        }

        public void Add(Todo entity)
        {
            _todoContext.TodoItems.Add(entity);
            _todoContext.SaveChanges();
        }

        public void Update(Todo dbEntity, Todo entity)
        {
            dbEntity.Name = entity.Name;
            dbEntity.IsComplete = entity.IsComplete;
            _todoContext.SaveChanges();
        }

        public void Delete(Todo entity)
        {
            _todoContext.TodoItems.Remove(entity);
            _todoContext.SaveChanges();
        }
    }
}