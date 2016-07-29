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
						if(obj.success == 1){
							window.location = '/homepage'
						}
                        else if(obj.success == 0){
							$("#loginStatus").attr('class', 'ui-state-error')  
							.html('<strong>ERROR</strong>: Your details were incorrect.<br />');
						}						
				},
                error: function(data, status, jqXHR) {                        
                    alert('There was an error.');
                }
            });
    }); 
});