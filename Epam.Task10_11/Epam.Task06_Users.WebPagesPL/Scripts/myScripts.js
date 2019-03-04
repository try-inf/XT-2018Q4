function createUser() {
    document.getElementById('buttons_div').style.display = 'none';
    document.getElementById('inputForm').style.display = 'block';
    document.getElementById('label2').style.display = 'block';
    document.getElementById('input2').style.display = 'block';
    document.getElementById('devResult').innerHTML = ''; 
    document.getElementById('label1').innerHTML = 'Enter the name of User:';
    document.getElementById('label2').innerHTML = 'Enter date of birth(in format dd- mm - yyyy or dd.mm.yyyy):';

    var $inputParam1 = $("input[id=input1]"),
        $inputParam2 = $("input[id=input2]");

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

function editUser() {
    document.getElementById('buttons_div').style.display = 'none';
    document.getElementById('inputForm').style.display = 'block';
    document.getElementById('label1').innerHTML = 'Enter the Id of user to edit details:';
    document.getElementById('label2').style.display = 'none';
    document.getElementById('input2').style.display = 'none';
    document.getElementById('devResult').innerHTML = '';

    var $inputParam1 = $("input[id=input1]");

    $("#inputForm").submit(function () {
        $.ajax({
            method: "POST",
            url: "/Pages/EditUserAjax",
            data: { param1: $inputParam1.val() },
            success: function (response) {
                document.getElementById('devResult').innerHTML = response;
            },
        })

        return false;
    })
    document.getElementById('input1').innerText = "";
}

function showUsers() {
    document.getElementById('buttons_div').style.display = 'none';
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
    document.getElementById('buttons_div').style.display = 'none';
    document.getElementById('inputForm').style.display = 'block';
    document.getElementById('label1').innerHTML = 'Enter the Id of user you want to remove:';
    document.getElementById('label2').style.display = 'none';
    document.getElementById('input2').style.display = 'none';
    document.getElementById('devResult').innerHTML = '';

    var $inputParam1 = $("input[id=input1]");

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
    document.getElementById('buttons_div').style.display = 'none';
    document.getElementById('inputForm').style.display = 'block';
    document.getElementById('label1').innerHTML = 'Enter the title of award:';
    document.getElementById('label2').style.display = 'none';
    document.getElementById('input2').style.display = 'none';
    document.getElementById('devResult').innerHTML = ''; 

    var $inputParam1 = $("input[id=input1]");

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
    document.getElementById('buttons_div').style.display = 'none';
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

function removeAward() {
    document.getElementById('inputForm').style.display = 'none';
    document.getElementById('buttons_div').style.display = 'inline-block';
    
 
    $("#button_accept").submit(function () {
        document.getElementById('buttons_div').style.display = 'none';
        document.getElementById('inputForm').style.display = 'block';
        document.getElementById('label1').innerHTML = 'Enter the Id of award you want to remove:';
        document.getElementById('label2').style.display = 'none';
        document.getElementById('input2').style.display = 'none';
        document.getElementById('devResult').innerHTML = '';
        return false;
    })

    $("#button_cancel").submit(function () {
        document.getElementById('buttons_div').style.display = 'none';
        document.getElementById('inputForm').style.display = 'none';
        document.getElementById('label1').innerHTML = 'Enter the Id of award you want to remove:';
        document.getElementById('label2').style.display = 'none';
        document.getElementById('input2').style.display = 'none';
        document.getElementById('devResult').innerHTML = '';
        return false;
    })

    var $inputParam1 = $("input[id=input1]");
    
    $("#inputForm").submit(function () {
        $.ajax({
            method: "POST",
            url: "/Pages/RemoveAwardAjax",
            data: { param1: $inputParam1.val() },
            success: function (response) {
                document.getElementById('devResult').innerHTML = response;
            },
        })
        return false;
    })
    document.getElementById('input1').innerText = "";
}

function awardUser() {
    document.getElementById('buttons_div').style.display = 'none';
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
    document.getElementById('buttons_div').style.display = 'none';
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
