<?php
    date_default_timezone_set('Europe/Sofia');
    $numbersString = $_GET['numbersString'];
    $dateString = $_GET['dateString'];

    preg_match_all('/[^a-zA-Z0-9](\d+)[^a-zA-Z]/', $numbersString, $numbersArray);
    $numbersSum = array_sum($numbersArray[1]);
    $reversedSum = strrev($numbersSum);
    preg_match_all('/(\d{4}-\d{2}-\d{2})/', $dateString, $dateArray);

    if (empty($dateArray[1])) {
        echo '<p>No dates</p>';
    } else {
        echo '<ul>';
        foreach ($dateArray[1] as $key => $value) {
            echo '<li>';
            $d = DateTime::createFromFormat('Y-m-d', $value);
            $d -> modify(' + ' . $reversedSum . ' day');
            echo $d -> format('Y-m-d');
            echo '</li>';
        }
        echo '</ul>';
    }