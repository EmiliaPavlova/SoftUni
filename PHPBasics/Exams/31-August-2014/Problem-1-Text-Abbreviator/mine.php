<?php
$list = $_GET['list'];
$maxSize = intval($_GET['maxSize']);

$text = preg_split('/\r?\n/', $list, -1, PREG_SPLIT_NO_EMPTY);
echo "<ul>";
for ($i = 0; $i < count($text); $i++) {
    $text[$i] = trim($text[$i]);

    if (strlen($text[$i]) > $maxSize) {
        echo "<li>" . htmlspecialchars(substr($text[$i], 0, $maxSize)) . "...</li>";
    } else {
        echo "<li>" . htmlspecialchars($text[$i]) . "</li>";
    }
}
echo "</ul>";