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



function validateForm() {
    var selectedStoreId = document.getElementById('SelectedStoreId').value;
    var selectedProductId = document.getElementById('SelectedProductId').value;

    if (selectedStoreId === "choose a store" || selectedProductId === "choose a product") {
        alert('Please select a store and a product.');
        return false; // Prevent form submission
    }

    return true;
}
