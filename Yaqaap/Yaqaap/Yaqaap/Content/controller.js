﻿var yaqaap = angular.module("yaqaap", ["ngRoute", "ngSanitize", "ngAnimate"]);

yaqaap.config([
    '$routeProvider', '$locationProvider',
    function ($routeProvider, $locationProvider) {
        $routeProvider
            .when('/', {
                templateUrl: "/Content/_Search.html",
                controller: "searchController"
            })
            .when('/Ask', {
                templateUrl: '/Content/_Ask.html',
                controller: "askController"
            })
            .when('/NotFound', {
                templateUrl: '/Content/_NotFound.html'
            })
            .otherwise({ redirectTo: '/NotFound' });

        $locationProvider.html5Mode(true);
    }
]);


yaqaap.controller("yaqqapController", ["$scope", '$route', '$routeParams', '$location', yaqqapController]);
yaqaap.controller("askController", ["$scope", askController]);
yaqaap.controller("searchController", ["$scope", searchController]);


function yaqqapController($scope, $route, $routeParams, $location) {

    // Using 'Controller As' syntax, so we assign this to the vm variable (for viewmodel).
    var vm = this;

    vm.$route = $route;
    vm.$location = $location;
    vm.$routeParams = $routeParams;
};

function searchController($scope) {

    // Using 'Controller As' syntax, so we assign this to the vm variable (for viewmodel).
    var vm = this;

    $scope.searchChange = function () {

        if ($scope.search) {
            $scope.questions = [
                { Title: "Question 1" },
                { Title: "Question 2" },
                { Title: "Question 3" }
            ];
        } else {
            $scope.questions = undefined;
        }

        //$.getJSON('/search/' + search)
        //      .success(function (response) {
        //          $('#searchResult').html(response.Result);
        //          $('#searchResultRow').fadeIn(400);
        //      });
    };
};


function askController($scope) {
    // Using 'Controller As' syntax, so we assign this to the vm variable (for viewmodel).
    var vm = this;

    $scope.markdownPreview = "";

    $scope.updateMarkdownPreview = function (data) {
        $scope.markdownPreview = markdown.toHTML(data);
    };
};