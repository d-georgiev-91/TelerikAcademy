<?php

mb_internal_encoding('UTF-8');

function validateName(&$name) {
    $name = trim($name);
    if (mb_strlen($name) < 4) {
        return false;
    }

    $name = htmlspecialchars($name);

    return true;
}

function validateSum(&$sum) {
    $sum = str_replace(',', '.', $sum);

    if (!is_numeric($sum)) {
        return false;
    }

    if ((float)$sum < 0) {
        return false;
    }

    return true;
}

function validateSelectedExpenseType($selectedExepnse) {
    global $expenses;
    if (array_key_exists($selectedExepnse, $expenses)) {
        return true;
    }

    return false;
}