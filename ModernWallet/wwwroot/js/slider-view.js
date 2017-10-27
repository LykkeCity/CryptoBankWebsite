var app = app || {};

(function activateSlider($, doc) {

	app.Slider = Object.create(app.BaseView);

	app.Slider.name = "Slider";

	/***
     * Start scroll functionality
     * returns void
     */
	app.Slider.init = function () {
		this.bindEvents();
		if (doc.querySelector('.carousel-init')) {
            this.events.notify(doc, 'activate:slider');
        }
	};


	//bind this
	app.Slider.init = app.Slider.init.bind(app.Slider);

	app.Slider.bindEvents = function () {

		// console.log('slider binded');
		this.sliderControls = this.sliderControls.bind(this);
	    this.events.on(doc, 'activate:slider', this.sliderControls);


	};

	app.Slider.sliderControls = function() {

	 	var slide = $('.carousel-init');
	    slide.owlCarousel({
			items : 1,
			singleItem: true,
			lazyLoad : true,
			navigation : false,
			autoPlay: true,
			stopOnHover: true,
			navigationText: ['<span class="owl-custon-arrows icon-left-open"></span>', '<span class="owl-custon-arrows icon-right-open"></span>']
	    });

	    var paginationBtns = doc.querySelectorAll('.owl-page span');

	    for(var i = 0; i < paginationBtns.length; i++) {
	        paginationBtns[i].innerHTML = i + 1;
        }
	};

	app.Slider.init();
})(jQuery, document);