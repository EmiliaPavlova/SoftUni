<?php
date_default_timezone_set('Europe/Sofia');
$currentDate = strtotime($_GET['currentDate']);
$text = $_GET['messages'];
$messages = preg_split("/\r?\n/", $text);
$chatLog = [];
$mostResentTime = 0;

foreach ($messages as $line) {
    $message = preg_split("/\s+\/\s+/", $line, -1, PREG_SPLIT_NO_EMPTY);
    $messageText = $message[0];
    $messageTime = strtotime($message[1]);
    $chatLog[$messageTime] = $messageText;
    if ($messageTime > $mostResentTime) {
        $mostResentTime = $messageTime;
    }
}
ksort($chatLog);
foreach ($chatLog as $key => $value) {
    echo "<div>" . htmlspecialchars($value) . "</div>\n";
}

$timestamp = getTimeMark($mostResentTime, $currentDate);
echo "<p>Last active: <time>$timestamp</time></p>";

function getTimeMark($lastTime, $currentDate) {
    $timeDiff = $currentDate - $lastTime;
    $timeStamp = '';

    $lastDay = date('z', $lastTime);
    $currentDay = date('z', $currentDate);
    if ($lastDay == $currentDay) {
        if ($timeDiff < 60) {
            $timeStamp = "a few moments ago";
        } else if ($timeDiff < 60 * 60) {
            $minutes = floor($timeDiff / 60);
            $timeStamp = "$minutes minute(s) ago";
        } else if ($timeDiff < 24 * 60 * 60) {
            $hours = floor($timeDiff / (60 * 60));
            $timeStamp = "$hours hour(s) ago";
        }
    }
    else if ($lastDay + 1 == $currentDay) {
        $timeStamp = "yesterday";
    } else {
        $timeStamp = date("d-m-Y", $lastTime);
    }

    return $timeStamp;
}