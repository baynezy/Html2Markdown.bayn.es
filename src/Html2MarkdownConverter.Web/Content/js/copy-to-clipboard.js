var clipboard = {
	init: function () {
		this.loadEvents();
	},
	
	loadEvents : function() {
		$("button#btnCopyToClipboard").on("click", function() {
			clipboard.copyToClipboard();
		});
	},
	
	copyToClipboard: function () {
		var copyTextarea = document.querySelector("#markdown");
		copyTextarea.select();
		
		try {
			var successful = document.execCommand("copy");
			var msg = successful ? 'successful' : 'unsuccessful';
			console.log('Copying text command was ' + msg);
		} catch (err) {
			console.log('Oops, unable to copy');
		}
	}
};

$(document).ready(function() {
	clipboard.init();
});