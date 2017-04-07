var alumno = {};

CreateAlumnoAsync = function (alumno) {
    $.ajax({
        type: "POST",
        url: "/Alumnos/Create",
        data: alumno,
        success: function (data, status) {
            if (!data) {
                alert("No fue posible ingresar al alumno, intente nuevamente");
            } else {
                alert("Alumno registrado con éxito");
                loadDataAsync("Index", "Alumnos");
            }
        }
    });
}

CreateAlumno = function () {
    if ($("#contraseña")[0].value == $("#contraseña2")[0].value) {
        alumno = {
            matricula: $("#matricula")[0].value,
            nombre: $("#nombre")[0].value,
            apellido: $("#apellido")[0].value,
            contraseña: $("#contraseña")[0].value
        };

        CreateAlumnoAsync(alumno);
    } else {
        alert("La contraseña debe coincidir en ambas casillas");
    }
}

UpdateAlumnoAsync = function (request) {
    $.ajax({
        type: "POST",
        url: "/Alumnos/Update",
        data: request,
        success: function (data, status) {
            if (!data) {
                alert("Contraseña incorrecta");
            } else {
                alert("Contraseña cambiada con éxito");
                loadDataAsync("Index", "Alumnos");
            }
        }
    });
}

UpdateAlumno = function (element) {
    var request;
    if ($("#contraseñaNueva")[0].value == $("#contraseñaNueva2")[0].value) {
        request = {
            id: element.id,
            contraseñaActual: $("#contraseñaActual")[0].value,
            contraseñaNueva: $("#contraseñaNueva")[0].value
        };
        UpdateAlumnoAsync(request);
    } else {
        alert("La nueva contraseña debe coincidir en ambar casillas");
    }
}

SignInAlumnoAsync = function (alumno) {
    $.ajax({
        type: "POST",
        url: "/Home/SignInAlumno",
        data: alumno,
        success: function (data, status) {
            if (!data) {
                alert("La combinación de matrícula y contraseña no son válidos");
            } else {
                localStorage.sesionUNagi = "alumno";
                localStorage.id = data.Id;
                alert("Bienvenido " + data.Nombre + " " + data.Apellido);

                loadDataAsync("Index", "Alumnos");
            }
        }
    });
}

SignInAlumno = function () {
    var alumno = {
        matricula: $("#sign-in-alumno-matricula")[0].value,
        contraseña: $("#sign-in-alumno-contraseña")[0].value
    };
    SignInAlumnoAsync(alumno);
}

SignOutAsync = function () {
    $.ajax({
        type: "POST",
        url: "/Home/SignOut",
        success: function (data, status) {
            if (!data) {
                alert("No se pudo cerrar sesión");
            } else {
                loadDataAsync("Index", "Home");
            }
        }
    });
}

SignOut = function () {
    localStorage.sesionUNagi = null;
    localStorage.id = null;
    SignOutAsync();
}