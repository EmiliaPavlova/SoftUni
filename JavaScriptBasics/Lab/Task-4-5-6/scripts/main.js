var canvas = document.getElementById('canvas');
var ctx = canvas.getContext('2d');

//ctx.fillStyle = '#FFFFB8';
ctx.strokeStyle = '#7A995C';
ctx.lineWidth = 2;
//ctx.fillRect(0, 0, canvas.clientWidth, canvas.clientHeight);
ctx.strokeRect(0, 0, canvas.clientWidth, canvas.clientHeight);

var input = new Input();
attachListeners(input);

var player1 = new Player(canvas.width / 2, 1, 0);
var player2 = new Player(canvas.width / 2, canvas.height - 50, 1);
document.getElementById('player1scores').innerText = player1.score;
document.getElementById('player2scores').innerText = player2.score;

var startRange = 300;
var endRange = canvas.height - startRange;
var startX = Math.floor(Math.random() * canvas.width);
var startY = randomNumInRange(startRange,endRange);
var ball = new Ball(startX, startY);

if(startY < canvas.height / 2) {
    ball.movement.down = true;
    var randomBall = Math.floor(Math.random() * 2);
    if(randomBall === 1) {
        ball.movement.left = true;
    } else {
        ball.movement.right = true;
    }
} else {
    ball.movement.up = true;
    var randomBall = Math.floor(Math.random() * 2);
    if(randomBall === 1) {
        ball.movement.left = true;
    }else {
        ball.movement.right = true;
    }
}

var collision = document.getElementById("collide");
var previousTime = Date.now();
var previousHit;

function update() {
    this.tick();
    this.render(ctx);
    requestAnimationFrame(update);
}

function tick() {
    movePlayer();

    if(ball.position.x +  ball.width >= canvas.width || ball.position.x <= 0) {
        ball.velocityModifierX *= -1;
    }
    if(player1.boundingBox.intersects(ball.boundingBox) && previousHit !== 'player1') {
        ball.velocityModifierY *= -1;
        previousHit = 'player1';
        collision.currentTime = 0;
        collision.play();
    }
    if(player2.boundingBox.intersects(ball.boundingBox) && previousHit !== 'player2') {
        ball.velocityModifierY *= -1;
        previousHit = 'player2';
        collision.currentTime = 0;
        collision.play();
    }
    if(ball.position.y + ball.height / 2 >= canvas.height) {
        player1.score += 1;
        document.getElementById('player1scores').innerText = player1.score;
        if(player1.score === 10) {
            gameOver();
            document.getElementById('gameOver').innerText = 'gameOver';
        }
        refresh();
    }
    if(ball.position.y <= 0) {
        player2.score += 1;
        document.getElementById('player2scores').innerText = player2.score;
        if(player2.score === 10) {
            gameOver();
            document.getElementById('gameOver').innerText = 'gameOver';
        }
        refresh();
    }

    ball.update();
    player1.update();
    player2.update();
}

function gameOver() {
    ctx.fillStyle = '#BE4874';
    ctx.strokeStyle = '#5F293C';
    ctx.lineWidth = 3;
    ctx.font = '80px Arial, sans-serif';
    ctx.textAlign = 'center';
    ctx.textBaseline = 'middle';
    ctx.fillText('Game Over', canvas.width / 2, canvas.height / 2);
    ctx.strokeText('Game Over', canvas.width / 2, canvas.height / 2);
}

function render(ctx) {
    ctx.clearRect(0, 0, canvas.width, canvas.height);
    player1.render(ctx);
    player2.render(ctx);
    ball.render(ctx);
}

function movePlayer() {
    player1.movement.right = !!input.right;
    player1.movement.left = !!input.left;
    player2.movement.right = !!input.right;
    player2.movement.left = !!input.left;
}

function refresh(){
    startRange,
    endRange,
    startX,
    startY;
    ball.position.x = startX;
    ball.position.y = startY;
    ball.movement.left = false;
    ball.movement.right = false;
    ball.movement.down = false;
    ball.movement.up = false;
    if(startY < canvas.height / 2) {
        ball.movement.down = true;
        var randomBall = Math.floor(Math.random() * 2);
        if(randomBall === 1) {
            ball.movement.left = true;
        }else {
            ball.movement.right = true;
        }
    } else {
        ball.movement.up = true;
        var randomBall = Math.floor(Math.random() * 2);
        if(randomBall === 1) {
            ball.movement.left = true;
        }else {
            ball.movement.right = true;
        }
    }
}

function randomNumInRange(min, max) {
    var num =  Math.floor(Math.random() * (max - min + 1)) + min;
    return num;
}

update();
