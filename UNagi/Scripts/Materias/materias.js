CreateMateriaAsync = function(materia) {
    $.ajax({
        type: "POST",
        url: "/Materias/Create",
        data: materia,
        succes: function(data, status) {
            if (!data) {
                alert("No se pudo dar de alta la materia");
            } else {
                alert("Materia dada de alta con éxito");
            }
        }
    });
}

CreateMateria = function () {
    
}