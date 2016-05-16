<?php
$fruit = $_GET['fruit'];
$ascii;
for ($i = 0; $i < strlen($fruit); $i++)
{
    $ascii += ord($fruit[$i]);
}
//var_dump($ascii);
$tail = substr($ascii, 0, 1);
$head = substr($ascii, strlen($ascii) - 1, 1);
echo ">>";
for ($i = 0; $i < $tail; $i++) {
    echo "-";
}
echo "($fruit)";
for ($i = 0; $i < $head; $i++) {
    echo "-";
}
echo ">";