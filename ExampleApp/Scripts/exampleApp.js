$(document).ready(function () {

    deleteProduct = function (data) {
        $.ajax('/api/products/' + data.ProductID, {
            type: 'DELETE',
            success: function () {
                products.remove(data);
            }
        });
    };

    getProducts = function () {
        $.ajax('/api/products', {
            headers: {
                "X-UseProductFormat": "true"
            },
            dataType: 'text',
            accepts: {
                text: 'application/x.product'
            },
            success: function (data) {
                products.removeAll();
                //for (var i = 0; i < data.length; i++) {
                //    products.push(data[i]);
                //}
                var arr = data.split(",");
                for (var i = 0; i < arr.length; i += 3) {
                    products.push({
                        ProductID: arr[i],
                        Name: arr[i + 1],
                        Price: arr[i + 2]
                    });
                }
            }
        });
    }

    ko.applyBindings();
});