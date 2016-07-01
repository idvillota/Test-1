app.controller('ArticleController', function ($scope, $http) {

    $scope.loading = true;
    $scope.addMode = false;

    $scope.toggleEdit = function () {
        this.article.editMode = !this.article.editMode;
    }

    $scope.toggleAdd = function () {
        $scope.addMode = !$scope.addMode;
    }
    
    //Get Articles
    $http.get("/api/Articles").success(function (data) {
        $scope.articles = data;
        $scope.loading = false;
    }).error(function () {
        $scope.error = "Error Getting Articles";
        $scope.loading = false;
    });

    //Insert Articles
    $scope.add = function () {
        $scope.loading = true;
        $http.post('/api/Articles/', this.newArticle).success(function (data) {
            $scope.addMode = false;
            $scope.articles.push(data);
            $scope.loading = false;
            alert("Added Successfully!!");
        }).error(function (data) {
            $scope.error = "An Error has occured while Adding Article! " + data;
            $scope.loading = false;
        });
    };

    //Edit Article
    $scope.save = function () {
        $scope.loading = true;
        var myArticle = this.article;
        $http.put('/api/Articles/' + myArticle.id, myArticle).success(function (data) {
            alert("Saved Successfully!!");
            myArticle.editMode = false;
            $scope.loading = false;
        }).error(function (data) {
            $scope.error = "An Error has occured while Saving Article! " + data;
            $scope.loading = false;
        });
    };

    //Delete Article
    $scope.deletearticle = function () {
        $scope.loading = true;
        var Id = this.article.id;
        $http.delete('/api/Articles/' + Id).success(function (data) {            
            $.each($scope.articles, function (i) {
                if ($scope.articles[i].id === Id) {
                    $scope.articles.splice(i, 1);
                    return false;
                }
            });
            $scope.loading = false;
            alert("Deleted Successfully!!");
        }).error(function (data) {
            $scope.error = "An Error has occured while Saving Article! " + data;
            $scope.loading = false;
        });
    }

    $http.get("/api/Stores").success(function (data) {
        $scope.stores = data;        
    }).error(function () {
        $scope.error = "Error Getting Stores";        
    });
});