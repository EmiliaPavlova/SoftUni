<?php
date_default_timezone_set('Europe/Sofia');
$text = preg_split("/\r?\n/", $_GET['text']);
$minPrice = $_GET['min-price'];
$maxPrice = $_GET['max-price'];
$criteria = $_GET['sort'];
$order = $_GET['order'];

$books = [];

foreach ($text as $item) {
    $data = preg_split("/\s*\/\s*/", $item, -1, PREG_SPLIT_NO_EMPTY);
    $bookArray = [
        'author' => trim($data[0]),
        'name' => trim($data[1]),
        'genre' => trim($data[2]),
        'price' => floatval(trim($data[3])),
        'publish date' => trim($data[4]),
        'info' => trim($data[5])
    ];
    if ($bookArray['price'] >= $minPrice && $bookArray['price'] <= $maxPrice) {
        $books[] = $bookArray;
    }
    //var_dump($bookArray);
}
//var_dump($criteria);
//var_dump($order);

usort($books, function($a, $b) use ($criteria) {
    if ($a[$criteria] === $b[$criteria]) {
        return $b['publish date'] < $a['publish date'];
    } else {
        return $a[$criteria] > $b[$criteria];
    }
});

if ($order === 'descending') {
    $books = array_reverse($books);
}

//var_dump($books);
foreach ($books as $book) {
    echo "<div>";
    echo "<p>" . htmlspecialchars($book['name']) . "</p>";
    echo "<ul>";
    echo "<li>" . htmlspecialchars($book['author']) . "</li>";
    echo "<li>" . htmlspecialchars($book['genre']) . "</li>";
    echo "<li>" . htmlspecialchars(number_format($book['price'], 2)) . "</li>";
    echo "<li>" . htmlspecialchars($book['publish date']) . "</li>";
    echo "<li>" . htmlspecialchars($book['info']) . "</li>";
    echo "</ul>";
    echo "</div>";
}