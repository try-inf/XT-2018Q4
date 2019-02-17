function createUser() {
    document.getElementById('inputForm').style.display = 'block';
    document.getElementById('label2').style.display = 'block';
    document.getElementById('input2').style.display = 'block';
    document.getElementById('devResult').innerHTML = ''; 
    document.getElementById('label1').innerHTML = 'Enter the name of User:';
    document.getElementById('label2').innerHTML = 'Enter date of birth(in format dd- mm - yyyy or dd.mm.yyyy):';

    var $inputParam1 = $("input[id=input1]"),
        $inputParam2 = $("input[id=input2]"),
        $result = $("#result");

    $("#inputForm").submit(function () {
        $.ajax({
            method: "POST",
            url: "/Pages/AddUserAjax",
            data: { param1: $inputParam1.val(), param2: $inputParam2.val() },
            success: function (response) {
                document.getElementById('devResult').innerHTML = response;
            },
        })
        return false;
    })
    document.getElementById('input1').innerText = "";
    document.getElementById('input2').innerText = "";
}

function showUsers() {
    document.getElementById('inputForm').style.display = 'none';
    document.getElementById('devResult').innerHTML = ''; 

    $.ajax({
        method: "POST",
        url: "/Pages/ShowUsersAjax",
        success: function (response) {
            document.getElementById('devResult').innerHTML = response;
        },
    })
}

function removeUser() {
    document.getElementById('inputForm').style.display = 'block';
    document.getElementById('label1').innerHTML = 'Enter the Id of user you want to remove:';
    document.getElementById('label2').style.display = 'none';
    document.getElementById('input2').style.display = 'none';
    document.getElementById('devResult').innerHTML = '';

    var $inputParam1 = $("input[id=input1]"),
        $result = $("#result");

    $("#inputForm").submit(function () {
        $.ajax({
            method: "POST",
            url: "/Pages/RemoveUserAjax",
            data: { param1: $inputParam1.val() },
            success: function (response) {
                document.getElementById('devResult').innerHTML = response;
            },
        })
        return false;
    })
    document.getElementById('input1').innerText = "";
}

function createAward() {
    document.getElementById('inputForm').style.display = 'block';
    document.getElementById('label1').innerHTML = 'Enter the title of award:';
    document.getElementById('label2').style.display = 'none';
    document.getElementById('input2').style.display = 'none';
    document.getElementById('devResult').innerHTML = ''; 

    var $inputParam1 = $("input[id=input1]"),
        $result = $("#result");

    $("#inputForm").submit(function () {
        $.ajax({
            method: "POST",
            url: "/Pages/AddAwardAjax",
            data: { param1: $inputParam1.val() },
            success: function (response) {
                document.getElementById('devResult').innerHTML = response;
            },
        })
        return false;
    })
    document.getElementById('input1').innerText = "";
}

function showAwards() {
    document.getElementById('inputForm').style.display = 'none';
    document.getElementById('devResult').innerHTML = '';

    $.ajax({
        method: "POST",
        url: "/Pages/ShowAwardsAjax",
        success: function (response) {
            document.getElementById('devResult').innerHTML = response;
        },
    })
}

function awardUser() {
    document.getElementById('inputForm').style.display = 'block';
    document.getElementById('label2').style.display = 'block';
    document.getElementById('input2').style.display = 'block';
    document.getElementById('devResult').innerHTML = '';
    document.getElementById('label1').innerHTML = 'Enter the Id of User you want to award:';
    document.getElementById('label2').innerHTML = 'Enter the Id of Award you want to award with:';

    var $inputParam1 = $("input[id=input1]"),
        $inputParam2 = $("input[id=input2]"),
        $result = $("#result");

    $("#inputForm").submit(function () {
        $.ajax({
            method: "POST",
            url: "/Pages/AwardUserAjax",
            data: { param1: $inputParam1.val(), param2: $inputParam2.val() },
            success: function (response) {
                document.getElementById('devResult').innerHTML = response;
            },
        })
        return false;
    })
    document.getElementById('input1').innerText = "";
    document.getElementById('input2').innerText = "";
}

function showDetails() {
    document.getElementById('inputForm').style.display = 'block';
    document.getElementById('label1').innerHTML = 'Enter the Id of user:';
    document.getElementById('label2').style.display = 'none';
    document.getElementById('input2').style.display = 'none';
    document.getElementById('devResult').innerHTML = '';

    var $inputParam1 = $("input[id=input1]");

    $("#inputForm").submit(function () {
        $.ajax({
            method: "POST",
            url: "/Pages/ShowDetailsAjax",
            data: { param1: $inputParam1.val() },
            success: function (response) {
                document.getElementById('devResult').innerHTML = response;
            },
        })
        return false;
    })
    document.getElementById('input1').innerText = "";
}
