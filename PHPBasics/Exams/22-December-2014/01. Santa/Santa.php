<?php
$childName = $_GET['childName'];
$wantedPresent = $_GET['wantedPresent'];
$riddlesInput = $_GET['riddles'];

$childName = preg_replace("/\s/", "-", $childName);
$riddles = explode(';', $riddlesInput);
$nrLettersChildName = strlen($childName);
$numberOfRiddles = count($riddles);
$riddleNumber = $nrLettersChildName % $numberOfRiddles;
if($riddleNumber == 0) {
    $pickedRiddle = $riddles[$numberOfRiddles - 1];
} else {
    $pickedRiddle = $riddles[$riddleNumber - 1];
}

$santaMessage = "\$giftOf" . $childName . " = \$[wasChildGood] ? '" . $wantedPresent . "' : '" . $pickedRiddle . "';";
echo htmlspecialchars($santaMessage);
//$encryptedMessage = encrypt($santaMessage, $nrLettersChildName);
//echo $encryptedMessage;

//echo (encrypt('Santa', 5));

function encrypt($message, $key) {
    $messageLength = strlen($message);
    $result = '';
    for ($i = 0; $i < $messageLength; $i++) {
        $encryptedChar = ord($message[$i]) + $key;
        $result .= $encryptedChar;
    }
    return $result;
}