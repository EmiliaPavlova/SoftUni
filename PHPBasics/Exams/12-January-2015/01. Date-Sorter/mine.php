<?php
date_default_timezone_set('Europe/Sofia');
$list = trim($_GET['list']);
$currDate = $_GET['currDate'];
$dates = preg_split('/\r?\n/', $list, -1, PREG_SPLIT_NO_EMPTY);
$formattedDates = [];

foreach ($dates as $date) {
    try {
        $date = new DateTime($date);
        $formattedDates[] = $date;
    } catch (Exception $ex) {
        continue;
    }
}

sort($formattedDates);

$currDate = new DateTime($currDate);

echo "<ul>";
foreach ($formattedDates as $date) {
    if ($date < $currDate) {
        echo "<li><em>" . $date->format('d/m/Y') . "</em></li>";
    } else {
        echo "<li>" . $date->format('d/m/Y') . "</li>";
    }
}
echo "</ul>";
