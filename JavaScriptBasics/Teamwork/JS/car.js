var Car = (function () {
    function Car(x, y, movementPosition) {
        this.position = new Vector2(x, y);
        this.width = 35.7;
        this.height = 17.9;
        this.velocity = 3;
        this.velocityModifierX = 1;
        this.velocityModifierY = 1;
        this.movement = {left: false, right : false, up: false, down : false};
        switch (movementPosition) {
            case 'right': this.movement.right = true; break;
            case 'left': this.movement.left = true; break;
            case 'up': this.movement.up = true; break;
            case 'down': this.movement.down = true; break;
            default : break;
        }
        this.resizeIndex = 1;

        var rowCars = randomCar(18),
            colCars = randomCar(6);
        this.animationR = new Animation(this.width, this.height, rowCars, colCars, 1, 'resources/cars-right.png', 1, 1, 1, this.resizeIndex);
        this.animationL = new Animation(this.width, this.height, rowCars, colCars, 1, 'resources/cars-left.png', 1, 1, 1, this.resizeIndex);
        var rowCarsU = randomCar(6),
            colCarsU = randomCar(18);
        this.animationU = new Animation(this.height, this.width, rowCarsU, colCarsU, 1, 'resources/cars-up.png', 1, 1, 1, this.resizeIndex);

        function randomCar(position) {
            var randCar =  Math.floor(Math.random() * position);
            return randCar;
        }

        this.boundingBox = new Rectangle(x, y, this.width/this.resizeIndex, this.height/this.resizeIndex);
    }

    Car.prototype.update = function () {
        if(this.movement.right ) {
            this.position.x += this.velocity * this.velocityModifierX;
        }
        if(this.movement.left ) {
            this.position.x -= (this.velocity * this.velocityModifierX);
        }
        //if(this.movement.down) {
        //    this.position.y += (this.velocity - 2) * this.velocityModifierY;
        //}
        if(this.movement.up) {
            this.position.y -= this.velocity;
        }

        this.animationR.position.set(this.position.x, this.position.y);
        this.animationL.position.set(this.position.x, this.position.y);
        this.animationU.position.set(this.position.x, this.position.y);
        this.boundingBox.x = this.position.x;
        this.boundingBox.y = this.position.y;
        this.animationR.update();
        this.animationU.update();
    };

    Car.prototype.render = function(ctx) {
        this.animationR.draw(ctx);
    };
    Car.prototype.renderL = function(ctx) {
        this.animationL.draw(ctx);
    };
    Car.prototype.renderU = function(ctx) {
        this.animationU.draw(ctx);
    };

    return Car;
}());
