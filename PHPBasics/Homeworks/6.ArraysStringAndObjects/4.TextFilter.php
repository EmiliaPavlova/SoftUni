<!DOCTYPE html>
<html>
<head lang="en">
    <meta charset="UTF-8">
    <title>Text Filter</title>
    <style>
        textarea {
            width: 500px;
            height: 60px;
            display: block;
            margin: 5px 0;
        }
        input {
            display: block;
            margin: 5px 0;
        }
        section {
            width: 500px;
        }
    </style>
</head>
<body>

<form action="4.TextFilter.php" method="post">
    <label for="text">Text:</label>
    <textarea name="input" id="text"></textarea>
    <label for="ban">Banned words:</label>
    <input type="text" name="ban" id="ban" />
    <input type="submit" name="submit" id="submit" value="Filter text">
</form>
<section>
    <?php
    if (isset($_POST['submit']) && isset($_POST['input']) && isset($_POST['ban'])):
        $ban = explode(', ', $_POST['ban']);
        $output = $_POST['input'];
    foreach ($ban as $word) {
        $filtered = str_repeat('*', strlen($word));
        $output = str_replace($word, $filtered, $output);
    }
    echo htmlentities($output);
    endif;
    ?>
</section>

</body>
</html>