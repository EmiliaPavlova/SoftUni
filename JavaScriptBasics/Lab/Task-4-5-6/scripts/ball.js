var Ball = (function() {
    function Ball(x, y) {
        this.position = new Vector2(x, y);
        this.movement = {left: false, right: false, up: false, down: false};
        this.width = 29;
        this.height = 30;
        this.velocity = 4;
        this.velocityModifierX = 2;
        this.velocityModifierY = 2;
        this.animation = new Animation(this.width, this.height, 0, 0, 1, 'images/ball.PNG', 1, 1, 1);
        this.boundingBox = new Rectangle(x, y, this.width, this.height);
    }

    Ball.prototype.update = function() {
        if (this.movement.right) {
            this.position.x += this.velocity * this.velocityModifierX;
        }
        if (this.movement.left) {
            this.position.x -= this.velocity * this.velocityModifierX;
        }
        if (this.movement.up) {
            this.position.y += this.velocity * this.velocityModifierY;
        }
        if (this.movement.down) {
            this.position.y -= this.velocity * this.velocityModifierY;
        }
        this.animation.position.set(this.position.x, this.position.y);
        this.boundingBox.x = this.position.x;
        this.boundingBox.y = this.position.y;
        this.animation.update();
    }

    Ball.prototype.render = function(ctx) {
        this.animation.draw(ctx);
    }

    return Ball;
}());
