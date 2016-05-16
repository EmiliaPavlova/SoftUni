<!DOCTYPE html>
<html>
<head lang="en">
    <meta charset="UTF-8">
    <title>Sentence Extractor</title>
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
        p {
            width: 500px;
        }
    </style>
</head>
<body>
<form action="5.SentenceExtractor.php" method="post">
    <label for="text">Text:</label>
    <textarea name="input" id="text"></textarea>
    <label for="word">Word:</label>
    <input type="text" name="word" id="word" />
    <input type="submit" name="submit" id="submit" value="Extract">
</form>
<?php
if (isset($_POST['submit']) && isset($_POST['input']) && isset($_POST['word'])):
    $word = $_POST['word'];
    $pattern = "/\\b[^.!?]*\\b" . $word . "\\b[^.!?]*[?!.]/";
    preg_match_all($pattern, $_POST['input'], $matches);
    if (count($matches) > 0):
        foreach ($matches[0] as $sentence): ?>
            <p><?php echo htmlentities($sentence); ?></p>
        <?php endforeach; ?>

    <?php else: ?>
        <p>No results found!</p>
    <?php endif;
endif; ?>

</body>
</html>