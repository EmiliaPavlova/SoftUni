/**
 * Created by toshiba on 28.3.2015 г..
 */
//Method for generating different elements(container)
function generatePlayer() {
    var player1 = new Player(canvas.width/4, 1,0);
    return player1
}
function generatePrices(type) {
    var posX = randomNumInRange(20,canvas.width -50);
    var posY = randomNumInRange(20,canvas.height - 50)

    switch (type) {
        case 'money' :
            var price = new Price(posX,posY,type);
            moneyArr.push(price); break
        case 'bomb' :
            var price = new Price(posX,posY,type);
            bombArr.push(price); break;
        case 'rpg' :
            var price = new Price(posX,posY,type);
            rpgArr.push(price); break;
        default : break;
    }
}

function deployBomb(posX,posY,bombDeployTime) {
    var bomb = new DepElements(posX,posY,bombDeployTime,'bomb');
    //var bomb = new Price(posX,posY,'money');

    deployedBombs.push(bomb);
}
function deployRpg(posX,posY,bombDeployTime,movement) {
    var rpg = new DepElements(posX,posY,bombDeployTime,'rpg',movement);
    deployedRpg.push(rpg);
}
function deployedExplosion(posX,posY,explDeployTime) {
    var explosion = new DepElements(posX,posY,explDeployTime,'explosion');
    //var bomb = new Price(posX,posY,'money');
    explosionsArr.push(explosion);
}
function deployRunoverPic(posX,posY,bombDeployTime) {
    var pic = new DepElements(posX,posY,bombDeployTime,'runoverPic');
    runOverPicArr.push(pic);
}
function deployDoorPic(posX,posY,bombDeployTime) {
    var door = new DepElements(posX,posY,bombDeployTime,'exitDoor');
    exitDoor.push(door);
}


function generateCars(){

    if(carsArrRight.length < 55 && getDiffInTime(previousTimeRightCar) >= gameDifficulty) {
        do {
            var rand = randomNumInRange(0,5)
        } while(rand == prevRightCarRow);
        var posY = positionY[Math.floor(Math.random()*positionY.length)];
        prevRightCarRow = rand;
        carsArrRight.push(new Car(1, posY,'right'));
        previousTimeRightCar = Date.now();
    }
    if(carsArrLeft.length < 55 && getDiffInTime(previousTimeLeftCar) >= gameDifficulty) {
        do {
            var rand = randomNumInRange(0,5)
        } while(rand == prevLeftCarRow);
        var posY = positionY[Math.floor(Math.random()*positionY.length)];
        prevLeftCarRow = rand;
        carsArrLeft.push(new Car(canvas.width-50, posY,'left'));
        previousTimeLeftCar = Date.now();
    }
    if(carsArrUp.length < 4 && getDiffInTime(previousTimeUpCar) >= gameDifficulty*1.5) {
        do {
            var rand = randomNumInRange(0,2)
        } while(rand == prevUpCarRow);
        var posX = canvas.width/2 - 35 * rand;
        prevUpCarRow = rand;
        carsArrUp.push(new Car(posX, canvas.height,'up'));
        previousTimeUpCar = Date.now();
    }
}


function randomNumInRange(min,max) {
    var randNum =  Math.floor(Math.random() * (max - min +1)) + min;
    return randNum;
}

function setGameDifficulty(difficulty) {
    gameDifficulty = parseFloat(difficulty);
}