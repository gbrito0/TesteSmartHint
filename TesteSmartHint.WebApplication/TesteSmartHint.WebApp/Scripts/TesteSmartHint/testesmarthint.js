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
