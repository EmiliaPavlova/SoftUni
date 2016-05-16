<!DOCTYPE html>
<html>
<head>
    <title>CV Generator</title>
    <style>
        .kur {
            border: solid;
        }
    </style>
</head>
<body>

<?php if (!isset($_POST['languages'])): ?>
    <form method="POST">
        <input type="text" name="languages[]" /> <br/>
        <input type="text" name="languages[]" /> <br/>
        <input type="text" name="languages[]" /> <br/>
        <input type="text" name="languages[]" /> <br/>
        <input type="text" name="languages[]" /> <br/>
        <input type="submit">
    </form>
<?php else: ?>
    <table class="kur">
        <tr>
            <th>Language</th>
        </tr>
        <?php foreach ($_POST['languages'] as $language): ?>
        <tr>
            <td> <?= $language; ?></td>
        </tr>
        <?php endforeach; ?>
    </table>
<?php endif; ?>