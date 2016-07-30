$(document).ready(function(){
	$("#btnSubmit").click(function(){
        urlToHandler = '/login';
		var obj = new Object();
		obj.username = $("#username").val();
		obj.password = $("#password").val();
		var jsonData = JSON.stringify(obj);
			$.ajax({
                url: urlToHandler,
                data: jsonData,
                dataType: 'json',
                type: 'POST',
                contentType: 'application/json',
                success: function(status) { 
						var obj = jQuery.parseJSON(status);
						if(obj.code == 0){
							$("#loginStatus").html('<strong>ERROR</strong>: Your details were incorrect.<br />');
						}
				},
                error: function(data, status, jqXHR) {                        
                    alert('There was an error.');
                }
            });
    }); 
});