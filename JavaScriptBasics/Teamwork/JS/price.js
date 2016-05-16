
var Price = (function () {
    function Price(x, y, name) {
        this.type = name;
        this.position = new Vector2(x, y);
        this.width = 64;
        this.height = 64;
        this.resizeIndex = 2;

        switch(this.type) {
            case 'money': this.animation = new Animation(this.width,this.height,0,0,32,
                'resources/gold_coin.png',12,0,0,this.resizeIndex);
                this.boundingBox = new Rectangle(x, y, this.width/this.resizeIndex, this.height/this.resizeIndex);
                break;
            case 'bomb':
                this.position.x = this.position.x+15;
                this.position.y = this.position.y+15;
                this.animation = new Animation( 81, 81, 4, 0, 8, 'resources/bombPrice.png', 5, 8, 4, this.resizeIndex-1);
                this.boundingBox = new Rectangle(this.position.x, this.position.y, 81/this.resizeIndex +10, 81/this.resizeIndex +10);
                break;
            case 'rpg':
                this.position.x = this.position.x+15;
                this.position.y = this.position.y+15;
                this.animation = new Animation( 81, 81, 5, 0, 8, 'resources/bombPrice.png', 5, 8, 5, this.resizeIndex-1);
                this.boundingBox = new Rectangle(this.position.x, this.position.y, 81/this.resizeIndex +10, 81/this.resizeIndex +10);
                break;
            default : break;
        }
    }

    Price.prototype.update = function () {

        this.animation.position.set(this.position.x, this.position.y);
        if(this.type === 'bomb' || this.type === 'rpg') {
            this.boundingBox.x = this.position.x+15;
            this.boundingBox.y = this.position.y+15;
        } else {
            this.boundingBox.x = this.position.x;
            this.boundingBox.y = this.position.y;
        }

        this.animation.update();
    };

    Price.prototype.render = function(ctx) {
        this.animation.draw(ctx);
    };

    return Price;
}());
