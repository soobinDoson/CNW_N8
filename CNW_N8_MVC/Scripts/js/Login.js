$("#login").click(function () {
    var user = $("#username").val();
    var pass = $("#password").val();
    $.ajax({
        method: "get",
        url: "/User/checkMK",
        data: { user: user, pass: pass}
    }).done(function (thongbao) {
        alert(thongbao);
    });
})