<?php 
	
	/*
	 * !!Caution!!!
	 * The path the index.html may be different, depending on your server configuration!
	 */
 
	if( empty( $_POST['first-number'] ) && $_POST['first-number'] != 0 || 
		empty( $_POST['operand'] ) || 
		empty( $_POST['second-number'] ) && $_POST['second-number'] != 0) {
	    	header('Location: http://localhost/PHP-Basics/');
	}

	$firstNumber = $_POST['first-number'];
	$operand = $_POST['operand'];
	$secondNumber = $_POST['second-number'];

	$acceptedOperands = array( '+', '-', '*', '/', '%' );
 
	if( ! is_numeric( $firstNumber ) || ! is_numeric( $secondNumber ) || ! in_array( $operand, $acceptedOperands ) ) {
    	header('Location: http://localhost/PHP-Basics/');
	}

	elseif ($secondNumber == 0 && ($operand == '%' || $operand == '/')) {
		header('Location: http://localhost/PHP-Basics/');	
	}

	eval('$result='.$firstNumber.$operand.$secondNumber.';');
	echo "$firstNumber $operand $secondNumber = ".$result;
?>