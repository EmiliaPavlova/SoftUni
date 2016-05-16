<?php
$errorLog = $_GET['errorLog'];

preg_match_all('/Exception in thread "(.*?)" java\.(?:.*\.)*(.*):(?:.*)\n\s+at\s*(?:.*?)\.(.*?)\((.*?):(\d+)\)/',
    $errorLog, $exceptionArray);

echo "<ul>";
for ($i = 0; $i < count($exceptionArray[0]); $i++) {
    echo "<li>line <strong>" . $exceptionArray[5][$i] . "</strong> - <strong>" .
        $exceptionArray[2][$i] . "</strong> in <em>" . $exceptionArray[4][$i] . ":" .
        $exceptionArray[3][$i] . "</em></li>";
}
echo "</ul>";