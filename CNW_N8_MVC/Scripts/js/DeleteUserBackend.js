function deleteRowUser(id) {
    $.ajax({
        method: "post",
        url: "/BackendUser/DeleteUser",
        data: {
            id: id
        }
    }).done(function (thongbao) {
        $("#row_" + id).css('display', 'none');
    });
}