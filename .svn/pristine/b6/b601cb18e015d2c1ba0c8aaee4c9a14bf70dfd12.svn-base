var elementDelete = '';
$(function () {
    $('.btn-delete').click(function () {
        elementDelete = $(this);
        $('.modal-body-contents').html("Bạn có chắc chắn xóa?");
    });

    $('.btn-ajax').click(function () {
        let value = $(elementDelete).data('value');
        if (value) {
            myAjax('Delete', { ID: value }, function (d, xhr, r) {
                if (elementDelete) {
                    $(elementDelete).parents('tr').first().hide();
                } else {
                    debugger
                    window.location.reload();
                }
                $('.modal-body-contents').html('<p>Xóa ' + (d == true ? "Thành công" : "Thất bại") + '</p>')
                elementDelete = undefined;
            }, function (d) {
                $('.modal-body-contents').html('<p>Đã xảy ra lỗi</p>')
                window.location.reload();
            }, function (d) {

            });
        } else {
            $('#myModal').modal('hide');
        }
    });
});