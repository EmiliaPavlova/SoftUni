function quadraticEquation (a, b, c) {
    var discriminant = Math.pow(b, 2) - 4 * a * c;
    if (discriminant > 0) {
        console.log('x1 = ' + (- b + Math.sqrt(discriminant)) / (2 * a));
        console.log('x2 = ' + (- b - Math.sqrt(discriminant)) / (2 * a));
    } else if (discriminant === 0) {
        console.log('x = ' + (- b / (2 * a)));
    } else if (discriminant < 0) {
        console.log('No real roots');
    }
    console.log('');
}

quadraticEquation(2, 5, -3);
quadraticEquation(2, -4, 2);
quadraticEquation(4, 2, 1);
