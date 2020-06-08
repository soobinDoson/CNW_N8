$(document).ready(function () {
    $("#btnThem").attr('type', 'button');
})

$("#homestay_name").blur(function () {
    var homestay_name = $("#homestay_name").val();
    var location_id = $("#location_id").val();
    var price = $("#price").val();
    var sell_price = $("#sell_price").val();

    $.ajax({
        method: "post",
        url: "/BackendHomestay/checkAddUser",
        data: {
            homestay_name: homestay_name, location_id: location_id, price: price, sell_price: sell_price
        }
    }).done(function (thongbao) {
        if (thongbao == 0) {
            $("#divThongBao").html("homestay_name đã tồn tại");
            $("#btnThem").attr('type', 'button');

        } else if (thongbao == -1) {
            $("#divThongBao").html("Thiếu Thông Tin");
            $("#btnThem").attr('type', 'button');
        }
        else {
            $("#divThongBao").html("");
            $("#btnThem").attr('type', 'submit');
        }
    });
})

$("#location_id").blur(function () {
    var homestay_name = $("#homestay_name").val();
    var location_id = $("#location_id").val();
    var price = $("#price").val();
    var sell_price = $("#sell_price").val();

    $.ajax({
        method: "post",
        url: "/BackendHomestay/checkAddUser",
        data: {
            homestay_name: homestay_name, location_id: location_id, price: price, sell_price: sell_price
        }
    }).done(function (thongbao) {
        if (thongbao == -1) {
            $("#divThongBao").html("Thiếu Thông Tin");
            $("#btnThem").attr('type', 'button');
        }
        else {
            $("#divThongBao").html("");
            $("#btnThem").attr('type', 'submit');
        }
    });
})

$("#price").blur(function () {
    var username = $("#username").val();
    var password = $("#password").val();
    var email = $("#email").val();
    var phone = $("#phone").val();
    var address = $("#address").val();
    var full_name = $("#full_name").val();
    var role_id = $("#role_id").val();

    $.ajax({
        method: "post",
        url: "/BackendUser/checkAddUser",
        data: {
            username: username, password: password, email: email, phone: phone, address: address, full_name: full_name,
            role_id: role_id
        }
    }).done(function (thongbao) {
        if (thongbao == 0) {
            $("#divThongBao").html("username đã có người sử dụng");
            $("#btnThem").attr('type', 'button');

        } else if (thongbao == -1) {
            $("#divThongBao").html("Thiếu Thông Tin");
            $("#btnThem").attr('type', 'button');
        } else {
            $("#divThongBao").html("");
            $("#btnThem").attr('type', 'submit');
        }
    });
})

$("#sell_price").blur(function () {
    var homestay_name = $("#homestay_name").val();
    var location_id = $("#location_id").val();
    var price = $("#price").val();
    var sell_price = $("#sell_price").val();

    $.ajax({
        method: "post",
        url: "/BackendHomestay/checkAddUser",
        data: {
            homestay_name: homestay_name, location_id: location_id, price: price, sell_price: sell_price
        }
    }).done(function (thongbao) {
        if (thongbao == 0) {
            $("#divThongBao").html("homestay_name đã tồn tại");
            $("#btnThem").attr('type', 'button');

        } else if (thongbao == -1) {
            $("#divThongBao").html("Thiếu Thông Tin");
            $("#btnThem").attr('type', 'button');
        }
        else {
            $("#divThongBao").html("");
            $("#btnThem").attr('type', 'submit');
        }
    });
})

