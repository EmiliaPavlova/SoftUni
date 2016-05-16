$('button').on('click', function () {
    var selectedLi = $('#className').val();
    var changeColor = $('#color').val();
    $('.' + selectedLi).css('background', changeColor);
});
