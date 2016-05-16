<?php

$input = json_decode($_GET['jsonTable']);
$numberOfCols = intval($input[0], 10);
$messages = $input[1];

$pattern = "/Reply from \d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}: bytes=\d+ time=(\d+)ms TTL=\d+/";
//$pattern = "/time\s*=\s*(\d+)\s*ms/";
$charCodes = array();

for ($i = 1; $i < count($messages); $i++) {
    preg_replace("/\s+/", "", $messages[$i]);
    preg_match_all($pattern, $messages[$i], $milliseconds);

    $millisecond = $milliseconds[1][0];
    $charCodes[] = $millisecond;
}

//chr (int ASCII);

$result = "<table border='1' cellpadding='5'>";

$index = 0;

while ($index < count($charCodes)) {
    $result .= "<tr>";
    $lineEnded = false;
    for ($col = 0; $col < $numberOfCols; $col++) {

        if ($index >= count($charCodes) || $lineEnded) {
            $result .= "<td></td>";
        } else if ($charCodes[$index] == 42) {
            $index++;
            $lineEnded = true;
            $result .= "<td></td>";

        } else if (ctype_space(chr($charCodes[$index]))) {
            $result .= "<td></td>";
            $index++;
        } else if (!ctype_alpha(chr($charCodes[$index]))) {
            $result .= "<td style='background:#CAF'>" . htmlspecialchars(chr($charCodes[$index])) ."</td>";
            $index++;
        } else {
            $result .= "<td style='background:#CAF'>" . htmlspecialchars(chr($charCodes[$index])) ."</td>";
            $index++;
        }


    }

    $result .= "</tr>";
}

$result .= "</table>";

echo $result;