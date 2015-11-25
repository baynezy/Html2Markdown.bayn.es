var clipboard = {
	init: function () {
		var client = new ZeroClipboard($("button#btnCopyToClipboard"));
	},
	
	loadEvents : function() {
		var copyTextareaBtn = document.querySelector("button#btnCopyToClipboard");

		copyTextareaBtn.addEventListener("click", function (event) {
			clipboard.copyToClipboard();
		});
	},
	
	copyToClipboard: function () {
		var copyTextarea = document.querySelector("#markdown");
		copyTextarea.select();

		try {
			var successful = document.execCommand("copy");
			var msg = successful ? "successful" : "unsuccessful";
			console.log("Copying text command was " + msg);
		} catch (err) {
			console.log("Oops, unable to copy");
		}
	}
};

$(document).ready(function() {
	clipboard.init();
});