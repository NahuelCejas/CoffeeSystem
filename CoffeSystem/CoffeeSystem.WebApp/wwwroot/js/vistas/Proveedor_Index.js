

const MODELO_BASE = {
    
    idProveedor: 0,
    razonSocial: '',
    nombre: '',
    email: '',
    telefono: '',
    cuit: '',
    direccion: '',
    localidad: '',
    codigoPostal: '',
}

let tablaData;

$(document).ready(function () {

    $('#tbdata').DataTable({
        responsive: true,
         "ajax": {
             "url": '/Proveedor/Lista',
             "type": "GET",
             "datatype": "json"
         },
         "columns": [
             { "data": "idProveedor","visible":true, "searchable":false },
             { "data": "razonSocial" },
             { "data": "nombre" },
             { "data": "email" },
             { "data": "telefono" },                          
             {
                 "defaultContent": '<button class="btn btn-primary btn-editar btn-sm mr-2"><i class="fas fa-pencil-alt"></i></button>' +
                     '<button class="btn btn-danger btn-eliminar btn-sm"><i class="fas fa-trash-alt"></i></button>',
                 "orderable": false,
                 "searchable": false,
                 "width": "80px"
             }
         ],
         order: [[0, "desc"]],
        //dom:"Bfrtip",
        //buttons:[
        //    {
        //        text: 'Exportar Excel',
        //        extend: 'excelHtml5',
        //        title: '',
        //        filename: 'Reporte Usuarios',
        //        exportOptions: {
        //            columns: [ 1,2 ]
        //        }
        //    },'pageLength'
        //],
        //language: {
        //    url: "https://cdn.datatables.net/plug-ins/1.11.5/i18n/es-ES.json"
        //},
    });

})

function mostrarModal(modelo = MODELO_BASE) {

    $("#txtId").val(modelo.idProveedor)
    $("#txtRazonSocial").val(modelo.razonSocial)
    $("#txtCUIT").val(modelo.cuit)
    $("#txtDireccion").val(modelo.direccion)
    $("#txtLocalidad").val(modelo.localidad)
    $("#txtCodPostal").val(modelo.codigoPostal)
    $("#txtNombre").val(modelo.nombre)
    $("#txtCorreo").val(modelo.email)
    $("#txtTelefono").val(modelo.telefono)

    $("#modalData").modal("show")

}

$("#btnNuevo").click(function () {
    mostrarModal()
})

$("#btnRegistrar").click(function () {
       
    //const inputs = $("input.input-validar")serializeArray();
    //const inputs_sin_valor = inputs.filter((item) => item.value.trim() == "")


    //if (inputs_sin_valor.length > 0) {
    //    const mensaje = `Debe completar el campo: "${inputs_sin_valor[0].name}"`;
    //    toastr.warning("", mensaje);
    //    $('input[name="' + inputs_sin_valor[0].name + '"]').focus();
    //    return;
    //}

    const modelo = structuredClone(MODELO_BASE);
    modelo["idProveedor"] = parseInt($("#txtId").val())
    modelo["razonSocial"] = $("#txtRazonSocial").val()
    modelo["cuit"] = $("#txtCUIT").val()
    modelo["direccion"] = $("#txtDireccion").val()
    modelo["localidad"] = $("txtLocalidad").val()
    modelo["codigoPostal"] = $("#txtCodPostal").val()
    modelo["nombre"] = $("txtNombre").val()
    modelo["email"] = $("#txtCorreo").val()
    modelo["telefono"] = $("#txtTelefono").val()

    const formData = new FormData()
    formData.append("modelo", JSON.stringify(modelo))

    $("#modalData").find("div.modal-content").LoadingOverlay("show");

    if (modelo.idProveedor == 0) {

        fetch("/Proveedor/Crear", {
            method: "POST",
            body: formData
        })
            .then(response => {
                $("#modalData").find("div.modal-content").LoadingOverlay("hide");
                return response.ok ? response.json() : Promise.reject(response);
            })
        //.then(responseJson => {

        //    if (responseJson.estado) {
        //        tablaData.row.add(responseJson.objeto).draw(false)
        //        $("modalData").modal("hide")
        //        swal("Listo!", "Proveedor registrado correctamente", "success")
        //    } else{

        //        swal("Lo sentimos", responseJson.mensaje, "error")
        //    }
        //})

    } else {
        fetch("/Proveedor/Editar", {
            method: "PUT",
            body: formData
        })

            .then(response => {
                $("#modalData").find("div.modal-content").LoadingOverlay("hide");
                return response.ok ? response.json() : Promise.reject(response);
            })
            .then(responseJson => {

                if (responseJson.estado) {

                    tablaData.row(filaSeleccionada).data(responseJson.objeto).draw(false);
                    filaSeleccionada = null;
                    $("#modalData").modal("hide")
                    swal("Listo!", "El proveedor fue modificado", "success")
                } else {
                    swal("Los sentimos", responseJson.mensaje, "error")
                }
            })
    }

    let filaSeleccionada;
    $("#tbdata tbody").on("click", ".btn-editar", function () {

        if ($(this).closest("tr").hasClass("child")) {
            filaSeleccionada = $(this).closest("tr").prev();
        } else {
            filaSeleccionada = $(this).closest("tr");
        }

        const data = tablaData.row(filaSeleccionada).data();

        mostrarModal(data);

    })

    $("#tbdata tbody").on("click", ".btn-eliminar", function () {

        let fila;
        if ($(this).closest("tr").hasClass("child")) {
            fila = $(this).closest("tr").prev();
        } else {
            fila = $(this).closest("tr");
        }

        const data = tablaData.row(fila).data();

        swal({
            title: "¿Está seguro?",
            text: `Eliminar al proveedor "${data.nombre}"`,
            type: "warning",
            showCancelButton: true,
            confirmButtonClass: "btn-danger",
            confirmButtonText: "Si, eliminar",
            cancelButtonText: "No, cancelar",
            closeOnConfirm: false,
            closeOnCancel: true
        },
            function (respuesta) {

                if (respuesta) {

                    $(".showSweetAlert").LoadingOverlay("show");

                    fetch(`/Proveedor/Eliminar?IdProveedor=${data.idProveedor}`, {
                        method: "DELETE"
                    })
                        .then(response => {
                            $(".showSweetAlert").LoadingOverlay("hide");
                            return response.ok ? response.json() : Promise.reject(response);
                        })
                        .then(responseJson => {

                            if (responseJson.estado) {

                                tablaData.row(fila).remove().draw()

                                swal("Listo!", "El proveedor fue eliminado", "success")
                            } else {
                                swal("Los sentimos", responseJson.mensaje, "error")
                            }
                        })


                }
            }
        )


    })


    

        

    


    
})