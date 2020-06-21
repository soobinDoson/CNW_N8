function deleteRowHotel(id) {
    $.ajax({
        method: "post",
        url: "/BackendHotel/DeleteHotel",
        data: {
            id: id
        }
    }).done(function(thongbao) {
        $("#row_" + id).css('display', 'none');
    });
}