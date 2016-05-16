<?php
$childName=$_GET['childName'];
$wantedPresent=$_GET['wantedPresent'];
//var_dump($wantedPresent);
$riddles=explode( ';',$_GET['riddles']);
$riddle;
$namecheck = str_split($childName);
foreach ($namecheck as $value) {
    if ($value==' ') {
        $value='-';
    }
}
for ($i=0, $x=0; $i <sizeof($namecheck); $i++,$x++) {
    if ($x==sizeof($riddles)) {
        $x=0;
    }
    $riddle=$riddles[$x];
}
$childName=htmlspecialchars($childName);
$wantedPresent=htmlspecialchars($wantedPresent);
$riddle=htmlspecialchars($riddle);
$result="\$giftOf$childName = $[wasChildGood] ? '$wantedPresent' : '$riddle';";
echo $result;
?>