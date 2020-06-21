using brewjournal.Application.Common.Mappings;
using brewjournal.Domain.Entities;

namespace brewjournal.Application.TodoLists.Queries.ExportTodos
{
    public class TodoItemRecord : IMapFrom<TodoItem>
    {
        public string Title { get; set; }

        public bool Done { get; set; }
    }
}
