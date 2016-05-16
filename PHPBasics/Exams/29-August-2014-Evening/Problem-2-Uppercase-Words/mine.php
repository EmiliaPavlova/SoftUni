<?php
$text = $_GET['text'];
$result = '';
$upperLetters = '';

for ($i = 0; $i < strlen($text); $i++) {
    $char = $text[$i];
    if (ctype_alpha($char)) {
        $upperLetters .= $char;
    } else {
        $result .= processWord($upperLetters);
        $upperLetters = '';
        $result .= $char;
    }
}
$result .= processWord($upperLetters);

function processWord($word) {
    if (ctype_upper($word)) {
        $reversed = reverseWord($word);
        if ($reversed == $word) {
            return doubleLetters($word);
        } else {
            return $reversed;
        }
    }
    return $word;
}

function reverseWord($word) {
    $reversed = "";
    for ($i = strlen($word)-1; $i >= 0; $i--) {
        $reversed .= $word[$i];
    }
    return $reversed;
}

function doubleLetters($word) {
    $result = "";
    for ($i = 0; $i < strlen($word); $i++) {
        $result .= $word[$i] . $word[$i];
    }
    return $result;
}

echo "<p>" . htmlspecialchars($result) . "</p>";