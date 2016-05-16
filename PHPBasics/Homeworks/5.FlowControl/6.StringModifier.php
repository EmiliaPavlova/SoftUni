<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <title>Modify String</title>
</head>
<body>

<form action="6.StringModifier.php" method="post">
    <input type="input" id="input" name="input" required="required">
    <input type="radio" name="option" value="palindrome" id="palindrome" required="required" />
    <label for="palindrome">Check Palindrome</label>
    <input type="radio" name="option" value="reverse" id="reverse" />
    <label for="reverse">Reverse String</label>
    <input type="radio" name="option" id="split" value="split" />
    <label for="split">Split</label>
    <input type="radio" name="option" id="hash" value="hash" />
    <label for="hash">Hash String</label>
    <input type="radio" name="option" id="shuffle" value="shuffle" />
    <label for="shuffle">Shuffle String</label>
    <input type="submit" name="submit">
</form>

<p>
    <?php
    if (isset($_POST['submit']) && $_POST['input'] != '') {
        $option = $_POST['option'];
        $string = $_POST['input'];

        if ($option === 'palindrome') {
            $reversed = array_reverse(str_split($string));
            $reversed = implode("", $reversed);
            if ($reversed === $string) {
                echo htmlentities($string) . ' is a palindrome!';
            } else {
                echo htmlentities($string) . ' is not a palindrome!';
            }
        } else if ($option === 'reverse') {
            $reversed = array_reverse(str_split($string));
            $reversed = implode("", $reversed);
            echo htmlentities($reversed);
        } else if ($option === 'split') {
            $split = implode(' ', str_split($string));
            echo htmlentities($split);
        } else if ($option === 'hash') {
            echo crypt($string);
        } else {
            $shuffledArray = str_split($string);
            shuffle($shuffledArray);
            $newString = implode('', $shuffledArray);
            echo htmlentities($newString);
        }
    }
    ?>
</p>
</body>
</html>
