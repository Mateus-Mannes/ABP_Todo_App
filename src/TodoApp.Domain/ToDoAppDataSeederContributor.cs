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
                        Text = "Levar o Lixo",
                        CurrentUserId = new Guid("7EF34F1C-C316-970C-2B49-3A02E52A79B3") 
                    },
                    autoSave: true
                );

                await _toDoItemRepository.InsertAsync(
                    new ToDoItem
                    {
                        Text = "Fazer trabalho",
                        CurrentUserId = new Guid("7EF34F1C-C316-970C-2B49-3A02E52A79B3")
                    },
                    autoSave: true
                );
            }
        }
    }
}
