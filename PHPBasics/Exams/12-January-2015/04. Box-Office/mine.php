<?php
$list = $_GET['list'];
$minSeats = $_GET['minSeats'];
$maxSeats = $_GET['maxSeats'];
$filter = $_GET['filter'];
$order = $_GET['order'];
$inputList = preg_split("/\r?\n/", $list, -1, PREG_SPLIT_NO_EMPTY);
$screenings = array();

foreach ($inputList as $line) {
    $movieData = preg_split('/[\)\(\-\/]/', $line, -1, PREG_SPLIT_NO_EMPTY);

    if($filter != 'all' && $movieData[1] != $filter) {
        continue;
    }
    if ($movieData[3] >= $minSeats && $movieData[3] <= $maxSeats) {
        $screenings[] = $movieData;
    }
}
usort($screenings, function($a, $b) use ($order) {
    if ($order === 'ascending') {
        if ($a[0] === $b[0]) {
            return $a[3] > $b[3];
        }
        return $a[0] > $b[0];
    } else {
        if ($a[0] === $b[0]) {
            return $a[3] > $b[3];
        }
        return $a[0] < $b[0];
    }
});

foreach($screenings as $screening) {
    echo '<div class="screening">';
    echo '<h2>' . trim(htmlspecialchars($screening[0])) . '</h2>';
    $cast = preg_split('/,/', $screening[2], -1, PREG_SPLIT_NO_EMPTY);
    echo '<ul>';
    foreach ($cast as $actor) {
        echo '<li class="star">' . trim(htmlspecialchars($actor)) . '</li>';
    }
    echo '</ul>';
    echo '<span class="seatsFilled">' . trim(htmlspecialchars($screening[3])) . ' seats filled</span>';
    echo '</div>';
}
//var_dump($screenings);
