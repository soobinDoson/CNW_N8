function deleteRowHomestayBackend(id) {
    $.ajax({
        method: "post",
        url: "/BackendHomestay/DeleteHomestay",
        data: {
            id: id
        }
    }).done(function (thongbao) {
        $("#row_" + id).css('display', 'none');
    });
}