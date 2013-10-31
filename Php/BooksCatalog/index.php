<?php

include './include/functions.php';
$page = '';
$connection = connectToDatabase();
session_start();
if (isset($_GET['p'])) {
    switch ($_GET['p']) {
        case 'index':
            $page = 'index_public';
            $data['books'] = getBooks($connection);
            $data['title'] = 'Книги';
            break;
        case 'authors':
            $page = 'authors';

            if ($_POST) {
                addAuthor($_POST['authorName'], $connection);
            }

            $data['title'] = 'Нов автор';
            $data['authors'] = getAuthors($connection);
            break;
        case 'add_book':
            $page = 'add_book';
            if ($_POST) {
                if (!isset($_POST['authors'])) {
                    $_POST['authors'] = '';
                }

                addBook($_POST['bookName'], $_POST['authors'], $connection);
            }

            $data['title'] = 'Нова книга';
            $data['authors'] = getAuthors($connection);
            break;
        case 'register':
            $page = 'register';
            if (isset($_SESSION['username'])) {
                header('Location: index.php');
            }
            
            if ($_POST) {
                registerUser($_POST['userName'], $_POST['password']);
            }
            break;
        default:
            $page = 'index_public';
            $data['books'] = getBooks($connection);
            $data['title'] = 'Книги';
            break;
    }
} else {
    $page = 'index_public';
    $data['books'] = getBooks($connection);
    $data['title'] = 'Книги';
}

render($data, 'views/' . $page . '.php');