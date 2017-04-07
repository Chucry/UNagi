var maestro = {};

CreateMaestroAsync = function (maestro) {
    $.ajax({
        type: "POST",
        url: "/Maestros/Create",
        data: maestro,
        success: function (data, status) {
            if (!data) {
                alert("No fue posible ingresar al maestro, intente nuevamente");
            } else {
                alert("Maestro registrado con éxito");
                loadDataAsync("Index", "Maestros");
            }
        }
    });
}

CreateMaestro = function () {
    if ($("#contraseña")[0].value == $("#contraseña2")[0].value) {
        maestro = {
            email: $("#email")[0].value,
            nombre: $("#nombre")[0].value,
            apellido: $("#apellido")[0].value,
            contraseña: $("#contraseña")[0].value
        };

        CreateMaestroAsync(maestro);
    } else {
        alert("La contraseña debe coincidir en ambas casillas");
    }
}

UpdateMaestroAsync = function(request) {
    $.ajax({
        type: "POST",
        url: "/Maestros/Update",
        data: request,
        success: function(data, status) {
            if (!data) {
                alert("Contraseña incorrecta");
            } else {
                alert("Contraseña cambiada con éxito");
                loadDataAsync("Index", "Maestros");
            }
        }
    });
}

UpdateMaestro = function (element) {
    var request;
    if ($("#contraseñaNueva")[0].value == $("#contraseñaNueva2")[0].value) {
        request = {
            id: element.id,
            contraseñaActual: $("#contraseñaActual")[0].value,
            contraseñaNueva: $("#contraseñaNueva")[0].value
        };
        UpdateMaestroAsync(request);
    } else {
        alert("La nueva contraseña debe coincidir en ambar casillas");
    }
}

SignInMaestroAsync = function (maestro) {
    $.ajax({
        type: "POST",
        url: "/Home/SignInMaestro",
        data: maestro,
        success: function (data, status) {
            if (!data) {
                alert("La combinación de correo y contraseña no son válidos");
            } else {
                localStorage.sesionUNagi = "maestro";
                localStorage.id = data.Id;
                alert("Bienvenido " + data.Nombre + " " + data.Apellido);

                loadDataAsync("Index", "Maestros");
            }
        }
    });
}

SignInMaestro = function () {
    var maestro = {
        email: $("#sign-in-maestro-email")[0].value,
        contraseña: $("#sign-in-maestro-contraseña")[0].value
    };
    SignInMaestroAsync(maestro);
}