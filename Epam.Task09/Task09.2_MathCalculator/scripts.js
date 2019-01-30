function Run(form) {
	var text = form.myText.value;
	var resText = myFunc(text);
	form.resultText.value = resText;
}

function myFunc(str) {
	var regOperand = /\d+(\.\d+)?/g;
	var regOperator = /[\+\-\*\/]/g;
	var arrOperands = str.match(regOperand);
	var arrOperators = str.match(regOperator);

	var result=0;

	if (str.substring(str.length, str.length-1) != "=") {
		alert("You should put equals symbol ('=') at the end of the expression!")
	}
	else {

	for (var i = 0; i < arrOperands.length; i++) {

		if (i == 0) {
			result += parseFloat(arrOperands[i]);
			continue;
		}

		switch (arrOperators[i-1]){

			case "+": 
			result += parseFloat(arrOperands[i]);
			break;

			case "-": 
			result -= parseFloat(arrOperands[i]);
			break;

			case "*": 
			result *= parseFloat(arrOperands[i]);
			break;

			case "/": 
			if (parseFloat(arrOperands[i]) == 0) {
				alert("Division by zero");
				break;
			}
			
			else {
			result /= parseFloat(arrOperands[i]);
			break;				
			}
		}
	}

	}

	return result.toFixed(2);
}