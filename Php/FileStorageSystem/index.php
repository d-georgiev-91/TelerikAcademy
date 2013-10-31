<?php
session_start();
$pageTitle = 'Login';
include './includes/header.php';



if (array_key_exists('isLogged', $_SESSION) && $_SESSION['isLogged']) {
    header('Location: files.php');
    exit;
}

if ($_POST) {
    $currentUsername = $_POST['username'];
    $currentPassword = $_POST['password'];

    if (!isUsernameValid($currentUsername)) {
        echo '<p>Invalid username</p>';
    } else if (!isPasswordValid($currentPassword)) {
        echo '<p>Invalid password</p>';
    } else {
        $_SESSION['isLogged'] = true;
        header('Location: files.php');
        exit;
    }
}
?>
<form id="login-form" method="POST">
    <label>Username: <input type="text" name="username"></label>
    <label>Password: <input type="password" name="password"></label>
    <input type="submit" value="Login" />
</form>
<?php
include './includes/footer.php';
?>