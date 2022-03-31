using TodoApp.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace TodoApp.Permissions;

public class TodoAppPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var toDoAppGroup = context.AddGroup(TodoAppPermissions.GroupName, L("Permission:ToDoApp") );
        //Define your own permissions here. Example:
        var toDoItemsPermission = toDoAppGroup.AddPermission(TodoAppPermissions.ToDoItems.Default, L("Permission:ToDoApp"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<TodoAppResource>(name);
    }
}
