	function myFunc(str) {
		var arr = str.split("");
		var splitters = [" ", "\t", "?", "!", ":", ";", ",", "."];

		var wordsInString = [];
		var occuredChars = [];

		var resultArray = [];

		wordsInString = words(str, splitters);

		for (var i = 0; i < wordsInString.length; i++) {

			if (ArrayOccuredChars(wordsInString[i]).length > 0) {
				occuredChars.push(ArrayOccuredChars(wordsInString[i]));
			}
		}

		resultArray = splitWithSplittersArray(arr, occuredChars);

		return resultArray.join("");
	}

	function words (str, splitters) {
		var result = [];
		var words = [];
		var temp = [];
		var temp1 = "";

		for (var i = 0; i < str.length; i++) {

			for (var j = 0; j < splitters.length; j++) {
				if (str.charAt(i) == splitters[j]) {
					temp1 = temp.join("");
					(words == "") ? words.push(temp1): words.push(temp1.slice(1, temp1.length));
					temp.length = 0;
					break;
				}
			}

			temp.push(str.charAt(i));
		}

		temp1 = temp.join("");
		(words == "") ? words.push(temp1): words.push(temp1.slice(1, temp1.length));

		return words;
	}

	function ArrayOccuredChars (word) {
		var splWord = word.split("");
		var result = [];

		for (var i = 0; i < splWord.length; i++) {

			if (isOccuredMoreThanOne(word, splWord[i]) && !result.includes(splWord[i])) {
				result.push(splWord[i]);
			}
		}

		return result;
	}

	function isOccuredMoreThanOne (str, ch) {
		if (str.split(ch).length-1 > 1) {
			return true;
		}
		else {
			return false;
		}
	}

	function splitWithSplittersArray(array, splitters) {
		var result = [];

		for (var i = 0; i < array.length; i++) {
			
			var count1 = 0;
			var count2 = 0;
			for (var j = 0; j < splitters.length; j++) {
				if (array[i] != splitters[j]) {
					count1++;
				}
				if (array[i] == splitters[j]) {
					count2++;
				}				
			}

			if (count1 > 0 && count2 == 0) {
				result.push(array[i]);
			}
		}
		return result;
	}

	function Run(form) {
		var text = form.myText.value;
		var resText = myFunc(text);
		form.resultText.value = resText;
	}