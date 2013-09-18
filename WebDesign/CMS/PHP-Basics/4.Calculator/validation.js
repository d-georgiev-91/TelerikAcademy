function isNumber(number) {
  return !isNaN(parseFloat(number)) && isFinite(number);
}

function validateForm() {
	var firstNumber = document.forms["calculator-form"]["first-number"].value;
	var secondNumber = document.forms["calculator-form"]["second-number"].value;
	var operand = document.forms["calculator-form"]["operand"].value;

	if (firstNumber.length == 0 || secondNumber.length == 0 || operand.length == 0) {
		alert("Fields are empty!");
		return false;
	}
	
	if (!isNumber(firstNumber) || !isNumber(secondNumber)) {
		alert("Invalid numbers!");
		return false;
	}

	if (operand != '/' && operand != '%' && operand != '*' && operand != '+' && operand != '-') {
		alert("Invalid operand!");
		return false;
	}

	else if (secondNumber == 0 && (operand == '/' || operand == "%")) {
		alert("Invalid zero division!");
		return false;
	}

	return true;
}