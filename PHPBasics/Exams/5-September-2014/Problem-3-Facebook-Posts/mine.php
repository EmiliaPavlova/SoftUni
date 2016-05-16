<?php
date_default_timezone_set('Europe/Sofia');
$input = preg_split("/\r?\n/", $_GET['text'], -1, PREG_SPLIT_NO_EMPTY);
for ($i = 0; $i < count($input); $i++) {
    $data = preg_split("/;/", $input[$i], -1, PREG_SPLIT_NO_EMPTY);
    $date = date_create($data[1]);
//        var_dump($date);
    $message[] = [
        'author' => trim($data[0]),
        'date' => $date,
        'post' => trim($data[2]),
        'likes' => intval($data[3]),
        'comments' => trim($data[4])
    ];
}
//var_dump($message[1]);

uasort($message, function($a, $b) {
    return $a['date'] < $b['date'];
});

//var_dump($message);

foreach ($message as $key => $value) {

    echo "<article><header><span>" . htmlspecialchars($value['author']) .
        "</span><time>" . $value['date']->format('j F Y') .
        "</time></header><main><p>" . htmlspecialchars($value['post']) .
        "</p></main><footer><div class=\"likes\">" . htmlspecialchars($value['likes']) .
        " people like this</div>";
    if ($value['comments'] !== '') {
        $comment = explode("/", $value['comments']);
        echo "<div class=\"comments\">";
        for ($j = 0; $j < count($comment); $j++) {
            echo "<p>" . htmlspecialchars(trim($comment[$j])) . "</p>";
        }
        echo "</div>";
    }
    echo "</footer></article>";
}