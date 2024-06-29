// Evento de cambio de casa
$('#Casa').on('change', function () {
    var idCasa = $(this).val();
    if (idCasa) {
        cargarAlquilerPorCasas(idCasa);
    } else {
        $('#precio').text(""); // Limpiar el contenido del label si no se selecciona ninguna casa
    }
});

// Función para cargar las Casas
function cargarCasas() {
    $.ajax({
        url: '/Casas/ConsultarAlquiler',
        method: 'GET',
        success: function (response) {
            var casas = response.Datos;
            var selectCasas = $('#Casa');
            selectCasas.empty();

            selectCasas.append('<option value="" disabled selected>Seleccione la Casa</option>');

            $.each(casas, function (index, casa) {
                selectCasas.append('<option value="' + casa.IdCasa + '">' + casa.DescripcionCasa + '</option>');
            });
        },
        error: function () {
            alert('Error al cargar las Casas.');
        }
    });
}

// Función para cargar los precios de las casas seleccionadas
function cargarAlquilerPorCasas(IdCasa) {
    $.ajax({
        url: '/Casas/ConsultarPrecioAlquiler/' + IdCasa,
        method: 'GET',
        data: { IdCasa: IdCasa },
        success: function (response) {              ;
            $('#precio').html(response); // Actualizar el contenido del label con el precio de alquiler
        },
        error: function () {
            alert('Error al cargar los precios.');
        }
    });
}

$(document).ready(function () {
    cargarCasas();
});
