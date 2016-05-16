<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <title>Sum Two Numbers</title>
</head>
<body>
    <?php
    function sumTwoNumbers($firstNumber, $secondNumber) {
        echo '$firstNumber + $secondNumber = ' . $firstNumber . ' + ' . $secondNumber . ' = ' . round($firstNumber + $secondNumber, 2) . '</br>';
    };
    sumTwoNumbers(2, 5);
    sumTwoNumbers(1.567808, 0.356);
    sumTwoNumbers(1234.5678, 333);
    ?>
</body>
</html>