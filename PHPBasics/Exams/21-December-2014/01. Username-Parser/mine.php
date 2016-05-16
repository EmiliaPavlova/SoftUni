<?php
$list = $_GET['list'];
$length = intval($_GET['length']);
$list = trim($list);
$list = preg_split('/\r?\n/', $list, -1, PREG_SPLIT_NO_EMPTY);

echo "<ul>";
foreach ($list as $name) {
    if (strlen($name) >= $length) {
        echo "<li>" . htmlspecialchars($name) . "</li>";
    } else if (isset($_GET['show'])) {
        echo "<li style=\"color: red;\">" . htmlspecialchars($name) . "</li>";
    }
}
echo "</ul>";