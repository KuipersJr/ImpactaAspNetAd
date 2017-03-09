var ProdutoController = ProdutoController || {
    self: this,

    inicializar: function (instancia) {
        self = instancia;
        self.vincularSubmeter();
        self.carregarCategorias();
    },
    vincularSubmeter: function () {
        $("#produtoForm").on("submit", function (event) {
            var form = $(this);
            $.ajax({
                type: form.attr('method'),
                url: form.attr('action'),
                data: self.obterProduto()
            })
            .success(function () {
                alert("Produto gravado com sucesso!");
                form[0].reset();
                $("#categoriaId").html("");
            })
            .fail(function (jqXHR, textStatus, errorThrown) {
                console.log(errorThrown);

                alert("Erro ao gravar o produto.");
            });

            event.preventDefault();
        });
    },
    obterProduto: function () {
        var produto = {
            id: $("#id").val(),
            nome: $("#nome").val(),
            preco: $("#preco").val(),
            categoria: { id: $("#categoriaId").val() }
        };

        return produto;
    },
    carregarCategorias: function () {
        $("#categoriaId").select2({
            ajax: {
                url: "http://localhost/Northwind.WebApi/api/Categorias",
                dataType: 'json',

                processResults: function (data) {
                    var results = [];
                    $.each(data, function (index, categoria) {
                        results.push({
                            id: categoria.Id,
                            text: categoria.Nome
                        });
                    });
                    return {
                        results: results
                    };
                }
            }
        });
    }
};
