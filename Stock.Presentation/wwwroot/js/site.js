﻿showInPopup = (url, title) => {
    $.ajax({
        type: 'GET',
        url: url,
        success: function (res) {
            $('#form-modal .modal-body').html(res);
            $('#form-modal .modal-title').html(title);
            $('#form-modal').modal('show');
        }
    })  
}

$(document).ready(function () {
    $('#closeDialog').on('click', function () {
        $('#form-modal').modal('hide');
    });
});

