// jQuery document ready function
$(document).ready(function () {
    $('#SelectedStoreId').change(function () {
        updateOldQuantity();
    });

    $('#SelectedProductId').change(function () {
        updateOldQuantity();
    });
});

function updateOldQuantity() {
    var selectedStoreId = $('#SelectedStoreId').val();
    var selectedProductId = $('#SelectedProductId').val();

    console.log(selectedStoreId);
    console.log(selectedProductId);

    $.ajax({
        type: 'GET',
        url: '/ProductStores/GetQuantityById',
        data: { storeId: selectedStoreId, productId: selectedProductId },
        success: function (data) {
            $('#OldQuantity').val(data.oldQuantity);
        },
        error: function () {
            console.log('Error fetching quantity');
        }
    });
}
