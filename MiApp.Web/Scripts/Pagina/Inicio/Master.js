function Confirmar(mensaje) {
    return Swal.fire({
        icon: 'question',
        title: 'Pregunta',
        text: mensaje,
        showConfirmButton: true,
        confirmButtonText: 'Si, Estoy seguro',
        showDenyButton: true,
        denyButtonText: 'No, Ya me Arrepenti',
        allowOutsideClick: false
    }).then(response => {
        return response.value;
    });
}

function Imprimir(s) {
    if (s.cpImprimir) {
        window.open("../Varios/Reporte.aspx");
        delete s.cpImprimir;
    }
}

function MostrarSalidas(s) {
    if (s.cpSalidas != null) {
        s.cpSalidas.forEach(salida => EnviarMensaje(salida.Codigo, salida.Mensaje));
    }
}

function EnviarMensaje(codigo, mensaje) {
    toastr.options = {
        "closeButton": true,
        "newestOnTop": false,
        "progresbar": true,
        "positionClass": "toast-bottom.rigth",
        "preventDuplicate": false,
        "onclick": null,
        "timeOut": "10000"
    }
    if (mensaje != undefined && mensaje != null && codigo <= -1 && codigo != null) {
        Command: toastr["error"](mensaje);
    } if (mensaje != undefined && mensaje != null && codigo === 0 && codigo != null) {
        Command: toastr["info"](mensaje);
    } if (mensaje != undefined && mensaje != null && codigo >=  1 && codigo != null) {
        Command: toastr["success"](mensaje);
    }
}

ASPxClientControl.GetControlCollection().ControlsInitialized.AddHandler(function (s, e) {
    if (window.UpdateGridHeight) {
        UpdateGridHeight();
    }
});
ASPxClientControl.GetControlCollection().BrowserWindowResized.AddHandler(function (s, e){
    if(window.UpdateGridHeight)     {
    UpdateGridHeight();
    }
})