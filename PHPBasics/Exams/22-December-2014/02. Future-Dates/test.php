<?php
date_default_timezone_set("UTC");
$numbersString = $_GET['numbersString'];
$dateString = $_GET['dateString'];

$numberPattern = "/(?<![a-zA-Z])\d+(?![a-zA-Z])/";

preg_match_all($numberPattern, $numbersString, $numbers);

var_dump($numbers);
$sum = 0;

foreach ($numbers[0] as $num) {
    $sum += $num;
}

$sum = intval(strrev($sum));
//echo $sum;

$datesPattern = "/\d{4}\-\d{2}\-\d{2}/";

preg_match_all($datesPattern, $dateString, $dates);

$result = "";

$totalDates = 0;

foreach ($dates as $datesFound) {
    $totalDates += count($datesFound);
}

if ($totalDates === 0) {
    echo "<p>No dates</p>";
} else {
    $result .= "<ul>";


    foreach ($dates as $entry) {
        foreach ($entry as $date) {
//            $dateInfo = preg_split("/\s*-\s*/", $date);
//            $newDate = mktime(0, 0, 0, intval($dateInfo[1]), intval($dateInfo[2]), intval($dateInfo[0]));
//            $toAdd = $sum * 24 * 60 * 60;
//            $newDate += $toAdd;
//        echo strtotime($date . " + $sum days") . "<br>";
            $result .= "<li>" . date('Y-m-d', strtotime($date . " + $sum days")) . "</li>";
        }


    }
    $result .= "</ul>";

    echo $result;
}