$(document).ready(function () {

    $('button').click(function () {
        $.get("/result", function (res) {
            var my_html = "";
            my_html += "<p>Random passcode (passcode #" + res.count + ")</p>";
            my_html += "<h1 id='box'>" + res.code + "</h1>";
            $("#result").html(my_html);
            // console.log(res.code)
            // console.log(res.count)
        }, 'json');
    });
});