using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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

        public Task<List<Todo>> GetAll()
        {
            return _todoContext.TodoItems.OrderByDescending(c => c.Id).ToListAsync();
        }

        public Todo Get(long id)
        {
            return _todoContext.TodoItems
                .FirstOrDefault(e => e.Id == id);
        }

        public Task Add(Todo entity)
        {
            _todoContext.TodoItems.AddAsync(entity);
            return _todoContext.SaveChangesAsync();
        }

        public Task Update(Todo dbEntity, Todo entity)
        {
            dbEntity.Name = entity.Name;
            dbEntity.IsComplete = entity.IsComplete;
            return _todoContext.SaveChangesAsync();
        }

        public Task Delete(Todo entity)
        {
            _todoContext.TodoItems.Remove(entity);
            return _todoContext.SaveChangesAsync();
        }
    }
}