/*
 * Função para efetuar o login via iterops
 */
(function () {



    loginControll = {
        efetuarLogin: function (usuario, senha, urlLogin) {

            var myHeaders = new Headers();
            myHeaders.append("Content-Type", "application/json");
            myHeaders.append("Content-Type", "text/plain");

            var raw = `{ "Email" : "${usuario}", "Password" :  "${senha}", "ConfirmPassword" :"${senha}", "IdEmpresa":0}`;

            var requestOptions = {
                method: 'POST',
                headers: myHeaders,
                body: raw,
                redirect: 'follow'
            };

            fetch(`${urlLogin}`, requestOptions)
                .then(result => {
                    if (result.ok) {
                        reader = result.body.getReader();
                        reader.read().then(data => {
                            var fetched = String.fromCharCode.apply(null, data.value);
                            var httpResult = JSON.parse(fetched);

                            let warning = new Object();
                            if (httpResult.succeeded) {
                                warning.class = "alert alert-info";
                                warning.text = httpResult.statusText;
                            } else {
                                warning.class = "alert alert-danger";
                                warning.text = httpResult.statusText;
                            }
                            loginControll.aviso(warning)
                            window.location.href = httpResult.redirectTo;
                            //DotNet.invokeMethodAsync('RDV', 'SetHttpResponseJS', true, "Login efetuado com sucesso!").then(data => {
                            //    var result = data.body.getReader();
                            //    result.read().then(r => {
                            //        var fetched = String.fromCharCode.apply(null, data.value);
                            //        console.log(fetched);
                            //    });
                            //});

                        });
                    } else {
                        reader = result.body.getReader();
                        reader.read().then(data => {
                            var fetched = String.fromCharCode.apply(null, data.value);
                            var httpResult = JSON.parse(fetched);
                            if (!httpResult.succeeded) {
                                let warning = new Object();
                                warning.class = "alert alert-danger";
                                warning.text = "Login inválido";
                                loginControll.aviso(warning)
                               // window.location.href = httpResult.redirectTo;
                            }
                        });

                    }

                })
                .catch(error => console.log('error', error));
        },
        aviso: function (warning) {
            var stringTemplate = `<div class="${warning.class}">
                                    <p>${warning.text}</p>
                                </div>`
            var infoLogin = document.querySelector("#infoLogin");
            infoLogin.innerHTML = stringTemplate;
        }

    };
})();
