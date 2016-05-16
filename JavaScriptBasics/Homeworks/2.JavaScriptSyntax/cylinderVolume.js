function calcCylinderVol(arr) {
    var volume = Math.PI * Math.pow(arr[0], 2) * arr[1];
    return volume;
}

console.log(calcCylinderVol([2,4]).toFixed(3));
console.log(calcCylinderVol([5,8]).toFixed(3));
console.log(calcCylinderVol([12,3]).toFixed(3));