<?php
$jsonTable = $_GET['jsonTable'];
$inputArray = json_decode($jsonTable);
$numberOfColumns = intval($inputArray[0]);
$pattern = '/time=(\d+){1,3}ms/';

$string = array();
$symbolCount = 0;

foreach ($inputArray[1] as $key => $value) {
    preg_match_all($pattern, $value, $millis);
    var_dump($millis);
    if (!empty($millis[1][0])) {
        $charCode = $millis[1][0];
        if (ctype_alpha(chr($charCode))) {
            $string[] = chr($charCode);
            $symbolCount++;
        }
        else if (chr($charCode) == ' ') {
            $string[] = '';
            $symbolCount++;
        }
        else if(chr($charCode) == '*' && $symbolCount % $numberOfColumns != 0) {
            for ($i = $symbolCount % $numberOfColumns; $i < $numberOfColumns; $i++) {
                $string[] = '';
                $symbolCount++;
            }
        }
    }
}

while($symbolCount % $numberOfColumns != 0) {
    $string[] = '';
    $symbolCount++;
}

$isOpened = false;
echo "<table border='1' cellpadding='5'>";
echo '<tr>';
for ($i = 0; $i < count($string); $i++) {
    if ($i != 0 && $i % $numberOfColumns == 0) {
        echo '<tr>';
        $isOpened = true;
    }
    echo '<td';
    if ($string[$i] != '') {
        echo " style='background:#CAF'";
    }
    echo '>'.htmlspecialchars($string[$i]);
    echo '</td>';

    if ($i % $numberOfColumns == ($numberOfColumns - 1)) {
        echo '</tr>';
        $isOpened = false;
    }
}
if ($isOpened) {
    echo '</tr>';
}
echo '</table>';

