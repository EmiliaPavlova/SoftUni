// 1
console.log(this);

// 2 & 3
function testContext() {
    console.log(this);
}
// 2
testContext();

//3
var newTest = new testContext();