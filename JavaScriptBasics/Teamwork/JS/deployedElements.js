/**
 * Created by toshiba on 30.3.2015 г..
 */
    //this ""class" deploys bombs and explosions in canvas scene
var DepElements = (function () {
    function DepElemts(x, y, bombDeployTime, name, movement) {
        this.type = name;
        this.position = new Vector2(x, y);
        this.width = 75;
        this.height = 75;
        this.velocity = 7;
        this.movement = {left: false, right : false, up: false, down: false};
        this.count = 0;
        this.bombDeployTime = bombDeployTime;
        this.resizeIndex = 1;

        switch(movement) {
            case 'left' : this.movement.left = true; break;
            case 'right' : this.movement.right = true; break;
            case 'down' : this.movement.down = true; break;
            case 'up' : this.movement.up = true; break;
            default : break;
        }

        switch(this.type) {
            case 'bomb': this.animation = new Animation(75,75,0,0,48,'resources/bomb.png',12,0,0,this.resizeIndex);
                this.boundingBox = new Rectangle(x-75, y-75, this.width+150, this.height+150);
                break;
            case 'explosion':  this.animation = new Animation(64,64,0,0,16,
                'resources/explosion.png',7,0,0,this.resizeIndex-0.5);
                this.boundingBox = new Rectangle(x, y, 75/this.resizeIndex, 75/this.resizeIndex);
                break;
            case 'rpg': this.animation = new Animation(64,64,0,0,1,'resources/rpgShot.png',12,0,0,this.resizeIndex);
                this.width = 64;
                this.height = 64;
                this.boundingBox = new Rectangle(x+15, y+15, this.width-30, this.height-30);
                break;
            case 'runoverPic' :
                this.resizeIndex = 3;
                this.animation = new Animation(460,322,0,0,1,'resources/runOver.png',1,0,0,this.resizeIndex);
                this.boundingBox = new Rectangle(this.position.x, this.position.y, this.width, this.height);
                break;
            case 'exitDoor' :
                this.resizeIndex = 6;
                this.animation = new Animation(529,616,0,0,1,'resources/door.png',1,0,0,this.resizeIndex);
                this.boundingBox = new Rectangle(this.position.x, this.position.y, this.width, this.height + 30);
                break;
            default : break;
        }

    }

    DepElemts.prototype.update = function () {
        if(this.type == 'rpg') {
            if(this.movement.right ) {
                this.position.x += this.velocity;
            }
            if(this.movement.left ) {
                this.position.x -= this.velocity;
            }
            if(this.movement.down) {
                this.position.y += this.velocity;
            }
            if(this.movement.up) {
                this.position.y -= this.velocity;
            }
            this.animation.position.set(this.position.x, this.position.y);
            this.boundingBox.x = this.position.x+15;
            this.boundingBox.y = this.position.y+15;
            this.animation.update();
        }


        if(this.type !== 'rpg') {
            this.animation.position.set(this.position.x, this.position.y);
            this.boundingBox.x = this.position.x - 75;
            this.boundingBox.y = this.position.y - 75;
            this.animation.update();
        }
        if(this.type == 'exitDoor') {
            this.animation.position.set(this.position.x, this.position.y);
            this.boundingBox.x = this.position.x;
            this.boundingBox.y = this.position.y;
            this.animation.update();
        }


    };

    DepElemts.prototype.render = function(ctx) {
        this.animation.draw(ctx);
    };

    return DepElemts;
}());
