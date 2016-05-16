<?php

$luggage = $_GET['luggage'];

$filterType = $_GET['typeLuggage'];
$filterRoom = $_GET['room'];
$filterMinKg = intval($_GET['minWeight']);
$filterMaxKg = intval($_GET['maxWeight']);

$luggageArray = explode('C|_|', $luggage);

$goshoLuggage = array();

foreach ($luggageArray as $key => $value) {
    $luggageDetails = explode(';', $value);

    if (count($luggageDetails) < 2) { continue; }
    if ($luggageDetails[1] != $filterRoom) { continue; }
    if (!in_array($luggageDetails[0], $filterType)) { continue; }

    $type = $luggageDetails[0];
    if (!isset($goshoLuggage[$type])) {
        $goshoLuggage[$type] = array();
    }

    if (!isset($goshoLuggage[$type]['weight'])) {
        $goshoLuggage[$type]['weight'] = 0;
    }

    $goshoLuggage[$type][] = $luggageDetails[2];
    $goshoLuggage[$type]['weight'] += intval($luggageDetails[3]);
}

ksort($goshoLuggage);

foreach ($goshoLuggage as $key => $value) {
    $weight = $value['weight'];
    unset($value['weight']);
    usort($value, function($a, $b){
        return strcmp($a, $b);
    });

    $goshoLuggage[$key] = $value;
    $goshoLuggage[$key]['weight'] = $weight;
}
echo '<ul>';
foreach ($goshoLuggage as $key => $value) {
    if ($value['weight'] < $filterMinKg ||
        $value['weight'] > $filterMaxKg)
    { continue; }
    $weight = $value['weight'];
    unset($value['weight']);


    echo '<li><p>'. $key .'</p>';
    echo '<ul><li><p>'. $filterRoom .'</p>';
    echo '<ul><li><p>'. implode(', ', $value) .' - '. $weight .'kg</p>';
    echo '</li></ul></li></ul></li>';
}
echo '</ul>';