var carouselIndex;

$(document).ready(function(){
	$("#menu-toggle").click(function(e) {
	    e.preventDefault();
	    $("#wrapper").toggleClass("toggled");
	    $("#overlay").toggle();
	});	

	startCarousel(3);
});

function startCarousel(sec){
	var $carouselImg = $(".carousel-img");
	var $carousel = $("#carousel");
	var length = $carouselImg.length;
	carouselIndex =0;
	$elTarget.css('background-image', "url('"+$elImg[carouselIndex].getAttribute("src")+"')");
	carouselIndex++;
	setInterval(function(){
		changeCarousel(length,$carouselImg,$carousel);
		}, sec*1000);
}

function changeCarousel(maxIndex,$elImg,$elTarget){
	if(carouselIndex < maxIndex){		
   		$elTarget.css('background-image', "url('"+$elImg[carouselIndex].getAttribute("src")+"')");
		carouselIndex++;
	}else{
		carouselIndex=0;
	}
}

