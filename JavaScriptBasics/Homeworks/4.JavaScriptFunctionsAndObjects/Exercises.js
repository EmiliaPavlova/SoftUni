Array.prototype.removeItem = function(arg){
    for(var i = 0; i < this.length; i++){
        if(this[i] === arg){
            this.splice(i,1);
        }
    }
};

var arr = [1, 2, 1, 4, 1, 3, 4, 1, 111, 3, 2, 1, '1'];
arr.removeItem(1);

var arr = ['hi', 'bye', 'hello' ];
arr.removeItem('bye');

console.log(arr);