function loadHtml(elID, url){	
	var xmlhttp;

	if(window.XMLHttpRequest){
		xmlhttp = new XMLHttpRequest();
	}else{
		xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
	}

	xmlhttp.onreadystatechange = function(){
		if(xmlhttp.readyState == 4){
			if(xmlhttp.status == 200){
				document.getElementById(elID).innerHTML = xmlhttp.responseText;
			}else{
				alert("error");
			}
		}
	}

	xmlhttp.open("GET", url, true);
	xmlhttp.send(null);


}

loadHtml("sideNav", "TopNav");