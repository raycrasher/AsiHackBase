$(document).ready(function(){
$("#btnSubmit").click(function(){
       urlToHandler = '/login';
var obj = new Object();
obj.username = $("#user").val();
obj.password = $("#password").val();
var jsonData = JSON.stringify(obj);
$.ajax({
               url: urlToHandler,
               data: jsonData,
               dataType: 'jsonp',
               type: 'POST',
               contentType: 'application/json',
               success: function (status) {
                   if (status.statusCode == 1) {
                       window.location = "/Homepage";
                   }
                   else {
                       $("#lblError").html('<strong>ERROR</strong>: Your details were incorrect.<br />');

                   }},
               error: function (error) {
                   console.log(error)
               }
           });
   }); 
});