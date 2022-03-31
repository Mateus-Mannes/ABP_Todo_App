using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Identity;

namespace TodoApp.ToDoApp
{
    public class ToDoItem : BasicAggregateRoot<Guid>
    {
        public string Text { get; set; }
        public Guid? CurrentUserId { get; set; } 
    }
}
