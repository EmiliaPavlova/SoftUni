<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <title>Awesome Calendar</title>
    <link rel="stylesheet" type="text/css" href="9.style.css">
</head>
<body>

    <?php

    function showCalendar($monthToShow = null, $yearToShow = null, $firstDayOfWeek = 0){
        if (($monthToShow == null) or ($yearToShow == null)) {
            $today = getdate();
            $monthToShow = $today['mon'];
            $yearToShow = $today['year'];
        }
        else {
            $today = getdate(mktime(0,0,0,$monthToShow,1,$yearToShow));
        }
        // get first and last days of the month
        $firstDay = getdate(mktime(0, 0, 0, $monthToShow, 1, $yearToShow));
        $lastDay  = getdate(mktime(0, 0, 0, $monthToShow + 1, 0, $yearToShow));

        $month_names = array(1 => 'Януари', 'Февруари', 'Март', 'Април', 'Май', 'Юни', 'Юли', 'Август',
            'Септември', 'Октомври', 'Ноември', 'Декември');

        echo '<div class = cal><table>';

        echo '<tr><th colspan = "7">';
        for ($m = $monthToShow; $m <= $monthToShow; $m++) {
            echo $month_names[$m];
        }
        echo "</th></tr>";

        echo '<tr class = "days">';
        $dayText = array (1 => 'Пн', 'Вт', 'Ср', 'Чт', 'Пт', 'Сб', 'Нд');

        for ($i = 0; $i < 7; $i++){
            echo '<td>' . $dayText[$firstDayOfWeek + $i] . '</td>';
        }
        echo '</tr><tr>';
        if ( $firstDayOfWeek <= $firstDay['wday'] ) {
            $blanks = $firstDay['wday'] - $firstDayOfWeek;
        }
        else {
            $blanks = $firstDay['wday'] - $firstDayOfWeek + 7;
        }
        for($i = 1; $i <= $blanks; $i++){
            echo '<td class="noday"></td>';
        }
        $actday = 0;

        for( ;$i <= 7; $i++){
            echo '<td class=hasday>' . ++$actday . '</td>';
        }
        echo '</tr>';

        // Get how many complete weeks are in the actual month
        $fullWeeks = floor(($lastDay['mday'] - $actday) / 7);
        for ($i = 0; $i < $fullWeeks; $i++) {
            echo '<tr>';
            for ($j = 0; $j < 7; $j++) {
                echo '<td class = hasday>' . ++$actday . '</td>';
            }
            echo '</tr>';
        }

        //display the partial last week of the month (if there is one)
        if ($actday < $lastDay['mday']){
            echo '<tr>';
            $actday++;
            for ($i = 0; $i < 7; $i++) {
                if ($actday <= $lastDay['mday']) {
                    echo '<td class = hasday>' . $actday++ . '</td>';
                }
                else {
                    echo '<td class = "noday"></td>';
                }
            }
            echo '</tr>';
        }
        echo '</table></div>';
    }

    $thisDay = getdate();
    $startMonth = 1;
    $startYear = $thisDay['year'];

    echo '<h1>' . $startYear . '</h1>';
    for ($block = 1; $block <= 3; $block++) { // there are 3 blocks
        echo '</br>';
        echo '<div class = "calblock"><table><tr>';
        for ($calcount=1; $calcount <=4; $calcount++) { // each block holds 4 months
            echo '<td class = "onecal">';
            showCalendar($startMonth++, $startYear, 1 /* start all weeks on Monday (1) */);
            echo '</td>';
        }
        echo '</tr></table></div>';
    }
    ?>

</body>
</html>