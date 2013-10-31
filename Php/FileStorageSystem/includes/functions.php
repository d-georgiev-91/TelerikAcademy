<?php
    function isUsernameValid($username) {
        $username = normalizeData($username);
        global $USERNAME;
        
        return strtolower($username) == strtolower($USERNAME);
    }
    
    function isPasswordValid($password) {
        $password = normalizeData($password);
        global $PASSWORD;
        
        return strtolower($password) == strtolower($PASSWORD);
    }
    
    function normalizeData($data) {
        $data = trim($data);
        $data = htmlspecialchars($data);
        
        return $data;
    }
    
    function isEmptyDir($dir){ 
        $files = scandir($dir);
        return $files && count($files) <= 2; 
    } 