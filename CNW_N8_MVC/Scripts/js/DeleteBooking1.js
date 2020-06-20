let count = 0;
let giohangCount = document.getElementsByClassName("giohang").length;
function deleteRow(hotelID, status, checkinConvert, checkin) {
    let key = hotelID + status + checkinConvert;
    $("#row_" + key).css('display', 'none');
    $.ajax({
        method: "post",
        url: "/User/RemoveLine",
        data: {
            id: hotelID, checkin: checkin, status_checking: status
        }
    }).done(function (thongbao) {
        $("#row_" + key).css("display", "none");
    });
    count++;
    if (count == giohangCount) {
        $("#btnThanhToan").css("display", "none");
    }
}
