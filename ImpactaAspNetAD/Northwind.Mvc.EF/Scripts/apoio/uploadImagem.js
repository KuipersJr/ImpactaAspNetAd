var uploadImagem = uploadImagem || {
	definirPreview: function (inputFileId, imageHolderId) {
		var inputFile = $("#" + inputFileId);
		var imageHolder = $("#" + imageHolderId);

		inputFile.on('change', function () {
			if (typeof (FileReader) == "undefined") {
				alert("This browser does not support FileReader.");
			} else {
				imageHolder.empty();

				var reader = new FileReader();

				reader.onload = function (e) {
					imageHolder.attr('src', e.target.result);
				}			

				reader.readAsDataURL(this.files[0]);

				imageHolder.css('visibility', 'visible');
			}
		});
	}
};