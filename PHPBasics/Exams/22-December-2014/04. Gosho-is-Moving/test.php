<?php

// $_GET['luggage'] = 'bags;bedroom;aaaa;49.99kgC|_|bags;bedroom;bbbb;1.99kgC|_|furniture;living room;pink couch;40.85kgC|_|furniture;bedroom;night table;1.12kgC|_|boxes;kitchen;plates;10.36kgC|_|boxes;kitchen;cups;10.36kgC|_|boxes;kitchen;tableware;7.6kgC|_|boxes;living room;glasses;3.32kgC|_|boxes;living room;dresses;4.32kgC|_|bags;hall;shoes;5.9kgC|_|';
// 
// $_GET['minWeight'] = '50';
// $_GET['maxWeight'] = '100';
// $_GET['typeLuggage'] = ['furniture', 'boxes', 'bags'];
// $_GET['room'] = 'living room';

$luggage = preg_split('/C\|_\|/', $_GET['luggage']);
$minWeight = (int)$_GET['minWeight']; // !!!
$maxWeight = (int)$_GET['maxWeight']; // !!!
$luggageType = $_GET['typeLuggage'];
$room = $_GET['room'];

$data = [];

for ($index = 0; $index < count($luggage); $index++) {
    if (empty($luggage[$index])) {
        continue;
    }

    $elements = preg_split('/\;/', $luggage[$index]);

    $elementLuggageType = $elements[0];
    $elementRoom = $elements[1];
    $elementName = $elements[2];
    $elementWeight = (int)preg_replace('/kg/', '', $elements[3]); // !!!!

    if (in_array($elementLuggageType, $luggageType)) {
        if ($elementRoom == $room) {
            if (!isset($data[$elementLuggageType])) {
                $data[$elementLuggageType] = [];
                $data[$elementLuggageType][$elementRoom] = [];
                $data[$elementLuggageType][$elementRoom][$elementName] = $elementWeight;
            } else {
                if (!isset($data[$elementLuggageType][$elementRoom])) {
                    $data[$elementLuggageType][$elementRoom] = [];
                    $data[$elementLuggageType][$elementRoom][$elementName] = $elementWeight;
                } else {
                    $data[$elementLuggageType][$elementRoom][$elementName] = $elementWeight;
                }
            }
        }
    }

}

ksort($data);
foreach ($data as $key => $value) {
    ksort($data[$key]);
    foreach ($data[$key] as $secondKey => $secondValue) {
        ksort($data[$key][$secondKey]);
    }

}

echo '<ul>';
foreach ($data as $type => $typeValue) {
    echo '<li>';
    echo "<p>$type</p>";

    echo '<ul>';
    foreach ($data[$type] as $room => $roomValue) {
        echo '<li>';
        echo "<p>$room</p>";

        echo '<ul>';
        $names = implode(', ', array_keys($data[$type][$room]));
        $values = array_sum($data[$type][$room]);
        if ($values >= $minWeight && $values <= $maxWeight) {
            echo '<li>';
            echo "<p>$names - ${values}kg</p>";
            echo '</li>';
        }

        echo '</ul>';
        echo '</li>';
    }

    echo '</ul>';

    echo '</li>';
}
echo '</ul>';

//<ul>
//    <li>
//        <p>boxes</p>
//        <ul>
//            <li>
//                <p>living room</p>
//                <ul>
//                    <li>
//                    <p>dresses, glasses - 7kg</p>
//                    </li>
//                </ul>
//            </li>
//        </ul>
//    </li>
//    <li>
//        <p>furniture</p>
//        <ul>
//            <li>
//                <p>living room</p>
//                <ul>
//                    <li>
//                        <p>pink couch - 40kg</p>
//                    </li>
//                </ul>
//            </li>
//        </ul>
//    </li>
//</ul>
