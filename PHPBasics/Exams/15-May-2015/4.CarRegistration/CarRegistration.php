<?php
date_default_timezone_set('Europe/Sofia');
$today = $_GET['today'];
$todayFormat = DateTime::createFromFormat('d/m/Y', $today);
$registrations = preg_split('/\s*,\s*/', $_GET['registrations'], -1, PREG_SPLIT_NO_EMPTY);
//var_dump($registrations);
$carBrands = [];

foreach ($registrations as $item) {
    $data = preg_split('/\|/', $item, -1, PREG_SPLIT_NO_EMPTY);
//    var_dump($data);
    $brand = $data[0];
    $model = $data[1];
    $date = $data[2];
    $dateFormat = DateTime::createFromFormat('d/m/Y', $date);
    $plate = $data[3];

//    if (!in_array($brand, $carBrands)) {
//        $carBrands = [$brand];
//    }

    if (!in_array($brand, $carBrands)) {
        $carBrands[$brand];
    }

//    var_dump($carBrands[$brand]);
    if ($todayFormat > $dateFormat) {
//        if (!in_array($model, $carBrands[$brand])){
            $carBrands[$brand][$model]['registrations'][] = [
                'date' => $date,
                'plate' => $plate
            ];
//        }
    } else {
//        if (!in_array($model, $carBrands[$brand])){
            $carBrands[$brand][$model]['registrations'][] = [
                'date' => $date,
                'plate' => $plate,
                'isValid' => false
            ];
//        }
    }
//    var_dump($carBrands);
//    echo json_encode($carBrands);
}

ksort($carBrands);
ksort($carBrands[$brand]);
//var_dump($carBrands);
echo json_encode($carBrands);

