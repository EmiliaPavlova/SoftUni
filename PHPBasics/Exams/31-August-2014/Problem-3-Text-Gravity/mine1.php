<?php
$text = $_GET['text'];
$cols = $_GET['lineLength'];
$mod = strlen($text) % $cols;
$toAdd = $mod;
if ($mod  > 0) {
    $toAdd = $cols - $mod;
}
$text .= str_repeat(' ', $toAdd);

$matrix = [];
$index = 0;
for ($i = 0; $i < strlen($text) / $cols; $i++) {
    $matrix[$i] = substr($text, $index, $cols);
    $index += $cols;
}
do {
    $hasMoved = false;
    for ($row = strlen($text) / $cols - 1; $row > 0; $row--) {
        for ($col = 0; $col < $cols; $col++) {
            if (isset($matrix[$row]) && trim($matrix[$row][$col]) == "" &&
                trim($matrix[$row-1][$col]) !== "") {
                $matrix[$row][$col] = $matrix[$row-1][$col];
                $matrix[$row-1][$col] = " ";
                $hasMoved = true;
            }
        }
    }
} while ($hasMoved);

echo "<table>";
for ($i = 0; $i < count($matrix); $i++) {
    echo "<tr>";
    for ($j = 0; $j < $cols; $j++) {
        echo "<td>" . htmlspecialchars($matrix[$i][$j]) . "</td>";
    }
    echo "</tr>";
}
echo "</table>";
