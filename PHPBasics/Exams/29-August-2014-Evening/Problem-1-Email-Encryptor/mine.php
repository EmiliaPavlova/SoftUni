<?php
$recipient = $_GET['recipient'];
$subject = $_GET['subject'];
$text = $_GET['body'];
$key = $_GET['key'];
$message = "<p class='recipient'>" . htmlspecialchars($recipient) .
    "</p><p class='subject'>" . htmlspecialchars($subject) .
    "</p><p class='message'>" . htmlspecialchars($text) . "</p>";
$output = '|';

for ($i = 0, $j = 0; $i < strlen($message); $i++, $j++) {
    if ($j === strlen($key)) {
        $j = 0;
    }
    $output = $output . dechex(ord($message[$i]) * ord($key[$j])) . '|';
}
echo $output;