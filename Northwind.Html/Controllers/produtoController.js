var ProdutoController = ProdutoController || {
    self: this,

    inicializar: function (instancia) {
        self = instancia;
        self.vincularSubmeter();
        self.carregarCategorias();
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
    },
    carregarCategorias: function () {
        $("#categoriaId").select2({
            //minimumInputLength: 2,
            //tags: [],
            ajax: {
                url: "",
                dataType: 'json',
                type: "GET",
                //quietMillis: 50,
                //data: function (term) {
                //    return {
                //        term: term
                //    };
                //},
                results: function (data) {
                    return {
                        results: $.map(data, function (item) {
                            return {
                                text: item.nome,
                                //slug: item.slug,
                                id: item.id
                            }
                        })
                    };
                }
            }
        });
    }
};