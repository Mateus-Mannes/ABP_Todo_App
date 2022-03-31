using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace TodoApp.ToDoApp
{
    public class ToDoAppService : ApplicationService, IToDoAppService
    {
        private readonly IRepository<ToDoItem, Guid> _todoItemRepository;
        public ToDoAppService(IRepository<ToDoItem, Guid> todoItemRepository)
        {
            _todoItemRepository = todoItemRepository;
        }

        public async Task<List<ToDoItemDto>> GetListAsync()
        {
            var itens = await _todoItemRepository.GetListAsync(x => x.CurrentUserId == CurrentUser.Id);
            return itens
                .Select(item => new ToDoItemDto
                {
                    Id = item.Id,
                    Text = item.Text
                }).ToList();
        }

        public async Task<ToDoItemDto> CreateAsync(string text)
        {
            var item = await _todoItemRepository.InsertAsync(new ToDoItem
            {
                Text = text,
                CurrentUserId = CurrentUser.Id
            });

            return new ToDoItemDto
                {
                    Id = item.Id,
                    Text = item.Text
                };
        }

        public async Task DeleteAsync(Guid id)
        {
            await _todoItemRepository.DeleteAsync(id);
        }


    }
}
