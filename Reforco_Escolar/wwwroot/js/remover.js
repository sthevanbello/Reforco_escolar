var pacientes = document.querySelectorAll(".cliente-tr");

var tabela = document.querySelector("#tabela-clientes");

tabela.addEventListener("dblclick", function(event){
    let alvoDoEvento = event.target;
    let paiDoAlvo = alvoDoEvento.parentNode;
    paiDoAlvo.classList.add("fadeOut");
    
    setTimeout(() => {  paiDoAlvo.remove(); }, 500);
});

