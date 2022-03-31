namespace TodoApp.Permissions;

public static class TodoAppPermissions
{
    public const string GroupName = "TodoApp";

    public static class ToDoItems
    {
        public const string Default = GroupName + ".ToDoApp";
    }

    //Add your own permission names. Example:
    //public const string MyPermission1 = GroupName + ".MyPermission1";
}
