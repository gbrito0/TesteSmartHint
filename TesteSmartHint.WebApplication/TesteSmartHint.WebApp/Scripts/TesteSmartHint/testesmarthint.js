//OnChange ddlPessoa
$('#ddlPessoa').change(function () {
    $('#txtDocumento')[0].value = "";
    $('#txtDocumento').unmask();
    if ($('#ddlPessoa')[0].value == 0) {
        $('#txtDocumento').mask('000.000.000-00', { reverse: true }); //CPF
        collapseAll();
    }
    else {
        $('#txtDocumento').mask('00.000.000/0000-00', { reverse: true }); //CNPJ
        collapseAll();
    }
});

//OnChange chkIsento
$("#chkIsento").change(function () {
    $('#txtInscricaoEstadual')[0].value = "";
    $('#txtInscricaoEstadual')[0].disabled = this.checked;
});

//Checa confirmação de senha
$('#txtSenha, #txtConfirmarSenha').on('keyup', function () {
    if ($('#txtSenha').val() != $('#txtConfirmarSenha').val()) {
        $('#txtConfirmarSenha').removeClass("is-valid");
        $('#txtConfirmarSenha').addClass("is-invalid");
    } else {
        $('#txtConfirmarSenha').removeClass("is-invalid");
        $('#txtConfirmarSenha').addClass("is-valid");
    }
});

function bloqueiaCampos() {
    let input = document.getElementsByClassName("form-control");
    for (var i = 0; i < input.length; i++) {
        if (input[i].disabled == false)
            input[i].disabled = true;
    }
};
function limparCampos() {
    let input = document.querySelectorAll(".form-control, .form-select, .form-check-input");
    for (var i = 0; i < input.length; i++) {
        if (!input[i].classList.contains("btn"))
            input[i].value = "";

        if (input[i].classList.contains("cbo"))
            input[i].value = 0;

        if (input[i].classList.contains("chk")) {
            input[i].checked = false;
        }
    }
    return false;
};
function collapseAll() {
    var collapseElementList = [].slice.call(document.querySelectorAll('.collapse'))
    var collapseList = collapseElementList.map(function (collapseEl) {
        return new bootstrap.Collapse(collapseEl)
    })
};

function selectAllCheckGrid(chk) {

    var GridView1 = document.getElementById("grvCompradores");
    for (i = 1; i < GridView1.rows.length; i++) {
        GridView1.rows[i].cells[0].getElementsByTagName("INPUT")[0].checked = chk.checked;
    }

}
