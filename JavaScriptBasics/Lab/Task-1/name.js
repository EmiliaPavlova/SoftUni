var canvas = document.getElementById('canvas');
var ctx = canvas.getContext('2d');
var name = 'Emilu';
ctx.fillStyle = 'yellow';
ctx.font = '100px Arial';
ctx.strokeStyle = 'orange';
ctx.lineWidth = 5;
ctx.strokeText(name, 300, 100);
ctx.fillText(name, 300, 100);
