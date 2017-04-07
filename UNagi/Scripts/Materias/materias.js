CreateMateriaAsync = function(materia) {
    $.ajax({
        type: "POST",
        url: "/Materias/Create",
        data: materia,
        success: function(data, status) {
            if (!data) {
                alert("No se pudo dar de alta la materia");
            } else {
                alert("Materia dada de alta con éxito");
                loadDataAsync("Index", "Materias");
            }
        }
    });
}

CreateMateria = function () {
    if ($("#nombre")[0].value != null && $("#nombre")[0].value != "") {
        var request = {
            id: localStorage.id,
            contraseña: $("#contraseña")[0].value,
            nombre: $("#nombre")[0].value
        };
        CreateMateriaAsync(request);
    } else {
        alert("Por favor ingresa el nombre de la materia");
    }
}

SignUpAlumnoAsync = function (request) {
    $.ajax({
        type: "POST",
        url: "/Materias/SignUp",
        data: request,
        success: function() {
            if (!data) {
                alert("No fue posible inscribirte en la materia");
            } else {
                alert("Materia dada de alta con éxito");
                loadDataAsync("Index", "Alumnos");
            }
        }
    });

}

SignUpAlumno = function() {
    var request = {
        idAlumno: localStorage.id,
        idMateria: $("#materias")[0].value
    };
    SignUpAlumno(request);
}