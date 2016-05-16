<?php
$keys = $_GET['keys'];
$text = $_GET['text'];
preg_match('/^([a-zA-Z_]+)\d+/', $keys, $startKey);
preg_match('/\d+([a-zA-Z_]+)$/', $keys, $endKey);

if (!$startKey[1] || !$endKey[1]) {
    echo "<p>A key is missing</p>";
} else {
    $regex = "/" . $startKey[1] . "(.*?)" . $endKey[1] . "/";
    preg_match_all($regex, $text, $matches);
    $sum = 0;
    foreach ($matches[1] as $match) {
        if (is_numeric($match) && $matches !== '') {
            $sum += $match;
        }
    }
    if ($sum === 0) {
        echo "<p>The total value is: <em>nothing</em></p>";
    } else {
        echo "<p>The total value is: <em>$sum</em></p>";
    }
}