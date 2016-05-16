<?php
$list = preg_split("/\r?\n/", $_GET['list']);
$minPrice = $_GET['minPrice'];
$maxPrice = $_GET['maxPrice'];
$filter = $_GET['filter'];
$order = $_GET['order'];

$id = 1;
$products = [];
foreach ($list as $item) {
    $data = preg_split("/\s*\|\s*/", $item, -1, PREG_SPLIT_NO_EMPTY);
    $price = floatval($data[3]);
    if ($price >= $minPrice && $price <= $maxPrice) {
        $product = $data[0];
        $type = $data[1];
        $components = explode(", ", $data[2]);
        $products[] = [$product, $id, $type, $components, $price];
    }
    $id++;

}

if ($filter !== 'all') {
    $products = array_filter($products, function($item) use ($filter) {
        return $filter === $item[2];
    });
}

usort($products, function($a, $b) use ($order) {
    $modifier = ($order === 'ascending') ? 1 : -1;

    if ($a[4] < $b[4]) {
        return -1 * $modifier;
    }
    if ($a[4] > $b[4]) {
        return 1 * $modifier;
    }
    if ($a[4] === $b[4]) {
        return $a[1] - $b[1];
    }
});

foreach ($products as $prod) {
//    var_dump($prod);
    echo "<div class=\"product\" id=\"product$prod[1]\">";
    echo "<h2>" . htmlspecialchars($prod[0]) . "</h2>";
    echo "<ul>";
    foreach ($prod[3] as $component) {
        echo "<li class=\"component\">" . htmlspecialchars($component) . "</li>";
    }
    echo "</ul>";
    echo "<span class=\"price\">" . number_format($prod[4], 2, '.', '') . "</span>";
    echo "</div>";
}


//var_dump($products);