var timeoutId;
var myTimer = 10;

function startTimeout (url) {
	myTimer = 10;
	countdown();
	timeoutId = setTimeout(newPage, 10000, url);
}

function stopTimeout () {
	window.clearTimeout(timeoutId);
	myTimer=undefined;
}

function newPage (url) {

	location.assign(url);
}

function countdown () {

	document.getElementById("timer").innerHTML = myTimer;
	myTimer--;
	setTimeout(countdown,1000);
}