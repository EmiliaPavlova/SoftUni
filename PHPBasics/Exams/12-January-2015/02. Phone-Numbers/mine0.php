<?php
$numbers = $_GET['numbersString'];
$pattern = '/(\b[A-Z][a-zA-Z]*)[^a-zA-Z0-9\+]*?(\+?[0-9]+[0-9()\/\-.\s]*[0-9]+)/';
preg_match_all($pattern, $numbers, $matches);
if (empty($matches[0])) {
    echo "<p>No matches!</p>";
} else {
    echo "<ol>";
    foreach ($matches[2] as $k => $phone) {
        $name = htmlspecialchars(trim($matches[1][$k]));
        $phone = preg_replace("/[^+0-9]*/", "", $phone);
        echo "<li><b>{$name}:</b> $phone</li>";
    }
    echo "</ol>";
}