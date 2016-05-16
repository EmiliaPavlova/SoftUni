<?php
$matrix = json_decode($_GET['jsonTable']);
//var_dump($_GET['jsonTable']);
//var_dump($matrix);
//var_dump(count($matrix));
$numbers;

echo "<ul>";

for ($row = 0; $row < count($matrix); $row++) {
    $numbers = preg_replace('/\D+/', '', $matrix[$row]);
//    var_dump(max($numbers)*2);

    for ($i = 0; $i < count($matrix[$row]); $i++) {
        var_dump($numbers[$i]);
        if ($numbers[$i] !== '' && in_array($numbers[$i], isFibonacciNumber(max($numbers)*2))){
            echo "<li style=\"color: #3DD459\">" . intval($numbers[$i]) . " - is a Fibonacci number</li>";
        } else if ($numbers[$i] !== '') {
            echo "<li style=\"color: #FF5900\">" . intval($numbers[$i]) ." - is not a Fibonacci number</li>";
        }
    }
}
echo "</ul>";


function isFibonacciNumber($n, $first = 0, $second = 1)
{
    $fib = [$first, $second];
    for($i = 1; $i < $n; $i++)
    {
        $fib[] = $fib[$i] + $fib[$i-1];
    }
    return $fib;
}
