app.directive('focusOn', function () {
    return function (scope, elem, attr) {
        scope.$on('focusOn', function (e, name) {
            if (name === attr.focusOn) {
                elem[0].focus();
            }
        });
    };
});

app.factory('focus', function ($rootScope, $timeout) {
    return function (name) {
        $timeout(function () {
            $rootScope.$broadcast('focusOn', name);
        });
    }
});

//include the factory
app.controller('loginController', function ($scope, $http,  focus) {
    $scope.alert = { type: 'danger', msg: '' };
    $scope.email = '';
    $scope.password = '';
    $scope.isProcessing = false;
    $scope.baseAPIUrl = window.location.protocol + "//" + window.location.host + '/odata/';

    $scope.validate = function () {
        if ($scope.email === '') {
            $scope.showErrorMessage('Username is required.');
            focus('email');
            return;
        }

        if ($scope.password === '') {
            $scope.showErrorMessage('Please provide your password');
            focus('password');
            return;
        }

        $scope.clearMsg();
        $scope.login();

    }

    $scope.login = function () {
        $scope.isProcessing = true;
        
        var data = { username: $scope.email, password: $scope.password };
        $http.post(window.location.href, data)
        .success(function (data) {
            if (data.toLowerCase() === 'success') {
                var href = getParameterByName('ReturnUrl');
                if (href === '' || href === undefined || href === null) {
                    window.location.href = window.location.protocol + "//" + window.location.host;
                }
                else {
                    window.location.href = href;
                }
            }
            else {
                $scope.showErrorMessage('Invalid Credentials.');
            }

            $scope.isProcessing = false;
        })
        .error(function (data) {
            $scope.isProcessing = false;
            $scope.showErrorMessage('An error occur while processing your request.');
        });


        //$http.get($scope.baseAPIUrl + "/Users?$filter=Username eq '" + $scope.email + "' and Password eq '" + $scope.password + "'").success(function (data) {
        //    if (data.value.length > 0) {
        //        var href = getParameterByName('ReturnUrl');
        //        window.location.href = href;
        //    }
        //    else {
        //        $scope.showErrorMessage('Invalid Credentials.');
        //    }

        //    $scope.isProcessing = false;

        //}).error(function (data, status, headers, config) {
        //    $scope.isProcessing = false;
        //    $scope.showErrorMessage('An error occur while processing your request.');
        //});
    }

    $scope.clearMsg = function () {
        $scope.alert.msg = '';
    }

    $scope.showErrorMessage = function (message) {
        $scope.alert = { type: 'danger', msg: message };
    }

    function getParameterByName(name) {
        name = name.replace(/[\[]/, "\\[").replace(/[\]]/, "\\]");
        var regex = new RegExp("[\\?&]" + name + "=([^&#]*)"),
            results = regex.exec(location.search);
        return results === null ? "" : decodeURIComponent(results[1].replace(/\+/g, " "));
    }
});