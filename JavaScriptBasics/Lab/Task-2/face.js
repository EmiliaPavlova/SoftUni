var canvas = document.getElementById('canvas');
var ctx = canvas.getContext('2d');
ctx.beginPath();
ctx.arc(350, 300, 100, 0,2 * Math.PI);
ctx.fillStyle = '#FF9966';
ctx.strokeStyle = 'brown';
ctx.fill();
ctx.stroke();

//right eye
ctx.save();
ctx.scale(1, 0.75);
ctx.beginPath();
ctx.arc(310, 350, 20, 0, Math.PI*2);
ctx.fillStyle = 'white';
ctx.fill();
ctx.stroke();

//left eye
ctx.beginPath();
ctx.arc(390, 350, 20, 0, Math.PI*2);
ctx.fillStyle = 'white';
ctx.fill();
ctx.stroke();
ctx.restore();

//right pupil
ctx.save();
ctx.scale(0.5, 0.75);
ctx.beginPath();
ctx.arc(610, 350, 18, 0, Math.PI*2);
ctx.fillStyle = 'black';
ctx.fill();

//left pupil
ctx.beginPath();
ctx.arc(770, 350, 18, 0, Math.PI*2);
ctx.fillStyle = 'black';
ctx.fill();
ctx.restore();

//eye light left
ctx.beginPath();
ctx.arc(308, 256, 4, 0, Math.PI*2);
ctx.fillStyle = 'white';
ctx.fill();

//eye light right
ctx.beginPath();
ctx.arc(388, 256, 4, 0, Math.PI*2);
ctx.fillStyle = 'white';
ctx.fill();
//nose
ctx.beginPath();
ctx.moveTo(345, 290);
ctx.lineTo(330, 320);
ctx.lineTo(345, 320);
ctx.strokeStyle = 'brown';
ctx.lineWidth = 2;
ctx.stroke();

//mouth
ctx.beginPath();
ctx.arc(340, 310, 50, 35*Math.PI/180, 125*Math.PI/180);
ctx.closePath();
ctx.strokeStyle = 'brown';
ctx.fillStyle = '#CC0000';
ctx.fill();
ctx.stroke();

//hat bottom
ctx.save();
ctx.scale(1, 0.25);
ctx.beginPath();
ctx.arc(350, 800, 120, 0, Math.PI*2);
ctx.fillStyle = '#006666';
ctx.strokeStyle = 'black';
ctx.fill();
ctx.stroke();
ctx.restore();

//hat body
ctx.beginPath();
ctx.moveTo(300, 90);
ctx.lineTo(300, 200);
ctx.bezierCurveTo(300, 220, 400, 220, 400, 200);
ctx.lineTo(400, 90);
ctx.closePath();
ctx.fillStyle = '#006666';
ctx.strokeStyle = 'black';
ctx.lineWidth = 1;
ctx.fill();
ctx.stroke();

//hat top
ctx.save();
ctx.scale(1, 0.25);
ctx.beginPath();
ctx.arc(350, 360, 50, 0, Math.PI*2);
ctx.fillStyle = '#006666';
ctx.strokeStyle = 'black';
ctx.lineWidth = 2;
ctx.fill();
ctx.stroke();
ctx.restore();