$(function () {
    $('#TodoList').on('click', 'li i', function () {
        var $li = $(this).parent();
        var id = $li.attr('data-id');

        todoApp.toDoApp.toDo.delete(id).then(function () {
            $li.remove();
            abp.notify.info('Deleted the todo item');
        });
    });

    $('#NewItemForm').submit(function (e) {
        e.preventDefault();
        
        var todoText = $('#NewTextItem').val();

        todoApp.toDoApp.toDo.create(todoText).then(function (result) {
            $('<li data-id="' + result.id + '">')
                .html('<i class="fa fa-trash-o"></i> ' + result.text)
                .appendTo($('#TodoList'));
            $('#NewTextItem').val('');
        });
    });
});