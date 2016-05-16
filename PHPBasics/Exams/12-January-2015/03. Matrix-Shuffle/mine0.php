<?php
$text = $_GET['text'];
$size = intval($_GET['size']);
$matrix = [];
$minRow = 0;
$maxRow = $size;
$minCol = 0;
$maxCol = $size;
for ($row = $minRow; $row < $maxRow; $row++) {
    $matrix[$row] = [];
}
$index = 0;
while ($index < strlen($text))
{
    for ($col = $minCol; $col < $maxCol && $index < strlen($text); $col++) {
        $matrix[$minRow][$col] = $text[$index++];
    }
    $minRow++;
    for ($row = $minRow; $row < $maxRow && $index < strlen($text); $row++) {
        $matrix[$row][$maxCol-1] = $text[$index++];
    }
    $maxCol--;
    for ($col = $maxCol-1; $col >= $minCol && $index < strlen($text); $col--) {
        $matrix[$maxRow-1][$col] = $text[$index++];
    }
    $maxRow--;
    for ($row = $maxRow-1; $row >= $minRow && $index < strlen($text); $row--) {
        $matrix[$row][$minCol] = $text[$index++];
    }
    $minCol++;
}
//foreach ($matrix as &$v) {
//    ksort($v);
//}
function print_m($matrix) {
    echo "<table border='1'>";
    for ($i = 0; $i < count($matrix); $i++) {
        echo "<tr>";
        for ($j = 0; $j < count($matrix[$i]); $j++) {
            echo "<td>" . $matrix[$i][$j] . "</td>";
        }
        echo "</tr>";
    }
    echo "</table>";
}
//print_m($matrix);
$startCol = 0;
$strings = "";
$whites = "";
$blacks = "";
for ($r = 0; $r < $size; $r++) {
    for ($c = 0; $c < $size; $c++) {
        if ($r % 2 == 0) {
            if ($c % 2 == 0) {
                $whites .= $matrix[$r][$c];
            } else {
                $blacks .= $matrix[$r][$c];
            }
        } else {
            if ($c % 2 == 0) {
                $blacks .= $matrix[$r][$c];
            } else {
                $whites .= $matrix[$r][$c];
            }
        }
    }
}
$concatenated = $whites . $blacks;
$toCheck = preg_replace("/[^a-zA-Z]*/", "", $concatenated);
$color = "#E0000F";
if (strtolower($toCheck) == strrev(strtolower($toCheck))) {
    $color = "#4FE000";
}
echo "<div style='background-color:$color'>".htmlspecialchars($concatenated)."</div>";

