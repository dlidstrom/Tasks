(function (app) {
    'use strict';

    // put your initial data in window.App.InitialData
    // and it will be available through this service
    app.factory('InitialData', function () {
        return app.initialData;
    });
})(window.App);