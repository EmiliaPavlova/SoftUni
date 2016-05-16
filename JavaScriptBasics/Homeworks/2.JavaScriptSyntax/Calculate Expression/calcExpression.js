function calculate() {
    var expression = document.getElementById('input').value;
    var regex = /[^0-9\-*/()+%]+/g;
    expression = expression.replace(regex, '');
    document.getElementById('result').textContent = eval(expression);
}
