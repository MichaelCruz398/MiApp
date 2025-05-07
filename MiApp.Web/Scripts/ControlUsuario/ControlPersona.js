function DobleClickFila(s, e) {
    function datosGrilla(valores) {
        ApcControlPersona.Hide();
        RespuestaControlPersona(valores);
    }
    s.GetRowValues(e.visibleIndex, 'Rut;Dv;Nombre', datosGrilla);
}