<?php
session_start();
$pageTitle = 'Login';
include './includes/header.php';
if (isset($_SESSION['username'])) {
    header('Location: messages.php');
    exit;
} 

try {
    loginUser();
} catch (Exception $exc) {
    echo $exc->getMessage();
}

?>
<form method="POST">
    <fieldset>
        <legend>Login</legend>
        <label for="username">Username:</label>
        <input id="username" name="username" type="text" />
        <label for="password">Password:</label>
        <input id="password" name="password" type="password" />
        <input type="submit" value="Login" />
        <a href="register.php">Register</a>
    </fieldset>
</form>
<?php include './includes/footer.php'; ?>