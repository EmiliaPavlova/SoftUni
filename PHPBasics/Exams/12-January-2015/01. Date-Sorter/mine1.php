<?php
date_default_timezone_set('Europe/Sofia');
$datesInput = explode("\n", $_GET['list']);
$currDate = $_GET['currDate'];
$currDate = date_create($currDate);
$dates = [];

foreach ($datesInput as $date) {
    if (date_create($date) !== false && date_create($date) != date_create()) {
        $dates[] = date_create($date);
    }
}
sort($dates);

echo "<ul>";
foreach ($dates as $date) {
    echo "<li>";
    if ($date < $currDate) {
        echo "<em>" . $date->format('d/m/Y') . "</em>";
    } else {
        echo $date->format('d/m/Y');
    }
    echo "</li>";
}
echo "</ul>";