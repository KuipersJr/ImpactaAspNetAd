var ProdutoViewModel = ProdutoViewModel || {
    self: this,

    inicializar: function (instancia) {
        self = instancia;
        self.vincularSubmeter();
    },
    vincularSubmeter: function () {
        $("#produtoForm").on("submit", function (event) {
            var $this = $(this);
            $.ajax({
                type: $this.attr('method'),
                url: $this.attr('action'),
                data: self.obterProduto()
            })
            .success(function () {
                alert("Produto gravado com sucesso!");
                $this[0].reset();
            })
            .error(function () {
                alert("Erro ao gravar o produto.");
            });
            event.preventDefault();
        });
    },
    obterProduto: function () {
        return {
            id: $("#id").val(),
            nome: $("#nome").val(),
            preco: $("#preco").val(),
            categoria: { id: $("#categoriaId").val() }
        };        
    }
};