<!DOCTYPE html>
<html>
<head>
    <title>CV Generator</title>
    <style>
    </style>
</head>
<body>

<?php
$firstName = $_POST["first-name"];
$lastName = $_POST["last-name"];
$email = $_POST["email"];
$number = $_POST["tel"];
$company = $_POST["company-name"];
$progrLanguage = $_POST["programmingLanguage"];
$level = $_POST["programming-language-level"];
$language = $_POST["language"];
$compr = $_POST["Comprehension"];
$read = $_POST["Reading"];
$write = $_POST["Writing"];
$driver = implode(', ', $_POST["driver"]);

$personalInfo = "<table border=\"1\">" .
    "<tr><th colspan=\"2\">Personal Information</th></tr>".
    "<tr><td>First Name</td><td>$firstName</td></tr>".
    "<tr><td>Last Name</td><td>$lastName</td></tr>".
    "<tr><td>Email</td><td>$email</td></tr>".
    "<tr><td>Phone Number</td><td>$number</td></tr>".
    "<tr><td>Gender</td><td>${_POST["gender"]}</td></tr>".
    "<tr><td>Birth Date</td><td>${_POST["birth-date"]}</td></tr>".
    "<tr><td>Nationality</td><td>${_POST["nationality"]}</td></tr>";

$lastWork = "<table border=\"1\">" .
    "<tr><th colspan=\"2\">Last Work Position</th></tr>".
    "<tr><td>Company Name</td><td>${_POST["company-name"]}</td></tr>".
    "<tr><td>From</td><td>${_POST["work-from"]}</td></tr>".
    "<tr><td>To</td><td>${_POST["work-to"]}</td></tr></table>";

$compSkills = "<table border=\"1\">" .
    "<tr><th colspan=\"3\">Computer Skills</th></tr>".
    "<tr><td>Programming Languages</td>".
    "<td><table border=\"1\"><tr><th>Language</th><th>Skill Level</th></tr>";
for($i = 0; $i < count($progrLanguage); $i++) {
    $compSkills .= "<tr><td>$progrLanguage[$i]</td><td>$level[$i]</td></tr>";
}

$compSkills .= "</table></td></table>";

$otherSkills = "<table border=\"1\">" .
    "<tr><th colspan=\"5\">Other Skills</th></tr>".
    "<tr><td>Languages</td>".
    "<td><table border=\"1\"><tr><th>Language</th><th>Comprehension</th><th>Reading</th><th>Writing</th></tr>";
for($j = 0; $j < count($language); $j++){
    $otherSkills .= "<tr><td>$language[$j]</td><td>$compr[$j]</td><td>$read[$j]</td><td>$write[$j]</td></tr>";
}
$otherSkills .= "</table></td></tr><tr><td>Driver's license</td><td colspan='4'>$driver</td></tr></table>";


//var_dump($progrLanguage);
//var_dump($level);
//var_dump($language);
//var_dump($compr);
//var_dump($read);
//var_dump($write);


echo "<h1>CV</h1>";
echo $personalInfo;
echo $lastWork;
echo $compSkills;
echo $otherSkills;
?>

</body>
</html>