<?php
$childName = trim($_GET['childName']);
$wantedPresent = trim($_GET['wantedPresent']);
$riddles = trim($_GET['riddles']);

$childName = str_replace(' ', '-', $childName);
$riddlesArray = explode(';', $riddles);

if (strlen($childName) % count($riddlesArray) === 0) {
    $pickedRiddle = $riddlesArray[count($riddlesArray) - 1];
} else {
    $pickedRiddle = $riddlesArray[strlen($childName) % count($riddlesArray) - 1];
}

echo "\$giftOf" . htmlspecialchars($childName) . " = $[wasChildGood] ? '" .
    htmlspecialchars($wantedPresent) . "' : '" . htmlspecialchars($pickedRiddle) . "';";