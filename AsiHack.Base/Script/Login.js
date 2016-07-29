$(document).ready(function(){
	$("#btnSubmit").click(function(){
        urlToHandler = 'handler.ashx';
		jsonData = '{ "username":"2010/01/01", "password": "hello" }';
			$.ajax({
                url: urlToHandler,
                data: jsonData,
                dataType: 'json',
                type: 'POST',
                contentType: 'application/json',
                success: function(data) {                        
                  alert("Success");  
				},
                error: function(data, status, jqXHR) {                        
                    alert('There was an error.');
                }
            }); // end $.ajax
    }); 
});