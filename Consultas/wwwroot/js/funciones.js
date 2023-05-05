function configuracionPaginadorVista(idTabla) {
    //$.noConflict()
    $(`#${idTabla}`).DataTable({
        "language": {
            "sProccessing": "Procesando...",
            "sLengthMenu": "Mostrar _MENU_ registros",
            "sZeroRecords": "No se encontraron resultados",
            "sEmptyTable": "Ningún ",
            "sInfo": "Mostrando registros del _START_ al _END_ de un total de _TOTAL_ registros",
            "sInfoEmpty": "Mostrando registros del 0 al 0 de un total de 0 registros",
            "sInfoFiltered": "(filtrado de un total de _MAX_ registros)",
            "sInfoPostFix": "",
            "sSearch": "Buscar:",
            "sUrl": "",
            "sInfoThousands": "",
            "sLoadingRecords": "Cargando...",
            "oPaginate": {
                "sFirst": "Primero",
                "sLast": "Último",
                "sNext": "Siguiente",
                "sPrevious": "Anterior"
            },
            "oAria": {
                "sSortAscending": ": Activar para ordenar la columna de manera ascendente",
                "sSortDescending": ": Activar para ordenar la columna de manera descendente",
            }
        }
    })
}

function exportarReporteExcel(tableID) {
    const nombreArchivo = $('#nombreArchivo').val()
    const dataType = 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet'

    let conteniddoTablaHTML = document.getElementById(tableID)
    conteniddoTablaHTML = conteniddoTablaHTML.outerHTML.replace(/ /g, '%20')
    conteniddoTablaHTML = reemplazarAcentos(conteniddoTablaHTML)

    // Crear elemento link para la descarga
    let linkDescarga = document.createElement('a')
    document.body.appendChild(linkDescarga)

    if (navigator.msSaveOrOpenBlob) {
        const blob = new Blob(['ufeff', conteniddoTablaHTML], {
            type: dataType
        })

        navigator.msSaveOrOpenBlob(blob, nombreArchivo)
    } else {
        // Crear un link para el archivo
        linkDescarga.href = `data:${dataType},${conteniddoTablaHTML}`

        // Asignar nombre del archivo
        linkDescarga.download = nombreArchivo

        // Activar el click
        linkDescarga.click()
    }
}

function reemplazarAcentos(cadena) {
    cadena = cadena.replace(new RegExp('[áàâäã]', 'g'), '&aacute;')
    cadena = cadena.replace(new RegExp('[éèêëẽ]', 'g'), '&eacute;')
    cadena = cadena.replace(new RegExp('[íìîï]', 'g'), '&iacute;')
    cadena = cadena.replace(new RegExp('[óòôöõ]', 'g'), '&oacute;')
    cadena = cadena.replace(new RegExp('[úùûü]', 'g'), '&uacute;')
    cadena = cadena.replace(new RegExp('[Á]', 'g'), '&Aacute;')
    cadena = cadena.replace(new RegExp('[É]', 'g'), '&Eacute;')
    cadena = cadena.replace(new RegExp('[Í]', 'g'), '&Iacute;')
    cadena = cadena.replace(new RegExp('[Ó]', 'g'), '&Oacute;')
    cadena = cadena.replace(new RegExp('[Ú]', 'g'), '&Uacute;')
    return cadena
}