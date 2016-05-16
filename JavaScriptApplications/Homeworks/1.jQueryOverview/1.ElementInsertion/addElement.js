$('#addBefore').on('click', function(){
    $('<li  style="color: lightseagreen">Added</li>').prependTo('ul');
});

$('#addAfter').on('click', function(){
    $('<li style="color: indigo">Added</li>').appendTo('ul');
});