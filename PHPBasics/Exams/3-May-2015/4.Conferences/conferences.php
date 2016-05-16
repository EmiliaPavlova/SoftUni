<?php

ini_set('display_errors',1);
ini_set('display_startup_errors',1);
error_reporting(-1);

date_default_timezone_set('Europe/Sofia');
$page = $_GET['page'];
$pageSize = $_GET['pageSize'];

$eventsToDispl = ($pageSize * $page) - $pageSize;
$currDay = date_create('now');
$input = $_GET['conferences'];
preg_match_all('/\[(\d{4}[-\/]\d{2}[-\/]\d{2}).*?,.*?(#[a-zA-Z\.-]+).*?,.*?(\'.*\').*?,.*?([a-zA-Z-,]+).*?,.*?(\d+).*?,.*?(\d+).*?]/', $input, $conferences);

$eventArray = [];

for ($i = 0; $i < count($conferences[0]); $i++) {
    $data = preg_split('/,\s/', $conferences[0][$i], -1, PREG_SPLIT_NO_EMPTY);
    $tempArray=[];
    $tempArray = [
        'date' => date_create(substr(trim($data[0]), 1)),
        'hashTag' => trim($data[1]),
        'name' => trim($data[2]),
        'location' => trim($data[3]),
        'allTickets' => intval($data[4]),
        'soldTickets' => intval($data[5]),
        'avaivableTickets' => $data[4] - $data[5]
    ];
    if ($tempArray['date']) {
        $eventArray[] = $tempArray;

    }

}
var_dump($eventArray);

uasort($eventArray, function($a, $b) {
    if ($a['date'] === $b['date']) {
        if ($a['location'] === $b['location']) {
            if (($a['allTickets'] - $a['soldTickets']) === $b['allTickets'] - $b['soldTickets']) {
                return strcmp($a['name'], $b['name']);
            }
            return $a['avaivableTickets'] > $b['avaivableTickets'];
        }
        return strcmp($a['location'], $b['location']);
    }
    return $a['date'] < $b['date'];
});

var_dump($eventsToDispl);
var_dump($pageSize);
echo "<table border=\"1\" cellpadding=\"5\">";
echo "<tr><th>Date</th><th>Event name</th><th>Event hash</th><th>Days left</th><th>Seats left</th></tr>";

$start = $eventsToDispl;
$end = $eventsToDispl + intval($pageSize);
//$daysLeft = date_diff( $currDay[0], $eventArray['date']);
//$daysLeft = $currDay -> diff($eventArray['date']);
var_dump($daysLeft);
for ($i = $start; $i < $end; $i++) {
    echo "<tr>";
    $rowspanCount = 1;
    for ($j = $i + 1; $j < $end; $j++) {
        if ($eventArray[$i]['date'] == $eventArray[$j]['date']) {
            $rowspanCount++;
        } else {
            $i++;
            break;
        }
    }

    if ($rowspanCount > 1) {
        echo "<td rowspan=\"$rowspanCount\">" . $eventArray[$i]['date']->format('Y-m-d') . "</td><td>" . $eventArray[$i]['name'] . "</td><td>"
            . $eventArray[$i]['hashTag'] . "</td><td>" . $eventArray[$i]['name'] . "</td><td>Seats left</td></tr>";
        $a = $i;
        for ($j = $i + 1; $j < $i + $rowspanCount; $j++) {

            echo "<tr><td>" . $eventArray[$j]['name'] . "</td><td>"
                . $eventArray[$j]['hashTag'] . "</td><td>" . $eventArray[$j]['name'] . "</td><td>Seats left</td></tr>";
        }
    } else {
        echo "<tr>" . $eventArray[$i]['date']->format('Y-m-d') . "</td><td>" . $eventArray[$i]['name'] . "</td><td>"
            . $eventArray[$i]['hashTag'] . "</td><td>" . $eventArray[$i]['name'] . "</td><td>Seats left</td></tr>";
    }
}

echo "</table>";


