(function() {
  var __sections__ = {};
  (function() {
    for(var i = 0, s = document.getElementById('sections-script').getAttribute('data-sections').split(','); i < s.length; i++)
      __sections__[s[i]] = true;
  })();
  (function() {
  if (!__sections__["main-article-simple"]) return;
  try {
    
	var sideBarLeft = document.getElementById('sidebar_left');
	var sideBarRight = document.getElementById('sidebar_right');
	
	update = () => {
		if( window.innerWidth > 1199) {
			if (sideBarLeft != null) 
				sideBarLeft.classList.remove("offcanvas","offcanvas-start");
			if (sideBarRight != null) 
				sideBarRight.classList.remove("offcanvas","offcanvas-end");
		} else {
			if (sideBarLeft != null) 
				sideBarLeft.classList.add("offcanvas","offcanvas-start");
			if (sideBarRight != null) 
				sideBarRight.classList.add("offcanvas","offcanvas-end");
		}
	}
	if (sideBarLeft != null || sideBarRight != null) {
		window.update();
		window.addEventListener('resize', update);
	}

  } catch(e) { console.error(e); }
})();

(function() {
  if (!__sections__["main-article"]) return;
  try {
    
	var sideBarLeft = document.getElementById('sidebar_left');
	var sideBarRight = document.getElementById('sidebar_right');
	
	update = () => {
		if( window.innerWidth > 992) {
			if (sideBarLeft != null) 
				sideBarLeft.classList.remove("offcanvas","offcanvas-start");
			if (sideBarRight != null) 
				sideBarRight.classList.remove("offcanvas","offcanvas-end");
		} else {
			if (sideBarLeft != null) 
				sideBarLeft.classList.add("offcanvas","offcanvas-start");
			if (sideBarRight != null) 
				sideBarRight.classList.add("offcanvas","offcanvas-end");
		}
	}
	if (sideBarLeft != null || sideBarRight != null) {
		window.update();
		window.addEventListener('resize', update);
	}

  } catch(e) { console.error(e); }
})();

(function() {
  if (!__sections__["main-blog-style1"]) return;
  try {
    
	var sideBarLeft = document.getElementById('sidebar_left');
	var sideBarRight = document.getElementById('sidebar_right');
	
	update = () => {
		if( window.innerWidth > 1199) {
			if (sideBarLeft != null) 
				sideBarLeft.classList.remove("offcanvas","offcanvas-start");
			if (sideBarRight != null) 
				sideBarRight.classList.remove("offcanvas","offcanvas-end");
		} else {
			if (sideBarLeft != null) 
				sideBarLeft.classList.add("offcanvas","offcanvas-start");
			if (sideBarRight != null) 
				sideBarRight.classList.add("offcanvas","offcanvas-end");
		}
	}
	if (sideBarLeft != null || sideBarRight != null) {
		window.update();
		window.addEventListener('resize', update);
	}

  } catch(e) { console.error(e); }
})();

(function() {
  if (!__sections__["main-blog"]) return;
  try {
    
	var sideBarLeft = document.getElementById('sidebar_left');
	var sideBarRight = document.getElementById('sidebar_right');
	
	update = () => {
		if( window.innerWidth > 992) {
			if (sideBarLeft != null) 
				sideBarLeft.classList.remove("offcanvas","offcanvas-start");
			if (sideBarRight != null) 
				sideBarRight.classList.remove("offcanvas","offcanvas-end");
		} else {
			if (sideBarLeft != null) 
				sideBarLeft.classList.add("offcanvas","offcanvas-start");
			if (sideBarRight != null) 
				sideBarRight.classList.add("offcanvas","offcanvas-end");
		}
	}
	if (sideBarLeft != null || sideBarRight != null) {
		window.update();
		window.addEventListener('resize', update);
	}

  } catch(e) { console.error(e); }
})();

(function() {
  if (!__sections__["main-cart"]) return;
  try {
    
    class CartNote extends HTMLElement {
        constructor() {
        super();

        this.addEventListener('change', debounce((event) => {
            const body = JSON.stringify({ note: event.target.value });
            fetch(`${routes.cart_update_url}`, {...fetchConfig(), ...{ body }});
        }, 300))
        }
    }
    customElements.define('cart-note', CartNote);

  } catch(e) { console.error(e); }
})();

(function() {
  if (!__sections__["product-recommendations"]) return;
  try {
    
	class ProductRecommendations extends HTMLElement {
		constructor() {
		super();
		const handleIntersection = (entries, observer) => {
			if (!entries[0].isIntersecting) return;
			observer.unobserve(this);
			fetch(this.dataset.url)
			.then(response => response.text())
			.then(text => {
				const html = document.createElement('div');
				html.innerHTML = text;
				const recommendations = html.querySelector('product-recommendations');
				if (recommendations && recommendations.innerHTML.trim().length) {
					this.innerHTML = recommendations.innerHTML;
					var tooltipTriggerList = [].slice.call(document.querySelectorAll('[data-bs-toggle="tooltip"]'));
                    var tooltipList = tooltipTriggerList.map(function (tooltipTriggerEl) {
                      	return new bootstrap.Tooltip(tooltipTriggerEl)
                    });
					if (vela.settings.currencies) {
						Currency.convertAll(shopCurrency, $('[name=currencies]').data('value'));
						velaCurrencyCurrent.text(Currency.currentCurrency);
					} 
					if (window.SPR && vela.settings.enableReview) {
						return window.SPR.registerCallbacks(), window.SPR.initRatingHandler(), window.SPR.initDomEls(), window.SPR.loadProducts(), window.SPR.loadBadges();				
					}
				}
			})
			.catch(e => {
				console.error(e);
			});
		}
	
		new IntersectionObserver(handleIntersection.bind(this), {rootMargin: '0px 0px 200px 0px'}).observe(this);
		}
	}
	customElements.define('product-recommendations', ProductRecommendations);

  } catch(e) { console.error(e); }
})();

})();
