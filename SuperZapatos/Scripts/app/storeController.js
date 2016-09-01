app.controller('StoreController', function ($scope, $http) {

    $scope.loading = true;
    $scope.addMode = false;

    $scope.toggleEdit = function () {
        this.store.editMode = !this.store.editMode;
    }

    $scope.toggleAdd = function () {
        $scope.addMode = !$scope.addMode;
    }

    //Get Stores
    $http.get("/api/Stores").success(function (data) {
        $scope.stores = data;
        $scope.loading = false;
    }).error(function () {
        $scope.error = "Error Getting Stores";
        $scope.loading = false;
    });

    //Insert Store
    $scope.add = function () {
        $scope.loading = true;
        $http.post('/api/Stores/', this.newStore).success(function (data) {
            $scope.addMode = false;
            $scope.stores.push(data);
            $scope.loading = false;
            alert("Added Successfully!!");
        }).error(function (data) {
            $scope.error = "An Error has occurred while Adding Store! " + data;
            $scope.loading = false;
        });
    };

    //Edit Store
    $scope.save = function () {
        $scope.loading = true;
        var myStore = this.store;
        $http.put('/api/Stores/' + myStore.id, myStore).success(function (data) {
            alert("Saved Successfully!!");
            myStore.editMode = false;
            $scope.loading = false;
        }).error(function (data) {
            $scope.error = "An Error has occurred while Saving store! " + data;
            $scope.loading = false;
        });
    };

    //Delete Store
    $scope.deletestore = function () {
        $scope.loading = true;
        var Id = this.store.id;
        
        $http.delete('/api/Stores/' + Id).success(function (data) {
            $.each($scope.stores, function (i) {
                if ($scope.stores[i].id === Id) {
                    $scope.stores.splice(i, 1);
                    return false;
                }
            });                        
            $scope.loading = false;
            alert("Deleted Successfully!!");
        }).error(function (data) {
            $scope.error = "An Error has occurred while Saving Store! " + data;
            $scope.loading = false;
        });
    }
});