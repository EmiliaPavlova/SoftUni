<?php
$data[0] = $_GET['arrows'];
for ($i = 1; $i < 4; $i++) {
    $data[$i] = $_GET['arrows' . $i];
}
$small = 0;
$medium = 0;
$large = 0;

foreach ($data as $line) {
    preg_match_all('/(>{1,3})-{5}(>{1,3})/', $line, $arrowsArray);

    for ($i = 0; $i < count($arrowsArray[1]); $i++) {
        if (strlen($arrowsArray[1][$i]) === 3 && strlen($arrowsArray[2][$i]) >= 2) {
            $large++;
        }
        if (strlen($arrowsArray[1][$i]) >= 2 && strlen($arrowsArray[2][$i]) === 1 ||
            strlen($arrowsArray[1][$i]) === 2 && strlen($arrowsArray[2][$i]) >= 1) {
            $medium++;
        }
        if (strlen($arrowsArray[1][$i]) === 1 && strlen($arrowsArray[2][$i]) >= 1) {
            $small++;
        }
    }
}
//var_dump($small);
//var_dump($medium);
//var_dump($large);
$numString = '' . $small . $medium . $large;
$numBinary = decbin($numString);
$numBinRev = strrev($numBinary);
$binConcat = $numBinary . $numBinRev;
$result = bindec($binConcat);

//echo $numString . "<br/>";
//echo $numBinary . "<br/>";
//echo $numBinRev . "<br/>";
//echo $binConcat . "<br/>";
echo $result;