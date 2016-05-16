<?php
$data = explode(',', $_GET['data']);
$gold = 0;
$silver = 0;
$diamonds = 0;
foreach ($data as $line) {
    $mines = preg_split('/\s+/', $line, -1, PREG_SPLIT_NO_EMPTY);
    $mine = trim($mines[0]);
    $mineName = trim($mines[1]);
    $oreType = trim(strtolower($mines[2]));
    $quantity = trim($mines[3]);

    if ($mine === 'mine' && is_numeric($quantity)){
        switch ($oreType) {
            case 'gold':
                $gold += $quantity;
                break;
            case 'silver':
                $silver += $quantity;
                break;
            case 'diamonds':
                $diamonds += $quantity;
                break;
        }
    }
}
echo "<p>*Gold: $gold</p>";
echo "<p>*Silver: $silver</p>";
echo "<p>*Diamonds: $diamonds</p>";

//var_dump($gold);
//var_dump($silver);
//var_dump($diamonds);
