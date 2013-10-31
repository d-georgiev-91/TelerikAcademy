<?php

mb_internal_encoding('UTF-8');

function render($data, $name) {
    include $name;
}

function connectToDatabase() {
    $connection = mysqli_connect('localhost', 'admin', 'admin', 'books');

    if (!$connection) {
        throw new Exception('No connection with database!');
    }

    mysqli_set_charset($connection, 'utf8');

    return $connection;
}

function getBooks($connection) {
    if (isset($_GET['author_id'])) {
        $statement = mysqli_prepare($connection, 'SELECT b.book_id, b.book_title, a.author_id, a.author_name FROM books as b 
            INNER JOIN books_authors as ba 
                ON b.book_id=ba.book_id 
                    INNER JOIN authors as a
                        ON a.author_id=ba.author_id 
        WHERE a.author_id=?');
        mysqli_stmt_bind_param($statement, 'i', $_GET['author_id']);
    } else {
        $statement = mysqli_prepare($connection, 'SELECT b.book_id, b.book_title, a.author_id, a.author_name FROM books as b 
            INNER JOIN books_authors as ba 
                ON b.book_id=ba.book_id 
                    INNER JOIN authors as a
                        ON a.author_id=ba.author_id');
    }

    mysqli_stmt_execute($statement);
    mysqli_stmt_bind_result($statement, $bookId, $bookTitle, $authorId, $authorName);
    $books = [];
    while (mysqli_stmt_fetch($statement)) {
        $books[$bookId]['bookTitle'] = $bookTitle;
        $books[$bookId]['authors'][$authorId] = $authorName;
    }

    return $books;
}

function getAuthors($connection) {
    $statement = mysqli_prepare($connection, 'SELECT author_id, author_name FROM authors');
    mysqli_execute($statement);
    mysqli_stmt_bind_result($statement, $authorId, $authorName);

    while (mysqli_stmt_fetch($statement)) {
        $authors[$authorId] = $authorName;
    }

    return $authors;
}

function addAuthor($authorName, $connection) {
    validateAuthorName($authorName);

    if (authorExists($authorName, $connection)) {
        throw new Exception('Author with name: "' . $authorName . '" exists');
    }

    $statement = mysqli_prepare($connection, 'INSERT INTO authors (author_name) VALUES (?)');
    mysqli_stmt_bind_param($statement, 's', $authorName);
    mysqli_execute($statement);
}

function authorExists($authorName, $connection) {
    $authorName = mb_strtolower($authorName);
    $statement = mysqli_prepare($connection, 'SELECT COUNT(*) as authors_count FROM authors WHERE LOWER(author_name) = ?');
    mysqli_stmt_bind_param($statement, 's', $authorName);
    mysqli_execute($statement);
    mysqli_stmt_bind_result($statement, $count);
    mysqli_stmt_fetch($statement);
    if ($count > 0) {
        return true;
    } else {
        return false;
    }
}

function validateAuthorName(&$authorName) {
    $authorName = htmlspecialchars($authorName);

    //TO DO LEGNTH CHECK
}

function addBook($bookName, $authors, $connection) {
    valideteBookName($bookName);
    if (!authorsIdsExists($authors, $connection)) {
        throw new Exception('Invalid authors.');
    }

    mysqli_query($connection, 'INSERT INTO books (book_title) VALUES("' .
            mysqli_real_escape_string($connection, $bookName) . '")');
        
    $bookId = mysqli_insert_id($connection);
    
    foreach ($authors as $authorId) {
        mysqli_query($connection, 'INSERT INTO books_authors (book_id,author_id)
                VALUES (' . $bookId . ',' . $authorId . ')');
    }
}

function valideteBookName(&$bookName) {
    $bookName = htmlspecialchars($bookName);
    //TO DO LEGNTH CHECK
}

function authorsIdsExists($ids, $connection) {
    if (!is_array($ids)) {
        return false;
    }

    $q = mysqli_query($connection, 'SELECT * FROM authors WHERE 
        author_id IN(' . implode(',', $ids) . ')');

    if (mysqli_error($connection)) {
        return false;
    }

    if (mysqli_num_rows($q) == count($ids)) {
        return true;
    }

    return false;
}