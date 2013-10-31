<?php

mb_internal_encoding('UTF-8');

function registerUser() {
    if ($_POST) {
        $username = $_POST['username'];
        $password = $_POST['password'];
        validateUserCredentials($username, $password);
        $connection = connectToDatabase();
        registerUserInDatabase($username, $password, $connection);
        $_SESSION['username'] = $username;
        header('Location: index.php');
        exit;
    }
}

function registerUserInDatabase($username, $password, $connection) {
    $statement = mysqli_prepare($connection, 'INSERT INTO Users (Username, Password) Values(?,?)');
    mysqli_stmt_bind_param($statement, 'ss', $username, $password);
    mysqli_stmt_execute($statement);

    if (mysqli_errno($connection) == 1062) {
        throw new Exception('The username "' . $username . '" is already registered!');
    }
}

function connectToDatabase() {
    $connection = mysqli_connect('localhost', 'admin', 'admin', 'MessageSystem');

    if (!$connection) {
        throw new Exception('No connection with database!');
    }

    mysqli_set_charset($connection, 'utf8');

    return $connection;
}

function validateUserCredentials(&$username, &$password) {
    validateUsername($username);
    validatePassword($password);
}

function validateUsername(&$username) {
    if (mb_strlen($username) < MIN_USERNAME_LENGTH) {
        throw new Exception('Username should be at least' . MIN_USERNAME_LENGTH . ' characters!');
    }

    if (mb_strlen($username) > MAX_USERNAME_LENGTH) {
        throw new Exception('Username should be at less than' . MAX_USERNAME_LENGTH . ' characters!');
    }

    $username = htmlspecialchars($username);
    $username = trim($username);
    $username = mb_strtolower($username, 'UTF-8');
}

function validatePassword(&$password) {
    if (mb_strlen($password) < MIN_PASSWORD_LENGTH) {
        throw new Exception('Password should be at least ' . MIN_PASSWORD_LENGTH . ' characters!');
    }

    if (mb_strlen($password) > MAX_PASSWORD_LENGTH) {
        throw new Exception('Password should be less than ' . MAX_PASSWORD_LENGTH . ' characters!');
    }
}

function loginUser() {
    if ($_POST) {
        $username = $_POST['username'];
        $password = $_POST['password'];
        validateUserCredentials($username, $password);

        $connection = connectToDatabase();
        $realPassword = getUserPassword($username, $connection);

        if ($password != $realPassword) {
            throw new Exception('Invalid password!');
        }

        $_SESSION['username'] = $username;
        header('Local: messages.php');
        exit;
    }
}

function logout() {
    if (isset($_POST['logout'])) {
        session_destroy();
        header('Local: index.php');
        exit;
    }
}

function getMessages() {
    $username = $_SESSION['username'];
    $connection = connectToDatabase();
    $statement = mysqli_prepare($connection, 'SELECT u.Username as Author, m.CreatedDate, m.Title, m.Body FROM Users u
                JOIN Messages m
                        ON m.AuthorId = u.UserId
            WHERE m.RecieverId = (SELECT UserId FROM Users WHERE Username = ?)
            ORDER BY CreatedDate ASC');
    mysqli_stmt_bind_param($statement, 's', $username);
    mysqli_stmt_bind_result($statement, $author, $dateCreated, $title, $body);
    mysqli_stmt_execute($statement);
    $messages = NULL;

    while (mysqli_stmt_fetch($statement)) {
        $message['author'] = $author;
        $message['dateCreated'] = date("Y M d H:i:s", strtotime($dateCreated));
        $message['title'] = $title;
        $message['body'] = $body;
        $messages[] = $message;
    }

    return $messages;
}

function getUserPassword($username, $connection) {
    $statement = mysqli_prepare($connection, 'SELECT Password FROM Users Password WHERE Username=?');
    mysqli_stmt_bind_param($statement, 's', $username);
    mysqli_stmt_execute($statement);
    $password = NULL;
    mysqli_stmt_bind_result($statement, $password);
    mysqli_stmt_fetch($statement);

    if ($password == NULL) {
        throw new Exception('Invalid username. User "' . $username .
        '" does not seem to be registered');
    }

    return $password;
}

function getUsers() {
    $connection = connectToDatabase();
    $statement = mysqli_prepare($connection, 'SELECT UserId, Username FROM Users');
    mysqli_stmt_execute($statement);
    mysqli_stmt_bind_result($statement, $userId, $username);
    $users = NULL;

    while (mysqli_stmt_fetch($statement)) {
        $user['userId'] = $userId;
        $user['username'] = $username;
        $users[] = $user;
    }

    return $users;
}

function validateTitle(&$title) {
    if (mb_strlen($title) < MIN_TITLE_LENGTH) {
        throw new Exception('Title shoud be at least ' . MIN_MESSAGE_LENGTH_TITLE_LENGTH . ' characters!');
    }

    if (mb_strlen($title) > MAX_TITLE_LENGTH) {
        throw new Exception('Title shoud be less than ' . MAX_TITLE_LENGTH . ' characters!');
    }

    $title = htmlspecialchars($title);
}

function validateMessage(&$message) {
    if (mb_strlen($message) < MIN_MESSAGE_LENGTH) {
        throw new Exception('Message shoud be at least ' . MIN_MESSAGE_LENGTH . ' characters!');
    }

    if (mb_strlen($message) > 250) {
        throw new Exception('Message shoud be less than '. MAX_MESSAGE_LENGTH . ' characters!');
    }

    $message = htmlspecialchars($message);
}

function sendMessage() {
    if ($_POST) {
        $message = $_POST['message'];
        validateMessage($message);
        $title = $_POST['title'];
        $userId = $_POST['selectedUser'];
        validateTitle($title);

        if (!userExists($userId)) {
            throw new Exception('User does not exists!');
        }

        $date = date("Y-m-d H:i:s");
        $connection = connectToDatabase();
        $statement = mysqli_prepare($connection, 'INSERT INTO Messages (Title, Body, CreatedDate, AuthorId, RecieverId) 
                 VALUES (?, ?, ?, (SELECT UserId FROM Users WHERE Username = ?), ?)');
        mysqli_stmt_bind_param($statement, 'sssss', $title, $message, $date, $_SESSION['username'], $userId);
        mysqli_stmt_execute($statement);
    }
}

function userExists($userId) {
    $connection = connectToDatabase();
    $statement = mysqli_prepare($connection, 'SELECT Username 
             FROM Users
             WHERE UserId = ?');
    mysqli_stmt_bind_param($statement, 'i', $userId);
    mysqli_stmt_execute($statement);
    $username = NULL;
    mysqli_stmt_bind_result($statement, $username);
    $username = mysqli_stmt_fetch($statement);

    return $username;
}