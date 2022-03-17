using System;
using System.Threading.Tasks;
using TodoApp.ToDoApp;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace TodoApp.ToDoApp
{
    public class ToDoAppDataSeederContributor
        : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<ToDoItem, Guid> _toDoItemRepository;

        public ToDoAppDataSeederContributor(IRepository<ToDoItem, Guid> toDoItemRepository)
        {
            _toDoItemRepository = toDoItemRepository;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (await _toDoItemRepository.GetCountAsync() <= 0)
            {
                await _toDoItemRepository.InsertAsync(
                    new ToDoItem
                    {
                        Text = "Levar o Lixo"
                    },
                    autoSave: true
                );

                await _toDoItemRepository.InsertAsync(
                    new ToDoItem
                    {
                        Text = "Fazer trabalho"
                    },
                    autoSave: true
                );
            }
        }
    }
}
