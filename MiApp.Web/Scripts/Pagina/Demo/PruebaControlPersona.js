function LlamarControlPersona() {
    if (AcbTipoDocumento.GetValue() != null) {
        ApcControlPersona.PerformCallback(['levantar', AcbTipoDocumento.GetValue()]);
    } else {
        EnviarMensaje(0, 'Seleccione un tipo de documento');
    }
}

function RespuestaControlPersona(datos) {
    if (datos != null) {
        AbeRut.SetText(datos[0] + '-' + datos[1]);
        AtxNombre,SetTtet(datos[2])
    }
}