var campoFiltro = document.querySelector("#filtro-tabela");

campoFiltro.addEventListener("input", function(){
    console.log(this.value);
    var clientes = document.querySelectorAll(".cliente-tr");
    
    if (this.value.length > 0) {
        for (let i = 0; i < clientes.length; i++) {
            let cliente = clientes[i];
            let nomeTd = cliente.querySelector(".info-nome");
            var nome = nomeTd.textContent;
            var expressao = new RegExp(this.value, "i");

            if ( !(expressao.test(nome))) {
                
                cliente.classList.add("invisivel");
            }else{
                
                cliente.classList.remove("invisivel")
            }
            
        }
    }else{
        clientes.forEach(paciente => {
            paciente.classList.remove("invisivel");
        });
    }

    
});
