<?php
$text = $_GET['text'];
$red = $_GET['red'];
$green = $_GET['green'];
$blue = $_GET['blue'];
$nLetter = intval($_GET['nth']);

$red = dexRGB($red);
$green = dexRGB($green);
$blue = dexRGB($blue);
$color = '#' . $red . $green . $blue;

function dexRGB($RGB){
    $color = dechex($RGB);
    if (strlen($color) < 2) {
        $color = '0' . $color;
    }
    return $color;
}

echo "<p>";
$textArray = str_split($text);
foreach ($textArray as $key => $letter) {
    if (($key + 1) % $nLetter == 0) {
        echo "<span style=\"color: " . htmlentities($color) .
            "\">" . htmlentities($letter) . "</span>";
    } else {
        echo htmlentities($letter);
    }
}
echo "</p>";
