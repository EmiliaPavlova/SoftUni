<?php
$dates = parseInputList();
$currDate = date_create($_GET['currDate'], timezone_open("Europe/Sofia"));
sort($dates);

echo "<ul>";
foreach ($dates as $date) {
    if ($date < $currDate) {
        // Earlier dates got italic
        $text = "<li><em>" . date_format($date, "d/m/Y") . "</em></li>";
    } else {
        $text = '<li>' . date_format($date, "d/m/Y") . "</li>";
    }
    echo $text;
}
echo "</ul>";

function parseInputList() {
    $list = $_GET['list'];
    $lines = preg_split('/\n/', $list);
    $result = [];
    //var_dump($lines);
    foreach ($lines as $line) {
        $tempDate = date_create($line, timezone_open("Europe/Sofia"));
        if ($line != "" && $tempDate) {
            $result[] = $tempDate;
        }
    }
    return $result;
}
