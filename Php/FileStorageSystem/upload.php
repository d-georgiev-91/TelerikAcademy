<?php
session_start();
$pageTitle = 'Upload';
include './includes/header.php';
?>

<a href="files.php">Go to files</a>

<?php
if (!array_key_exists('isLogged', $_SESSION) || !$_SESSION['isLogged']) {
    echo '<h1>Forbidden</h1>';
} else {

    if ($_FILES) {
        $userDirectoryPath = $FILESTORAGE . DIRECTORY_SEPARATOR . $USERNAME;
        if (!realpath($userDirectoryPath)) {
            mkdir($userDirectoryPath);
        }

        move_uploaded_file($_FILES['file']['tmp_name'], 
                realpath($userDirectoryPath) .
                DIRECTORY_SEPARATOR . $_FILES['file']['name']);
        echo '<p>File successfully uploaded.</p>';
    }
    ?>
    <form method="POST" enctype="multipart/form-data">
        <input type="file" name="file" />
        <input type="submit" value="upload" />
    </form>
    <?php
}

include './includes/footer.php';
?>