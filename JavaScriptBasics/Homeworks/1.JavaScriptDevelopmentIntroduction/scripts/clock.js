"use strict";
function timer() {
    var now = new Date(),
    hour = now.getHours(),
    min = now.getMinutes(),
    sec = now.getSeconds();

    if (min < 10) {
        min = '0' + min;
    }
    if (sec < 10) {
        sec = '0' + sec;
    }
    document.getElementById("time").innerHTML = hour + ":" + min + ":" + sec;
}
setInterval('timer()', 1000);