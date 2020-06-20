$(document).ready(function () {
    $("#login").attr('type', 'button');
    window.addEventListener("keyup", function (event) {
        if (event.keyCode === 13) {
            event.preventDefault();
            document.getElementById("login").click();
        }
    });
});
$("#login").click(function () {
    var user = $("#username").val();
    var pass = $("#password").val();

    $.ajax({
        method: "get",
        url: "/User/checkMK",
        data: { user: user, pass: pass}
    }).done(function (thongbao) {
        if (thongbao == 0) {
            $("#divThongBao").html("Tài Khoản hoặc Mật Khẩu Không Đúng !");
        }
        else {
            $("#login").attr('type', 'submit');
            $("#login").click();
        }
    });
})




