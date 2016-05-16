<?php
$text = preg_split("/\r?\n/", $_GET['text'], -1, PREG_SPLIT_NO_EMPTY);
$artist = $_GET['artist'];
$property = $_GET['property'];
$order = $_GET['order'];

$tunesArray = [];

for ($i = 0; $i < count($text); $i++) {
    $data = preg_split("/\s*\|\s*/", $text[$i], -1, PREG_SPLIT_NO_EMPTY);
    $tempTunes = [
        'name' => trim($data[0]),
        'genre' => trim($data[1]),
        'artists' => explode(", ", trim($data[2])),
        'downloads' => intval(trim($data[3])),
        'rating' => floatval(trim($data[4]))
    ];
    sort($tempTunes['artists']);

    if (in_array($artist, $tempTunes['artists'])) {
        $tunesArray[] = $tempTunes;
    }
}

usort($tunesArray, function($a, $b) use ($property) {
    if ($property === 'genre') {
        if ($a[$property] === $b[$property]) {
            return $a['name'] > $b['name'];
        }
        return $a[$property] > $b[$property];
    }
    if ($a[$property] === $b[$property]) {
        return $b['name'] > $a['name'];
    }
    return $a[$property] > $b[$property];
});

if ($order === 'descending') {
    $tunesArray = array_reverse($tunesArray);
}

echo "<table>\n";
echo "<tr><th>Name</th><th>Genre</th><th>Artists</th><th>Downloads</th><th>Rating</th></tr>\n";
for ($i = 0; $i < count($tunesArray); $i++) {
    echo "<tr><td>" . htmlspecialchars($tunesArray[$i]['name']) .
        "</td><td>" . htmlspecialchars($tunesArray[$i]['genre']) .
        "</td><td>" . htmlspecialchars(implode(", ", $tunesArray[$i]['artists'])) .
        "</td><td>" . htmlspecialchars($tunesArray[$i]['downloads']) .
        "</td><td>" . htmlspecialchars($tunesArray[$i]['rating']) . "</td></tr>\n";
}
echo "</table>";