<?php
$order = $_GET['order'];
$text = $_GET['students'];
$students = preg_split("/\r?\n/", $text, -1, PREG_SPLIT_NO_EMPTY);

for ($i = 0; $i < count($students); $i++) {
    $data = preg_split("/\s*,\s*/", $students[$i], -1, PREG_SPLIT_NO_EMPTY);
    $studentsArray[] = [
        'id' => $i + 1,
        'username' => trim($data[0]),
        'email' => $data[1],
        'type' => $data[2],
        'result' => intval($data[3])
    ];
}
$column = $_GET['column'];
switch ($column) {
    case 'id':
        usort($studentsArray, function($a, $b) {
            return $a['id'] > $b['id'];
        } );
        break;
    case 'username':
        usort($studentsArray, function($a, $b) {
            if ($a['username'] === $b['username']) {
                return $a['id'] > $b['id'];
            } else {
                return $a['username'] > $b['username'];
            }
        });
        break;
    case 'result':
        usort($studentsArray, function($a, $b) {
            if ($a['result'] === $b['result']) {
                return $a['id'] > $b['id'] ;
            } else {
                return $a['result'] > $b['result'];
            }
        });
        break;
}
if ($order === 'descending') {
    $studentsArray = array_reverse($studentsArray);
}

echo "<table>";
echo "<thead><tr><th>Id</th><th>Username</th><th>Email</th><th>Type</th><th>Result</th></tr></thead>";
for ($i = 0; $i < count($studentsArray); $i++) {
    echo "<tr><td>" . htmlspecialchars($studentsArray[$i]['id']) .
        "</td><td>" . htmlspecialchars($studentsArray[$i]['username']) .
        "</td><td>" . htmlspecialchars($studentsArray[$i]['email']) .
        "</td><td>" . htmlspecialchars($studentsArray[$i]['type']) .
        "</td><td>" . htmlspecialchars($studentsArray[$i]['result']) . "</td></tr>";
}
echo "</table>";