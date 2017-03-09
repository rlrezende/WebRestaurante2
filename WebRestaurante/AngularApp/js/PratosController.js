/**
 * Controllher das Paginas de Pratos no cliente
 */

(function (app) {

    //Cria controleller para paginas de Pratos

    var PratosController = function ($scope, $http, $location, PropriedadesCompartilhadas) {

        var teste = PropriedadesCompartilhadas.getItem();


        if ($scope.Pratos == null)
        {
            $http.get('/api/Pratos').then(function (response) {
            $scope.Pratos = response.data;
        }, function (err) {
            console.log(err);
        });

        }

        //Metodo Para carregar dados por API nesse caso Restaurantes
        $scope.CarregaDados = function () {

            if (PropriedadesCompartilhadas.getCadastro() == true) {

                if ($scope.Restaurantes == null) {
                    $http.get('/api/Restaurantes').then(function (response) {
                        $scope.Restaurantes = response.data;
                    }, function (err) {
                        console.log(err);
                    });

                }
                PropriedadesCompartilhadas.getCadastro(false);
            }
        }

          
        if ($scope.Prato == null) {

            $scope.Prato = $.extend(true, {}, teste);
            PropriedadesCompartilhadas.setItem(null);
        }

   

        $scope.MarcaIDDelete = function (Id_Prato) {

            $scope.idrestdelete = Id_Prato;
      
        }

        $scope.MarcaAdd = function () {

            PropriedadesCompartilhadas.setCadastro(true);

        }

        
        $scope.EditPrato = function (Prato) {

            $scope.Prato = Prato;

            console.log(Prato);

            $location.path('/Pratos/Alterar');

            PropriedadesCompartilhadas.setItem(Prato);

            PropriedadesCompartilhadas.setCadastro(true);

        }

        //Metodo para buscar dados dos Pratos por API funcao GET
        $scope.AddPrato = function (Prato, RestauranteSel) {

            var baseUrl;

            baseUrl = '/api/Pratos';
    

            Prato.Preco = parseFloat(Prato.Preco.toString().replace(".", "").replace(",", "."));


            if (Prato.Id_Prato == null) {
                $http.post(baseUrl, Prato).then(function (response) {

                    alert('Prato Salvo com sucesso.');

                    $location.path('/Pratos/');


                }, function (err) {
                    console.log(err);
                });

            }
            else {
                baseUrl = baseUrl + '/' + Prato.Id_Prato;
                $http.put(baseUrl, Prato).then(function (response) {

                    alert('Prato Alterado com sucesso.');

                    $location.path('/Pratos/');


                }, function (err) {
                    console.log(err);
                });

            }
        }

        //Deleta o Prato no banco de dados via API
        $scope.DeletarPratos = function (Pratos) {

            var baseUrl;

            baseUrl = 'api/Pratos/' + $scope.idrestdelete;

          ;

            $http.delete(baseUrl).then(function (response) {

                $scope.Pratos = Pratos.filter(function (Prato) {
                    if (Prato.Id_Prato != $scope.idrestdelete) return Prato;
                }

              );

            }, function (err) {
                console.log(err);
            });


        }

    };

    app.controller("PratosController", PratosController)

}(angular.module("webrest")));