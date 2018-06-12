var viewModel = ko.observable({ first: 2, second: 5, third: 100 });
var response = ko.observable("Ready");
var gotError = ko.observable(false);

var sendRequest = function () {
    $.ajax('/api/bindings/sumnumbers', {
        type: 'get',
        data: {
            "numbers": [viewModel().first, viewModel().second, viewModel().third]
        },
        success: function (data) {
            gotError(false);
            response('Total: ' + data)
        },
        error: function (jqXHR) {
            gotError(true);
            response(jqXHR.status + ' (' + jqXHR.statusText + ')');
        }
    });
};

$(document).ready(function () {
    ko.applyBindings();
});