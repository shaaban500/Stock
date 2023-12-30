$(document).ready(function () {
    // Event handler for store selection change
    $('#SelectedStoreId').change(function () {
        fetchOldQuantity();
    });

    // Event handler for product selection change
    $('#SelectedProductId').change(function () {
        fetchOldQuantity();
    });

    function fetchOldQuantity() {
        var selectedStoreId = $('#SelectedStoreId').val();
        var selectedProductId = $('#SelectedProductId').val();
        console.log("store: " + selectedStoreId);
        console.log("produ: " + selectedProductId);
        // AJAX call to fetch old quantity
        $.ajax({
            url: '/ProductStores/GetQuantityById',
            method: 'GET',
            data: {
                storeId: selectedStoreId,
                productId: selectedProductId
            },
            success: function (response) {
                // Update the Old Quantity input field with the fetched value
                $('#OldQuantity').val(response.oldQuantity);

                // Once old quantity is fetched, you can proceed with saving or other actions
                // Add your logic here...
            },
            error: function () {
                // Handle error if AJAX call fails
                console.log('Error fetching old quantity');
            }
        });
    }
});