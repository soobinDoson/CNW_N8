$(document).ready(function () {
    $("#btnthem").attr('type', 'button');
})

$("#hotel_name").blur(function () {
    var location_id = $("#location_id").val();
    var hotel_name = $("#hotel_name").val();
    var description = $("#description").val();
    var more_imformation = $("#more_imformation").val();
    var price = $("#price").val();
    var sell_price = $("#sell_price").val();
    var image_url = $("customfile1").val();
    var detail_header_image_url = $("customfile2").val();
    var more_imformation_image_url = $("customfile3").val();


    $.ajax({
        method: "post",
        url: "/BackendHotel/checkAddHotel",
        data: {
            location_id: location_id, hotel_name: hotel_name, description: description, more_imformation: more_imformation,
            price: price, sell_price: sell_price,
            image_url: image_url, detail_header_image_url: detail_header_image_url, more_imformation_image_url: more_imformation_image_url
        }
    }).done(function (thongbao) {
        if (thongbao == 0) {
            $("#divThongBao").html("tên khách sạn bị trùng");
            $("#btnThem").attr('type', 'button');
        } else if (thongbao == -1) {
            $("#divThongBao").html("thiếu thông tin");
            $("#btnThem").attr('type', 'button');
        } else {
            $("#divThongBao").html("");
            $("#btnThem").attr('type', 'submit');
        }
    });
})

$("#description").blur(function () {
    var location_id = $("#location_id").val();
    var hotel_name = $("#hotel_name").val();
    var description = $("#description").val();
    var more_imformation = $("#more_imformation").val();
    var price = $("#price").val();
    var sell_price = $("#sell_price").val();
    var image_url = $("customfile1").val();
    var detail_header_image_url = $("customfile2").val();
    var more_imformation_image_url = $("customfile3").val();

    $.ajax({
        method: "post",
        url: "/BackendHotel/checkAddHotel",
        data: {
            location_id: location_id, hotel_name: hotel_name, description: description, more_imformation: more_imformation,
            price: price, sell_price: sell_price,
            image_url: image_url, detail_header_image_url: detail_header_image_url, more_imformation_image_url: more_imformation_image_url
        }
    }).done(function (thongbao) {
        if (thongbao == 0) {
            $("#divThongBao").html("tên khách sạn bị trùng");
            $("#btnThem").attr('type', 'button');
        } else if (thongbao == -1) {
            $("#divThongBao").html("thiếu thông tin");
            $("#btnThem").attr('type', 'button');
        } else {
            $("#divThongBao").html("");
            $("#btnThem").attr('type', 'submit');
        }
    });
})

$("#more_imformation").blur(function () {
    var location_id = $("#location_id").val();
    var hotel_name = $("#hotel_name").val();
    var description = $("#description").val();
    var more_imformation = $("#more_imformation").val();
    var price = $("#price").val();
    var sell_price = $("#sell_price").val();
    var image_url = $("customfile1").val();
    var detail_header_image_url = $("customfile2").val();
    var more_imformation_image_url = $("customfile3").val();
    $.ajax({
        method: "post",
        url: "/BackendHotel/checkAddHotel",
        data: {
            location_id: location_id, hotel_name: hotel_name, description: description, more_imformation: more_imformation,
            price: price, sell_price: sell_price,
            image_url: image_url, detail_header_image_url: detail_header_image_url, more_imformation_image_url: more_imformation_image_url
        }
    }).done(function (thongbao) {
        if (thongbao == 0) {
            $("#divThongBao").html("tên khách sạn bị trùng");
            $("#btnThem").attr('type', 'button');
        } else if (thongbao == -1) {
            $("#divThongBao").html("thiếu thông tin");
            $("#btnThem").attr('type', 'button');
        } else {
            $("#divThongBao").html("");
            $("#btnThem").attr('type', 'submit');
        }
    });
})

$("#price").blur(function () {
    var location_id = $("#location_id").val();
    var hotel_name = $("#hotel_name").val();
    var description = $("#description").val();
    var more_imformation = $("#more_imformation").val();
    var price = $("#price").val();
    var sell_price = $("#sell_price").val();
    var image_url = $("customfile1").val();
    var detail_header_image_url = $("customfile2").val();
    var more_imformation_image_url = $("customfile3").val();
    $.ajax({
        method: "post",
        url: "/BackendHotel/checkAddHotel",
        data: {
            location_id: location_id, hotel_name: hotel_name, description: description, more_imformation: more_imformation,
            price: price, sell_price: sell_price,
            image_url: image_url, detail_header_image_url: detail_header_image_url, more_imformation_image_url: more_imformation_image_url
        }
    }).done(function (thongbao) {
        if (thongbao == 0) {
            $("#divThongBao").html("tên khách sạn bị trùng");
            $("#btnThem").attr('type', 'button');
        } else if (thongbao == -1) {
            $("#divThongBao").html("thiếu thông tin");
            $("#btnThem").attr('type', 'button');
        } else {
            $("#divThongBao").html("");
            $("#btnThem").attr('type', 'submit');
        }
    });
})

$("#sell_price").blur(function () {
    var location_id = $("#location_id").val();
    var hotel_name = $("#hotel_name").val();
    var description = $("#description").val();
    var more_imformation = $("#more_imformation").val();
    var price = $("#price").val();
    var sell_price = $("#sell_price").val();
    var image_url = $("customfile1").val();
    var detail_header_image_url = $("customfile2").val();
    var more_imformation_image_url = $("customfile3").val();
    $.ajax({
        method: "post",
        url: "/BackendHotel/checkAddHotel",
        data: {
            location_id: location_id, hotel_name: hotel_name, description: description, more_imformation: more_imformation,
            price: price, sell_price: sell_price,
            image_url: image_url, detail_header_image_url: detail_header_image_url, more_imformation_image_url: more_imformation_image_url
        }
    }).done(function (thongbao) {
        if (thongbao == 0) {
            $("#divThongBao").html("tên khách sạn bị trùng");
            $("#btnThem").attr('type', 'button');
        } else if (thongbao == -1) {
            $("#divThongBao").html("thiếu thông tin");
            $("#btnThem").attr('type', 'button');
        } else {
            $("#divThongBao").html("");
            $("#btnThem").attr('type', 'submit');
        }
    });
})

$("#location_id").blur(function () {
    var location_id = $("#location_id").val();
    var hotel_name = $("#hotel_name").val();
    var description = $("#description").val();
    var more_imformation = $("#more_imformation").val();
    var price = $("#price").val();
    var sell_price = $("#sell_price").val();
    var image_url = $("customfile1").val();
    var detail_header_image_url = $("customfile2").val();
    var more_imformation_image_url = $("customfile3").val();
    $.ajax({
        method: "post",
        url: "/BackendHotel/checkAddHotel",
        data: {
            location_id: location_id, hotel_name: hotel_name, description: description, more_imformation: more_imformation,
            price: price, sell_price: sell_price,
            image_url: image_url, detail_header_image_url: detail_header_image_url, more_imformation_image_url: more_imformation_image_url
        }
    }).done(function (thongbao) {
        if (thongbao == 0) {
            $("#divThongBao").html("tên khách sạn bị trùng");
            $("#btnThem").attr('type', 'button');
        } else if (thongbao == -1) {
            $("#divThongBao").html("thiếu thông tin");
            $("#btnThem").attr('type', 'button');
        } else {
            $("#divThongBao").html("");
            $("#btnThem").attr('type', 'submit');
        }
    });
})