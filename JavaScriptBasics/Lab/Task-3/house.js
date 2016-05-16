var canvas = document.getElementById('canvas');
var ctx = canvas.getContext('2d');

//body rect
ctx.beginPath();
ctx.rect(300, 300, 300, 250);
ctx.fillStyle = '#FFCC66';
ctx.strokeStyle = 'brown';
ctx.lineWidth = 2;
ctx.fill();
ctx.stroke();

//roof
ctx.beginPath();
ctx.moveTo(280, 300);
ctx.lineTo(620, 300);
ctx.lineTo(450, 100);
ctx.closePath();
ctx.fillStyle = 'brown';
ctx.strokeStyle = 'black';
ctx.fill();
ctx.stroke();

//chimney
ctx.beginPath();
ctx.rect(520, 150, 30, 90);
ctx.fill();
//left
ctx.beginPath();
ctx.moveTo(520, 150);
ctx.lineTo(520, 240);
ctx.stroke();
//right
ctx.beginPath();
ctx.moveTo(550, 150);
ctx.lineTo(550, 240);
ctx.stroke();
//top
ctx.save();
ctx.scale(1, 0.5);
ctx.beginPath();
ctx.arc(535, 300, 15, 0, Math.PI*2);
ctx.fillStyle = 'black';
ctx.fill();
ctx.stroke();
ctx.restore();

//door
ctx.beginPath();
ctx.moveTo(340, 550);
ctx.lineTo(340, 450);
ctx.bezierCurveTo(340, 422, 440, 422, 440, 450);
ctx.lineTo(440, 550);
ctx.closePath();
ctx.fillStyle = '#FFCC66';
ctx.strokeStyle = 'brown';
ctx.fill();
ctx.stroke();

//door middle line
ctx.beginPath();
ctx.moveTo(390, 430);
ctx.lineTo(390, 550);
ctx.strokeStyle = 'brown';
ctx.stroke();

//handel left
ctx.beginPath();
ctx.arc(380, 500, 5, 0, Math.PI*2);
ctx.fill();
ctx.stroke();

//handel right
ctx.beginPath();
ctx.arc(400, 500, 5, 0, Math.PI*2);
ctx.fill();
ctx.stroke();

//window 1
ctx.beginPath();
ctx.rect(340, 320, 80, 80);
ctx.fillStyle = 'brown';
ctx.fill();

ctx.beginPath();
ctx.moveTo(340, 360);
ctx.lineTo(420, 360);
ctx.strokeStyle = '#FFCC66';
ctx.lineWidth = 4;
ctx.stroke();

ctx.beginPath();
ctx.moveTo(380, 320);
ctx.lineTo(380, 400);
ctx.strokeStyle = '#FFCC66';
ctx.lineWidth = 4;
ctx.stroke();

//window 2
ctx.beginPath();
ctx.rect(480, 320, 80, 80);
ctx.fillStyle = 'brown';
ctx.fill();

ctx.beginPath();
ctx.moveTo(480, 360);
ctx.lineTo(560, 360);
ctx.strokeStyle = '#FFCC66';
ctx.lineWidth = 4;
ctx.stroke();

ctx.beginPath();
ctx.moveTo(520, 320);
ctx.lineTo(520, 440);
ctx.strokeStyle = '#FFCC66';
ctx.lineWidth = 4;
ctx.stroke();

//window 3
ctx.beginPath();
ctx.rect(480, 440, 80, 80);
ctx.fillStyle = 'brown';
ctx.fill();

ctx.beginPath();
ctx.moveTo(480, 480);
ctx.lineTo(560, 480);
ctx.strokeStyle = '#FFCC66';
ctx.lineWidth = 4;
ctx.stroke();

ctx.beginPath();
ctx.moveTo(520, 440);
ctx.lineTo(520, 520);
ctx.strokeStyle = '#FFCC66';
ctx.lineWidth = 4;
ctx.stroke();
