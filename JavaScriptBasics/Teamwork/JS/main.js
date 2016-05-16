var canvas = document.getElementById('canvas');
var ctx = canvas.getContext('2d');
var previousTime = Date.now();
var previousTimeRightCar = Date.now();
var previousTimeLeftCar = Date.now();
var previousTimeUpCar = Date.now();
var previousTimeHornPushed = Date.now();

var input = new Input();
attachListeners(input);

var player1 = generatePlayer();

var button = document.getElementById('hide');
var buttonClose = document.getElementById("close");
var buttonInstructions = document.getElementById("instructions-btn");
var runOverPicArr = [];
var exitDoor = [];
var carsArrRight = [];
var carsArrLeft = [];
var carsArrUp = [];
var moneyArr = [];
var positionY = [24,45,66,118,140,162,256,278,300,356,381,406,493,518,543,601,627,653];
var prevRightCarRow;
var prevLeftCarRow;
var prevUpCarRow;
var isGameOver = true;
var gameDifficulty = 2;
var bombArr = [];
var rpgArr = [];
var deployedBombs = [];
var deployedRpg = [];
var explosionsArr = [];
var prevBombGenTime = Date.now();
var prevRpgGenTime = Date.now();
var prevRpgShooted = Date.now();
var isBombDeployed = false;
var isRgpDeployed = false;
var movement;

button.onclick = function() {
    var div = document.getElementById('new-game');
    var divInstructions = document.getElementById('instructions');
    if (div.style.display !== 'none') {
        div.style.display = 'none';
        divInstructions.style.display = 'none';
        isGameOver = false;
    }
    else {
        div.style.display = 'block';
        isGameOver = true;
    }
};

buttonClose.addEventListener('click', function () {
    var div = document.getElementById('instructions');
   if(div.style.zIndex == '6') {
       div.style.zIndex = '4';
   }
}, false);

buttonInstructions.addEventListener('click', function () {
    console.log('buttonInstructions');
    var div = document.getElementById('instructions');
    if(div.style.zIndex <= '5') {
        div.style.zIndex = '6';
    }
}, false);




// Initialise sounds
var carHorn1 = document.getElementById("car-horn1");
var carCrash = document.getElementById("car-crash");
var coinSound = document.getElementById("coin-sound");
var explosionSound = document.getElementById("explosion");
var scream = document.getElementById("scream");


function update() {
    if(!isGameOver) {
        this.tick();
    }
    this.render(ctx);
    requestAnimationFrame(update);
}

function tick() {
    movePlayer();
    generateCars();
    switch (gameDifficulty) {
        case 3: if(player1.scores >= 100 && exitDoor < 1){
            deployDoorPic(canvas.width/2 - 30, canvas.height/2 - 50, Date.now());
        } break;
        case 1.5: if(player1.scores >= 2000 && exitDoor < 1){
            deployDoorPic(canvas.width/2 - 30, canvas.height/2 - 50, Date.now());
        } break;
        case 1: if(player1.scores >= 5000 && exitDoor < 1){
            deployDoorPic(canvas.width/2 - 30, canvas.height/2 - 50, Date.now());
        } break;
        case 0.5: if(player1.scores >= 10000 && exitDoor < 1){
            deployDoorPic(canvas.width/2 - 30, canvas.height/2 - 50, Date.now());
        } break;
        default:  break;

    }
    modifyCarSpeed();
    if(isBombDeployed && (player1.bomb > 0)) {
        deployBomb(player1.position.x, player1.position.y,Date.now());
        prevBombGenTime = Date.now();
        player1.bomb--;
        isBombDeployed = false;
    }

    if(isRgpDeployed && (player1.rpg > 0) && getDiffInTime(prevRpgShooted) > 1) {
        deployRpg(player1.position.x, player1.position.y,Date.now(),movement);
        prevRpgShooted = Date.now();
        player1.rpg--;
        isRgpDeployed = false;
    }

    //check for collision between cars and player. Delete cars after leaving canvas and make new car in the beginning of the canvas scene
    carsArrRight.forEach(function(car){
        if(car.position.x +  car.width >= canvas.width) {
            carsArrRight.removeAt(carsArrRight.indexOf(car));
            generateCars();
        }

        if(player1.boundingBox.intersects(car.boundingBox)) {
            car.position.x -= (car.velocity + 1);
            if(!isGameOver){
                deployRunoverPic(player1.position.x,player1.position.y);
                scream.volume = 1;
                scream.play();
                isGameOver = true;
                carCrash.volume = 0.9;
                carCrash.play();
                var timeOut = setTimeout(gameOver,2000);
            }
        }
        carsArrUp.forEach(function(carUp){
            if(car.boundingBox.intersects(carUp.boundingBox)) {
                carUp.position.y += (carUp.velocity + 1);
                if(!isGameOver){
                    //carHorn1.currentTime = 0;
                    if(getDiffInTime(previousTimeHornPushed) > 0.5) {
                        carHorn1.volume = 0.5;
                        carHorn1.play();
                        previousTimeHornPushed = Date.now();
                    }
                }
            }
            //carUp.update();
        });
        deployedRpg.forEach(function(rpg){
            if(car.boundingBox.intersects(rpg.boundingBox)){
                deployedExplosion(car.position.x,car.position.y,Date.now());
                carsArrRight.removeAt(carsArrRight.indexOf(car));
                deployedRpg.removeAt(deployedRpg.indexOf(rpg));
                explosionSound.volume = 1;
                explosionSound.play();
                player1.scores += 50;
            }
        });
        car.update();
    });

    carsArrLeft.forEach(function(car){
        if(car.position.x <= 0) {
            carsArrLeft.removeAt(carsArrLeft.indexOf(car));
            generateCars();
        }

        if(player1.boundingBox.intersects(car.boundingBox)) {
            car.position.x += (car.velocity + 1);
            if(!isGameOver){
                deployRunoverPic(player1.position.x,player1.position.y);
                scream.volume = 1;
                scream.play();
                isGameOver = true;
                carCrash.volume = 0.9;
                carCrash.play();
                var timeOut = setTimeout(gameOver,2000);
            }
        }
        carsArrUp.forEach(function(carUp){
            if(car.boundingBox.intersects(carUp.boundingBox)) {
                carUp.position.y += (carUp.velocity + 1);
                if(!isGameOver){
                    //carHorn1.currentTime = 0;
                    if(getDiffInTime(previousTimeHornPushed) > 0.5) {
                        carHorn1.volume = 0.5;
                        carHorn1.play();
                        previousTimeHornPushed = Date.now();
                    }
                }
            }
            //carUp.update();
        });
        deployedRpg.forEach(function(rpg){
            if(car.boundingBox.intersects(rpg.boundingBox)){
                deployedExplosion(car.position.x,car.position.y,Date.now());
                carsArrLeft.removeAt(carsArrLeft.indexOf(car));
                deployedRpg.removeAt(deployedRpg.indexOf(rpg));
                explosionSound.volume = 1;
                explosionSound.play();
                player1.scores += 50;
            }
        });
        car.update();
    });


    carsArrUp.forEach(function(car){
        if(car.position.y <= 0) {
            carsArrUp.removeAt(carsArrUp.indexOf(car));
            generateCars();
        }

        if(player1.boundingBox.intersects(car.boundingBox)) {
            car.position.y += (car.velocity + 1);
            if(!isGameOver){
                deployRunoverPic(player1.position.x,player1.position.y);
                scream.volume = 1;
                scream.play();
                isGameOver = true;
                carCrash.volume = 0.9;
                carCrash.play();
                var timeOut = setTimeout(gameOver,2000);
            }
        }

        carsArrLeft.forEach(function(carLeft){
            if(car.boundingBox.intersects(carLeft.boundingBox)) {
                carLeft.position.x += (carLeft.velocity * 0.5);
            }
        });
        deployedRpg.forEach(function(rpg){
            if(car.boundingBox.intersects(rpg.boundingBox)){
                deployedExplosion(car.position.x,car.position.y,Date.now());
                carsArrUp.removeAt(carsArrUp.indexOf(car));
                deployedRpg.removeAt(deployedRpg.indexOf(rpg));
                explosionSound.volume = 1;
                explosionSound.play();
                player1.scores += 50;
            }
        });
        car.update();
    });

    deployedRpg.forEach(function(rpg){
        if(rpg.position.x >= canvas.width) {
            deployedRpg.removeAt(deployedRpg.indexOf(rpg));
        } else if (rpg.position.y >= canvas.height) {
            deployedRpg.removeAt(deployedRpg.indexOf(rpg));
        } else if (rpg.position.x < 0) {
            deployedRpg.removeAt(deployedRpg.indexOf(rpg));
        } else if (rpg.position.y < 0) {
            deployedRpg.removeAt(deployedRpg.indexOf(rpg));
        }
        rpg.update();
    });

    //check for collision between player and money price
    if(moneyArr.length > 0) {
        moneyArr.forEach(function(price){
            if(price.boundingBox.intersects(player1.boundingBox)) {
                player1.scores += 50;
                moneyArr.removeAt(moneyArr.indexOf(price));
                coinSound.volume = 1;
                coinSound.play();
            }
        });
    }

    //check for collision between player and bomb price
    if(bombArr.length > 0) {
        bombArr.forEach(function(price){
            if(price.boundingBox.intersects(player1.boundingBox)) {
                player1.bomb ++;
                bombArr.removeAt(moneyArr.indexOf(price));

            }
        });
    }

    //check for collision between player and rpg price
    if(rpgArr.length > 0) {
        rpgArr.forEach(function(price){
            if(price.boundingBox.intersects(player1.boundingBox)) {
                player1.rpg ++;
                rpgArr.removeAt(rpgArr.indexOf(price));

            }
        });
    }

    //check for collision between player and door
    if(exitDoor.length > 0) {
        exitDoor.forEach(function(door){
            if(door.boundingBox.intersects(player1.boundingBox)) {
                if(!isGameOver){
                    switch (gameDifficulty) {
                        case 3: document.getElementById("p1").innerHTML = "You win!";
                        break;
                        case 1.5: document.getElementById("p1").innerHTML = "You win!";
                        break;
                        case 1: document.getElementById("p1").innerHTML = "You win!";
                        break;
                        case 0.5: document.getElementById("p1").innerHTML = "MASTER!";
                        break;
                        default:  break;
                    }
                    isGameOver = true;
                    var timeOut = setTimeout(gameOver,0);
                }
            }
        });
    }


    //update prices
    if(moneyArr.length < 1) {
        generatePrices('money');
    }
    if(moneyArr.length > 0) {
        moneyArr.forEach(function(price){
            price.update()
        });
    }

    //update bomb price
    if((bombArr.length < 1) && (player1.bomb < 1 ) && (getDiffInTime(prevBombGenTime) >= 10 )) {
        generatePrices('bomb');
    }

    if(bombArr.length > 0) {
        bombArr.forEach(function(price){
            price.update()
        });
    }

    //update rpg price
    if((rpgArr.length < 1) && (player1.rpg < 5 ) && (getDiffInTime(prevRpgGenTime) >= randomNumInRange(15,55))) {
        generatePrices('rpg');
        prevRpgGenTime = Date.now();
    }
    if(rpgArr.length > 0) {
        rpgArr.forEach(function(price){
            price.update()
        });
    }




    //update deployed bomb
    if(deployedBombs.length > 0) {
        deployedBombs.forEach(function(bomb){
            bomb.count ++ ;

            //bomb explode
            if(bomb.count > 200) {
                explosionSound.currentTime = 0;
                explosionSound.volume = 1;
                explosionSound.play();
                deployedExplosion(bomb.position.x,bomb.position.y,Date.now());
                deployedBombs.removeAt(deployedBombs.indexOf(bomb));

                //check if explosion interact with something
                if(bomb.boundingBox.intersects(player1.boundingBox)) {
                    isGameOver = true;
                    var timeOut = setTimeout(gameOver,100);
                }

                carsArrRight.forEach(function(car){
                    if(bomb.boundingBox.intersects(car.boundingBox)) {
                        deployedExplosion(car.position.x,car.position.y,Date.now());
                        carsArrRight.removeAt(carsArrRight.indexOf(car));
                        player1.scores += 50;
                    }
                });

                carsArrLeft.forEach(function(car){
                    if(bomb.boundingBox.intersects(car.boundingBox)) {
                        deployedExplosion(car.position.x,car.position.y,Date.now());
                        carsArrLeft.removeAt(carsArrLeft.indexOf(car));
                        player1.scores += 50;

                    }
                });
                carsArrUp.forEach(function(car){
                    if(bomb.boundingBox.intersects(car.boundingBox)) {
                        deployedExplosion(car.position.x,car.position.y,Date.now());
                        carsArrUp.removeAt(carsArrUp.indexOf(car));
                        player1.scores += 50;
                    }
                });
            }
            bomb.update()
        });
    }

    //update explosions
    if(explosionsArr.length > 0) {
        explosionsArr.forEach(function(explosion){
            explosion.count ++ ;
            if(explosion.count > 70) {
                explosionsArr.removeAt(explosionsArr.indexOf(explosion));
            }
            explosion.update()
        });
    }

    //update runOverPic
    if(runOverPicArr.length > 0) {
        runOverPicArr.forEach(function(pic){
            pic.update()
        });
    }

    if(exitDoor.length > 0) {
        exitDoor.forEach(function(pic){
            pic.update()
        });
    }

    player1.update();
    document.getElementById('scores').innerText = 'Scores: ' + player1.scores;
    document.getElementById('bombs-quantity').innerText = 'Bombs: ' + player1.bomb;
    document.getElementById('rpg-quantity').innerText = 'Rpg: ' + player1.rpg;


}


function render(ctx) {
    ctx.clearRect(0, 0, canvas.width, canvas.height);
    //draw player
    if(!isGameOver){
        player1.render(ctx);
        //ctx.strokeRect(player1.boundingBox.x, player1.boundingBox.y, player1.boundingBox.width, player1.boundingBox.height);
    }

    //draw cars
    carsArrRight.forEach(function(car){
        car.render(ctx);
        //ctx.strokeRect(car.boundingBox.x, car.boundingBox.y, car.boundingBox.width, car.boundingBox.height);
    });
    carsArrLeft.forEach(function(car){
        car.renderL(ctx);
        //ctx.strokeRect(car.boundingBox.x, car.boundingBox.y, car.boundingBox.width, car.boundingBox.height);
    });
    carsArrUp.forEach(function(car){
        car.renderU(ctx);
        //ctx.strokeRect(car.boundingBox.x, car.boundingBox.y, car.boundingBox.width, car.boundingBox.height);
    });


    //draw prices
    if(moneyArr.length > 0) {
        moneyArr.forEach(function(elem){
            elem.render(ctx);
            //ctx.strokeRect(elem.boundingBox.x, elem.boundingBox.y, elem.boundingBox.width, elem.boundingBox.height);
        });
    }

    //draw bomb price
    if(bombArr.length > 0) {
        bombArr.forEach(function(elem){
            elem.render(ctx);
            //ctx.strokeRect(elem.boundingBox.x, elem.boundingBox.y, elem.boundingBox.width, elem.boundingBox.height);
        });
    }
    //draw rpg price
    if(rpgArr.length > 0) {
        rpgArr.forEach(function(elem){
            elem.render(ctx);
            //ctx.strokeRect(elem.boundingBox.x, elem.boundingBox.y, elem.boundingBox.width, elem.boundingBox.height);
        });
    }
    //draw deplyed bomb
    if(deployedBombs.length > 0) {
        deployedBombs.forEach(function(bomb){
            bomb.render(ctx);
            //ctx.strokeRect(bomb.boundingBox.x, bomb.boundingBox.y, bomb.boundingBox.width, bomb.boundingBox.height);
        });
    }

    //draw explosions
    if(explosionsArr.length > 0) {
        explosionsArr.forEach(function(explosion){
            explosion.render(ctx);
        });
    }

    //draw rpg
    if(deployedRpg.length > 0) {
        deployedRpg.forEach(function(rpg){
            rpg.render(ctx);
            //ctx.strokeRect(rpg.boundingBox.x, rpg.boundingBox.y, rpg.boundingBox.width, rpg.boundingBox.height);
        });
    }
    //draw runoverPic
    if(runOverPicArr.length > 0) {
        runOverPicArr.forEach(function(pic){
            pic.render(ctx);
            //ctx.strokeRect(rpg.boundingBox.x, rpg.boundingBox.y, rpg.boundingBox.width, rpg.boundingBox.height);
        });
    }
    //draw doorPic
    if(exitDoor.length > 0) {
        exitDoor.forEach(function(pic){
            pic.render(ctx);
            //ctx.strokeRect(pic.boundingBox.x, pic.boundingBox.y, pic.boundingBox.width, pic.boundingBox.height);
        });
    }

}

function movePlayer() {
    player1.movement.right = !!input.right;
    player1.movement.left = !!input.left;
    player1.movement.up = !!input.up;
    player1.movement.down = !!input.down;
    isBombDeployed = !!input.b;
    isRgpDeployed = !!input.space;

    if(player1.movement.down) {
        movement = 'down';
    } else if(player1.movement.up) {
        movement = 'up';
    } else if (player1.movement.left) {
        movement = 'left';
    } else if (player1.movement.right) {
        movement = 'right';
    }
}

function getDiffInTime (prevTime) {
    var now = Date.now();
    var difference = (Math.abs(now - prevTime) / 1000);
    return difference;
}

function modifyCarSpeed() {
    var now = Date.now();
    var difference = Math.abs(now - previousTime) / 1000;
    if(difference >= 10) {
        previousTime = now;
        carsArrRight.forEach(function(car){
            car.velocityModifierX += 0.1;
        });
        carsArrLeft.forEach(function(car){
            car.velocityModifierX += 0.1;
        });
        carsArrUp.forEach(function(car){
            car.velocityModifierY += 0.1;
        });

    }
}
function gameOver() {
    player1.position.set(-30,-30);
    document.getElementById('result').innerText = 'Scores: ' + player1.scores;
    document.getElementById('game-over').style.display = 'block';
    document.getElementById('game-over-overlay').style.display = 'block';
    //isGameOver = true;
    document.getElementById('play-again').addEventListener('click', function() {
        reset();
    });
    deployedBombs.forEach(function(bomb){
        deployedBombs.removeAt(deployedBombs.indexOf(bomb));
    });
    deployedRpg.forEach(function(rpg){
        deployedRpg.removeAt(deployedRpg.indexOf(rpg));
        prevRpgShooted = Date.now();
    });
    bombArr.forEach(function(bomb){
        bombArr.removeAt(bombArr.indexOf(bomb));
        prevBombGenTime = Date.now();
    });
    rpgArr.forEach(function(rpg){
        rpgArr.removeAt(rpgArr.indexOf(rpg));
        prevRpgGenTime = Date.now();
    });
    exitDoor.forEach(function(door){
        exitDoor.removeAt(exitDoor.indexOf(door));
        prevRpgGenTime = Date.now();
    });
}

function reset() {
    runOverPic = undefined;
    document.getElementById('game-over').style.display = 'none';
    document.getElementById('game-over-overlay').style.display = 'none';
    isGameOver = false;
    document.getElementById("p1").innerHTML = "GAME OVER!";
    carsArrRight = [];
    carsArrLeft = [];
    carsArrUp = [];
    moneyArr = [];
    player1.scores = 0;
    player1.bomb = 0;
    player1.rpg = 0;
    runOverPicArr.forEach(function(pic){
        runOverPicArr.removeAt(runOverPicArr.indexOf(pic));
    });
    player1.position.x = randomNumInRange(30, canvas.width-player1.width-30);
    player1.position.y = randomNumInRange(0, canvas.height-player1.height);
}

update();
