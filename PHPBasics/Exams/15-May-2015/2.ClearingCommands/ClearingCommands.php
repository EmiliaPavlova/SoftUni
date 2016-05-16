<?php
$inputArray = $_GET['array'];
$matrix = preg_split("/\r?\n/", $inputArray, -1, PREG_SPLIT_NO_EMPTY);
//$result;

//var_dump($matrix);

$rowsCount = strlen($inputArray) / strlen($matrix[0]) - 1;
$colsCount = strlen($matrix[0]);
$index = 0;

for ($row = 0; $row < $rowsCount; $row++) {
    for ($col = 0; $col < $colsCount; $col++) {
        if ($matrix[$row][$col] === '>') {
            for ($i = 0; $i <= $colsCount - $col - $i; $i++) {
                if ($matrix[$row][$col + $i] !== '>' &&
                    $matrix[$row][$col + $i] !== '<' &&
                    $matrix[$row][$col + $i] !== 'v' &&
                    $matrix[$row][$col + $i] !== '^') {
                    $matrix[$row][$col + $i] = " ";
                } else {
                    continue;
                }
            }
        }

        if ($matrix[$row][$col] === 'v') {
            for ($i = 0; $i <= $rowsCount - $row - $i; $i++) {
                if ($matrix[$row + $i][$col] !== '>' &&
                    $matrix[$row + $i][$col] !== '<' &&
                    $matrix[$row + $i][$col] !== 'v' &&
                    $matrix[$row + $i][$col] !== '^') {
                    $matrix[$row + $i][$col] = " ";
                } else {
                    continue;
                }
            }
        }
    }
}

for ($row = $rowsCount; $row > 0; $row--) {
    for ($col = $colsCount; $col > 0; $col--) {
        if ($matrix[$row][$col] === '<') {
            for ($i = $colsCount - $col + $i; $i > 0; $i--) {
                if ($matrix[$row][$col - $i] !== '>' &&
                    $matrix[$row][$col - $i] !== '<' &&
                    $matrix[$row][$col - $i] !== 'v' &&
                    $matrix[$row][$col - $i] !== '^') {
                    $matrix[$row][$col - $i] = " ";
                } else {
                    continue;
                }
            }
        }

        if ($matrix[$row][$col] === '^') {
            for ($i = $rowsCount - $row; $i > 0; $i--) {
                if ($matrix[$row - $i][$col] !== '>' &&
                    $matrix[$row - $i][$col] !== '<' &&
                    $matrix[$row - $i][$col] !== 'v' &&
                    $matrix[$row - $i][$col] !== '^') {
                    $matrix[$row - $i][$col] = " ";
                } else {
                    continue;
                }
            }
        }
    }
}
var_dump($matrix);

for ($i = 0; $i < count($matrix); $i++) {
    echo "<p>";
    for ($j = 0; $j < strlen($matrix[0]); $j++) {
        echo htmlspecialchars($matrix[$i][$j]);
    }
    echo "</p>\n";
}
