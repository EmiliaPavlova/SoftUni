<?php
$inputLuggage = $_GET['luggage'];
$luggage = explode('C|_|', $inputLuggage);
$luggage = array_filter($luggage);

$filterTypeLuggage = $_GET['typeLuggage']; //array
$filterRoom = $_GET['room'];
$filterMinWeight = (int)$_GET['minWeight'];
$filterMaxWeight = (int)$_GET['maxWeight'];

$luggageList = array();

foreach ($luggage as $luggagePiece) {
    $tempLuggagePiece = explode(';', $luggagePiece);
    $tempType = $tempLuggagePiece[0];
    $tempRoom = $tempLuggagePiece[1];
    $tempWeight = floor($tempLuggagePiece[3]);
    //var_dump($tempWeight);
    $tempName = $tempLuggagePiece[2];

    if (!array_key_exists($tempType, $luggageList) ||
        !array_key_exists($tempRoom, $luggageList[$tempType])) {
        $luggageList[$tempType][$tempRoom][$tempWeight][] = $tempName;

    } else {
        $oldKey = key($luggageList[$tempType][$tempRoom]);
        $newKey =($oldKey + $tempWeight) . '' ;
        $luggageList[$tempType][$tempRoom][$newKey] = $luggageList[$tempType][$tempRoom][$oldKey];
        $luggageList[$tempType][$tempRoom][$newKey][] = $tempName;
        unset($luggageList[$tempType][$tempRoom][$oldKey]);
    }
}

ksort($luggageList);
echo "<ul>";
foreach ($luggageList as $type => $rooms) {
    ksort($rooms);
    $output = '';
    $print = false;
    if (in_array($type, $filterTypeLuggage)){
        $output.= '<li><p>'.$type.'</p>';

        foreach ($rooms as $room => $weights) {
            if ($room == $filterRoom){
                $output.= '<ul><li><p>'.$room.'</p>';

                foreach ($weights as $weight => $name) {
                    if ($weight >= $filterMinWeight && $weight <= $filterMaxWeight){
                        $print = true;
                        asort($name);
                        $output.= '<ul><li><p>'.implode(", ",$name).' - '.$weight.'kg</p></li></ul>';
                    }
                }
                $output.= '</li></ul>';
            }
        }
        $output.= '</li>';
    }

    if ($print){
      echo $output;
    }
}
echo "</ul>";
