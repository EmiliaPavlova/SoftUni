<!DOCTYPE html>
<html>
<head lang="en">
    <meta charset="UTF-8">
    <title>URL Replacer</title>
    <style>
        textarea {
            width: 500px;
            height: 60px;
            display: block;
            margin: 5px 0;
        }
        p {
            width: 500px;
        }
    </style>
</head>
<body>
<form action="6.URLReplacer.php" method="post">
    <label for="text">Text:</label>
    <textarea name="input" id="text"></textarea>
    <input type="submit" name="submit" id="submit" value="Replace">
</form>
<p>
    <?php
    if (isset($_POST['submit']) && isset($_POST['input'])):
        $text = $_POST['input'];
        $openingTag = "/<\\s*a\\s*href\\s*=\\s*\"([^\"]+)\"\\s*>/";
        preg_match_all($openingTag, $text, $matches);
        for ($i = 0; $i < count($matches[0]); $i++) {
            $text = preg_replace('<' . $matches[0][$i] . ">", "[URL=" . $matches[1][$i] . "]" , $text);
        }
        $text = preg_replace("/<\\s*\\/\\s*a\\s*>/", "[/URL]", $text);
        echo htmlentities($text);
    endif; ?>
</p>

</body>
</html>