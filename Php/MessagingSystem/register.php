<?php
session_start();
$pageTitle = 'Register';
include './includes/header.php';

try {
    registerUser();
} catch (Exception $exc) {
    echo $exc->getMessage();
}
?>
<form method="POST">
    <fieldset>
        <legend>Register</legend>
        <label for="username">Username:</label>
        <input id="username" name="username" type="text" />
        <label for="password">Password:</label>
        <input id="password" name="password" type="password" />
        <input type="submit" value="Register" />
    </fieldset>
</form>
<?php include './includes/footer.php'; ?>