<?php
$input =json_decode($_GET['jsonTable']);
$maxCols = 0;
foreach ($input[0] as $key => $value) {
    $input[0][$key] = encryptMatrix($value, $input[1][0], $input[1][1]);
    $maxCols = max(strlen($value), $maxCols);
}

function encryptMatrix($text, $k, $s) {
    $cipherText = "";
    $chars = str_split(strtoupper($text));
    foreach ($chars as $char) {
        $x = ord($char) - 65;
        if($x < 0) {
            $cipherText .= $char;
        }
        else {
            $cipherText .= chr((($k * $x + $s) % 26) + 65);
        }
    }
    return $cipherText;
}

echo "<table border='1' cellpadding='5'>";
foreach ($input[0] as $key => $value) {
    echo "<tr>";
    if ($maxCols > 0) {
        for ($col = 0; $col < $maxCols; $col++) {
            if ($col >= strlen($value)) {
                echo "<td>";
            } else {
                echo "<td style='background:#CCC'>";
                echo htmlspecialchars($value[$col]);
            }
            echo "</td>";
        }
    } else{
        echo "<td></td>";
    }
    echo "</tr>";
}
echo "</table>";