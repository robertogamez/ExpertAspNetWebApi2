var viewModel = ko.observable({
    productID: 1,
    name: "Emergency Flare",
    price: 12.99
});

var response = ko.observable('Ready');
var gotError = ko.observable(false);

var sendRequest = function (requestType) {

    var requestData = viewModel();
    requestData.IncludeInSale = true;

    $.ajax('/api/products', {
        type: 'post',
        data: requestData,
        success: function (data) {
            gotError(false);
            response("Success");
        },
        error: function (jqXHR) {
            gotError(true);
            response(jqXHR.status + " (" + jqXHR.statusText + ")");
        }
    })
};

$(document).ready(function () {
    ko.applyBindings();
});

