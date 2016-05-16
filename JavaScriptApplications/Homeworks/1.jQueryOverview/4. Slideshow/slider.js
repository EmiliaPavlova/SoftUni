var slideCount = $('#slider ul li').length;
var slideWidth = $('#slider ul li').width();
var slideHeight = $('#slider ul li').height();

$('#slider').css({ width: slideWidth, height: slideHeight });

$('#slider ul li:last-child').prependTo('#slider ul');

function moveLeft() {
    $('#slider ul').animate({
        left: + slideWidth
    }, 200, function () {
        $('#slider ul li:last-child').prependTo('#slider ul');
        $('#slider ul').css('left', '');
    });
};

function moveRight() {
    $('#slider ul').animate({
        left: - slideWidth
    }, 200, function () {
        $('#slider ul li:first-child').appendTo('#slider ul');
        $('#slider ul').css('left', '');
    });
};

$('a.control_prev').click(function () {
    moveLeft();
});

$('a.control_next').click(function () {
    moveRight();
});


// autoslide
$('#checkbox').change(function(){
    setInterval(function () {
        moveRight();
    }, 5000);
});
