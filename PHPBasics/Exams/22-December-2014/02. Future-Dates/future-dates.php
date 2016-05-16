<?php
$numbersString = $_GET['numbersString'];
$dateString = $_GET['dateString'];

$numbersRegex = "/[^a-zA-Z0-9]+?([0-9]+)[^a-zA-Z0-9]+?/";
preg_match_all($numbersRegex, $numbersString, $numbers);
//var_dump($numbers);

$sum = 0;

foreach ($numbers[1] as $number) {
    $sum+=$number;
}

$sum = strrev($sum);
//var_dump($sum);

$dateRegex = "/([0-9]{4}-[0-9]{2}-[0-9]{2})/";
preg_match_all($dateRegex, $dateString, $dates);

//var_dump($dates);
if (!empty($dates[1])) {
    $futureDates = [];

    foreach ($dates[1] as $date) {
        $tempDate = date_create($date, timezone_open("Europe/Sofia"));
        date_add($tempDate, date_interval_create_from_date_string("$sum days"));
        array_push($futureDates, $tempDate);
    }

    //var_dump($futureDates);

    $result = "<ul>";
    foreach ($futureDates as $futureDate) {
        $result .= "<li>". date_format($futureDate, "Y-m-d") . "</li>";
    }
    $result .= "</ul>";
    echo $result;
} else {
    echo "<p>No dates</p>";
}