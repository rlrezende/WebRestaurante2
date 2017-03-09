(function (app) {

    var restaurantesController = function ($scope, $http, $location,PropriedadesCompartilhadas) {
                
       var teste = PropriedadesCompartilhadas.getItem();

       if ($scope.Restaurante == null) {

           $scope.Restaurante = $.extend(true, {}, teste);
           PropriedadesCompartilhadas.setItem(null);
       }

        $scope.BuscarRestaurantes = function (criterioDeBusca) {

            var baseUrl;

            if (criterioDeBusca == null)
            {
                 baseUrl = 'api/Restaurantes';
            }
            else
            {
                baseUrl = 'api/Restaurantes' + '/?nome=' + criterioDeBusca;
            }
             
            console.log(criterioDeBusca);
            console.log(baseUrl);

            $http.get(baseUrl).then(function (response) {
                $scope.Restaurantes = response.data;
            }, function (err) {
                console.log(err);
            });


        }

        $scope.MarcaIDDelete = function (Id_restaurante) {

            $scope.idrestdelete = Id_restaurante;
            console.log(Id_restaurante);
        }

        $scope.EditRestaurante = function (Restaurante) {

            $scope.Restaurante = Restaurante;

            console.log(Restaurante);

            $location.path('/Restaurantes/Alterar');

            PropriedadesCompartilhadas.setItem(Restaurante);

        }

        $scope.AddRestaurante = function (Restaurante) {

            var baseUrl;

            baseUrl = '/api/Restaurantes';

            console.log(Restaurante);

            if (Restaurante.Id_restaurante == null)
            {
            $http.post(baseUrl, Restaurante).then(function (response) {
            
                alert('Restaurante Salvo com sucesso.');

                $location.path('/Restaurantes/');
            

            }, function (err) {
                console.log(err);
            });

            }
            else
            {
                baseUrl = baseUrl + '/' + Restaurante.Id_restaurante;
                $http.put(baseUrl, Restaurante).then(function (response) {

                    alert('Restaurante Alterado com sucesso.');

                    $location.path('/Restaurantes/');


                }, function (err) {
                    console.log(err);
                });

            }
        }


        $scope.DeletarRestaurantes = function (Restaurantes) {

            var baseUrl;

            baseUrl = 'api/Restaurantes/' + $scope.idrestdelete;

            console.log(baseUrl);

            $http.delete(baseUrl).then(function (response) {
            
                $scope.Restaurantes = Restaurantes.filter(function (Restaurante) {
                    if (Restaurante.Id_restaurante != $scope.idrestdelete) return Restaurante;
                }

              );

            }, function (err) {
                console.log(err);
            });


        }

    };

    app.controller("restaurantesController", restaurantesController)

}(angular.module("webrest")));