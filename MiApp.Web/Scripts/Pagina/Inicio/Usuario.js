async function ConfirmarUsuarioGuardar(AgvUsuario) {
    if (ASPxClientEdit.ValidateEditorsInContainerById('AgvUsuario')) {
        if (await Confirmar('Se dispone a guardar el registro. ¿Esta seguro?')) {
            AgvUsuario.UpdateEdit();
        }
    }
}

async function ConfirmarUsuarioCancelar(AgvUsuario) {
    if (await Confirmar('Se dispone a cancelar el registro. ¿Esta seguro?')) {
        AgvUsuario.CancelEdit();

    }
}

async function OnToolbarItemClick(s, e) {
    if (e.item.name == "Delete") {
        if (await Confirmar('Se dispone a eliminar el registro. ¿Esta seguro?')) {
            s.DeleteRow(s.focusedRowIndex);
        }
    }
    if (e.item.name == "Print") {
        e.processOnServer = true;
    }
}
function EndCallbackAgvUsuario(s) {
    MostrarSalidas(S);
    Imprimir(s);
}


function UpdateGridHeight() {
    AgvUsuario.SetHeight(0);
    var containerHeight = ASPxClientUtils.GetDocumentClientHeight();
    if (document.body.scrollHeight > containerHeight)
        containerHeight = document.Body.scrollHeight;
    AgvUsuario.SetHeight(containerHeight - AplTitulo.GetHeight() - 114);
}   
