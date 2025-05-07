function OnTipoDocumentoChanged(s) {
    if (!AcbPersona.InCallback()) {
        AcbPersona.PerformCallback(s.GetValue().toString()); 
    }
}

function OnItemsClick() {
    ApcItem.Show();
}

function EndCallbackAcpDocumento(s) {
    if (s.cpCodigo != null) {
        EnviarMensaje(s.cpCodigo, s.cpMensaje);
        delete s.cpCodigo;
        delete s.cpMensaje;
    }
    if (s.cpLimpiar) {
        ASPxClientEdit.ClearEditorsInContainerById('AflDocumento');
        delete s.cpLimpiar;
    }
}

function Guardar() {
    if (ASPxClientEdit.ValidateEditorsInContainerById('AflDocumento')) {
        AcpDocumento.PerformCallback();
    }
}