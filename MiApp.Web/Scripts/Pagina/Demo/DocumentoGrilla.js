function EndCallbackAgvDocumentoGrilla(s) {
    MostrarSalidas(s);
    Imprimir(s);
    if (s.cpItemInyectados) {
        delete s.cpItemsInyectados;
        AcpItem.Hide();
        AgvDocumentoGrilla.ExpandDetailRow(AgvDocumentoGrilla.focusedRowIndex);
    }
}

function OnToolbarItemClick(s, e) {
    if (e.item.name == "Print") {
        e.processOnServer = true;
    }
}


function DesEnfocar() {
    AgvDocumentoGrilla.SetFocusedRowIndex(-1);
}

async function EliminarDesdeFuera() {
    if (AgvDocumentoGrilla.focusedRowIndex >= 0) {
        async function datosGrilla(valores) {
            if (await Confirmar('¿Seguro desea eliminar el documento con el codigo: ' + valores[0] + ' y la Glosa ' + valores[1] + ' ?')) {

                AgvDocumentoGrilla.DeleteRow(AgvDocumentoGrilla.focusedRowIndex);
            }
        }
        AgvDocumentoGrilla.GetRowValues(AgvDocumentoGrilla.focusedRowIndex, 'Codigo;Glosa', datosGrilla);
    } else {
        EnviarMensaje(0, 'Seleccione un documento.');
    }
}


function LevantarPopUpInyectarItems(s, e) {
    ApcItem.Show();
}

function LlamarAsdItem() {
    ApcItem.PerformCallback();        
}

function InyectarDocumento() {
    AcpDocumentoGrilla.PerformCallback('InyectarItems');
}

function UpdateGridHeight() {
    AgvDocumentoGrilla.SetHeight(0);
    var containerHeight = ASPxClientUtils.GetDocumentClientHeight();
    if (document.body.scrollHeight > containerHeight)
        containerHeight = document.body.scrollHeight;
    AgvDocumentoGrilla.SetHeight(containerHeight - AplTitulo.GetHeight() - 137);
}
    
