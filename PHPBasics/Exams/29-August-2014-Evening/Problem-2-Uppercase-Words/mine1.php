<?php
$text = $_GET['text'];
//echo "<p>" . htmlspecialchars($text) . "</p>";
preg_match_all('/(\b[A-Z]+\b)|([A-Z]+(?=\d))|((?<=\d)[A-Z]+)/', $text, $upperCase);
$split = preg_split('/(\b[A-Z]+\b)|([A-Z]+(?=\d))|((?<=\d)[A-Z]+)/', $text);
var_dump($split);
$output = $split[0];
for ($i = 1; $i < count($split); $i++) {
    $output .= newWord($upperCase[0][$i-1]) . $split[$i];
}


function newWord($word) {
    $newWord = strrev($word);
    $output='';

    if ($newWord === $word) {
        for ($i = 0; $i < strlen($word); $i++) {
            $output .= $word[$i] . $word[$i];
        }
        return $output;
    }
    return $newWord;
}

echo "<p>" . htmlspecialchars($output) . "</p>";

