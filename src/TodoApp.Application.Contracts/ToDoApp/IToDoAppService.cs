using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Services;
using System.Threading.Tasks;

namespace TodoApp.ToDoApp
{
    public interface IToDoAppService : IApplicationService
    {
        Task<List<ToDoItemDto>> GetListAsync();
        Task<ToDoItemDto> CreateAsync(string text);
        Task DeleteAsync(Guid id);
    }
}
