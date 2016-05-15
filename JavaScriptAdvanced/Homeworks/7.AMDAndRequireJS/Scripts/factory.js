define(['container', 'item', 'section'], function(Container, Item, Section) {
    var toDoList = toDoList || {},
        list = toDoList._createToDoList('Tuesday TODO List'),
        body = document.body;

    list.addToDOM();
});