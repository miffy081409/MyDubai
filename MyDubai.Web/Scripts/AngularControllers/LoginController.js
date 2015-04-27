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

        $http.get($scope.baseAPIUrl + "/Users('" + $scope.email + "')?$filter=Password eq '" + $scope.password + "'").success(function (data) {
            $scope.isProcessing = false;
            console.log(data);
        }).error(function (data, status, headers, config) {
            $scope.isProcessing = false;
            $scope.showErrorMessage('An error occur while processing your request.')
        });
    }

    $scope.clearMsg = function () {
        $scope.alert.msg = '';
    }

    $scope.showErrorMessage = function (message) {
        $scope.alert = { type: 'danger', msg: message };
    }
});