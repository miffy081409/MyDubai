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
app.controller('loginController', function ($scope, focus) {
    $scope.alert = { type: 'danger', msg: '' };
    $scope.email = '';
    $scope.password = '';

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

        $scope.alert.msg = '';
        $scope.login();

    }

    $scope.login = function () {

    }

    $scope.showErrorMessage = function (message) {
        $scope.alert = { type: 'danger', msg: message };
    }
});