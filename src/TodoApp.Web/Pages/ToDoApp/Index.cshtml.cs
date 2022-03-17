using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TodoApp.ToDoApp;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoApp.Web.Pages;

namespace TodoApp.Web.Pages.ToDoApp
{
    public class IndexModel : TodoAppPageModel
    {
        public List<ToDoItemDto> ToDoItems { get; set; }
        private readonly IToDoAppService _toDoAppService;

        public IndexModel(IToDoAppService toDoAppService)
        {
            _toDoAppService = toDoAppService;
        }

        public async Task OnGetAsync()
        {
            ToDoItems = await _toDoAppService.GetListAsync();
        }
    }
}
