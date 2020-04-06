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
                            console.log(fetched);
                            //DotNet.invokeMethodAsync('RDV', 'SetHttpResponseJS', true, "Login efetuado com sucesso!").then(data => {
                            //    var result = data.body.getReader();
                            //    result.read().then(r => {
                            //        var fetched = String.fromCharCode.apply(null, data.value);
                            //        console.log(fetched);
                            //    });
                            //});
                            let warning = new Object();
                            warning.class = "alert alert-info"; //  alertClass = "alert alert-info";
                            warning.text = "Login efetuado com sucesso!";
                            loginControll.aviso(warning)
                            window.location.href = "/counter";
                        });
                    } else {
                        //DotNet.invokeMethodAsync('RDV', 'SetHttpResponseJS', false, "Faha ao autenticar suas credenciais!").then(data => {
                        //    var result = data.body.getReader();
                        //    result.read().then(r => {
                        //        var fetched = String.fromCharCode.apply(null, data.value);
                        //        console.log(fetched);
                        //    });
                        //});
                        let warning = new Object();
                        warning.class = "alert alert-danger"; //  alertClass = "alert alert-info";
                        warning.text = "Faha ao autenticar suas credenciais!";
                        loginControll.aviso(warning)
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
