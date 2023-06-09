window.vela=window.vela||{},vela.LibraryLoader=function(){var o={link:"link",script:"script"},e={requested:"requested",loaded:"loaded"},s="https://cdn.shopify.com/shopifycloud/",i={youtubeSdk:{tagId:"youtube-sdk",src:"https://www.youtube.com/iframe_api",type:o.script},plyrShopifyStyles:{tagId:"plyr-shopify-styles",src:s+"shopify-plyr/v1.0/shopify-plyr.css",type:o.link},modelViewerUiStyles:{tagId:"shopify-model-viewer-ui-styles",src:s+"model-viewer-ui/assets/v1.0/model-viewer-ui.css",type:o.link}};function r(c,h){var d=i[c];if(d&&d.status!==e.requested){if(h=h||function(){},d.status===e.loaded){h();return}d.status=e.requested;var l;switch(d.type){case o.script:l=t(d,h);break;case o.link:l=u(d,h);break}l.id=d.tagId,d.element=l;var a=document.getElementsByTagName(d.type)[0];a.parentNode.insertBefore(l,a)}}function t(c,h){var d=document.createElement("script");return d.src=c.src,d.addEventListener("load",function(){c.status=e.loaded,h()}),d}function u(c,h){var d=document.createElement("link");return d.href=c.src,d.rel="stylesheet",d.type="text/css",d.addEventListener("load",function(){c.status=e.loaded,h()}),d}return{load:r}}(),vela.Variants=function(){function o(e){this.$container=e.$container,this.product=e.product,this.productSelectOption=e.productSelectOption,this.singleOptionSelector=e.singleOptionSelector,this.originalSelectorId=e.originalSelectorId,this.enableHistoryState=e.enableHistoryState,this.currentVariant=this._getVariantFromOptions(),$(this.singleOptionSelector,this.$container).on("change",this._onSelectChange.bind(this))}return o.prototype=_.assignIn({},o.prototype,{_getCurrentOptions:function(){var e=_.map($(this.singleOptionSelector,this.$container),function(s){var i=$(s),r=i.attr("type"),t={};return r==="radio"||r==="checkbox"?i[0].checked?(t.value=i.val(),t.index=i.data("index"),t):!1:(t.value=i.val(),t.index=i.data("index"),t)});return e=_.compact(e),e},_getVariantFromOptions:function(){for(var e=this._getCurrentOptions(),s=this.product.variants,i=_.find(s,function(u){return e.every(function(c){return _.isEqual(u[c.index],c.value)})}),r=0;r<e.length;r++){var t=r+1;$(".js-swatch-display--"+t).text(e[r].value)}return i},_onSelectChange:function(){var e=this._getVariantFromOptions();if($("[data-single-option-button]",this.$container).length&&(this._updateVariantsButton(),!e||!e.available)){this._updateVariantsButtonDisabed();return}this.$container.trigger({type:"variantChange",variant:e}),e&&(this._updateMasterSelect(e),this._updateMedia(e),this._updatePrice(e),this._updateSKU(e),this.currentVariant=e,this._updateSwatchTitle(e),this.enableHistoryState&&this._updateHistoryState(e))},_updateVariantsButtonDisabed:function(){for(var e=2;e<=3;e++)if($(this.productSelectOption+e,this.$container).length){var s=!1;$(this.productSelectOption+e+" "+this.singleOptionSelector,this.$container).each(function(){var i=$(this),r=i.attr("type");if((r==="radio"||r==="checkbox")&&this.checked&&i.hasClass("disabled"))return i.prop("checked",!1),s=!0,!1}),$(this.productSelectOption+e+" "+this.singleOptionSelector,this.$container).each(function(){var i=$(this),r=i.attr("type");if(s&&(r==="radio"||r==="checkbox")&&!i.hasClass("disabled"))return i.prop("checked",!0),s=!1,i.trigger("change"),!1})}},_updateVariantsButton:function(){for(var e=this._getCurrentOptions(),s=this.product.variants,i=2;i<=3;i++)$(this.productSelectOption+i,this.$container).length&&$(this.productSelectOption+i+" "+this.singleOptionSelector,this.$container).each(function(){var r=$(this),t=r.val(),u;i===2?u=_.findIndex(s,function(c){return c.option1===e[0].value&&c.option2===t&&c.available===!0}):i===3&&(u=_.findIndex(s,function(c){return c.option1===e[0].value&&c.option2===e[1].value&&c.option3===t&&c.available===!0})),u!==-1?(r.removeAttr("disabled","disabled").removeClass("disabled"),r.next("label").removeClass("disabled")):(r.attr("disabled","disabled").addClass("disabled"),r.next("label").addClass("disabled"))})},_updateMedia:function(e){var s=e.featured_media||{},i=this.currentVariant.featured_media||{},r=!1;s.preview_image&&i.preview_image&&(r=s.preview_image.src===i.preview_image.src),!(!e.featured_media||r)&&this.$container.trigger({type:"variantMediaChange",variant:e})},_updatePrice:function(e){e.price===this.currentVariant.price&&e.compare_at_price===this.currentVariant.compare_at_price||this.$container.trigger({type:"variantPriceChange",variant:e})},_updateSKU:function(e){e.sku!==this.currentVariant.sku&&this.$container.trigger({type:"variantSKUChange",variant:e})},_updateSwatchTitle:function(){for(var e=1;e<=3;e++)$(".js-swatch-display--"+e).text(this.currentVariant["option"+e])},_updateHistoryState:function(e){if(!(!history.replaceState||!e)){var s=window.location.protocol+"//"+window.location.host+window.location.pathname+"?variant="+e.id;window.history.replaceState({path:s},"",s)}},_updateMasterSelect:function(e){$(this.originalSelectorId,this.$container).val(e.id)}}),o}(),vela.ProductModel=function(){var o={},e={},s={},i={productMediaGroup:".js-product-media-group",productMediaGroupWrapper:".js-product-single-media",xrButton:"[data-shopify-xr]",xrButtonSingle:"[data-shopify-xr-single]"},r={viewInSpaceDisabled:"product-single__view-in-space--disabled"};function t(l,a){o[a]={loaded:!1},l.each(function(n){var p=$(this),f=p.data("media-id"),m=$(p.find("model-viewer")[0]),v=m.data("model-id");if(n===0){var y=p.closest(i.productMediaGroupWrapper).find(i.xrButtonSingle);s[a]={$element:y,defaultId:v}}e[f]={modelId:v,sectionId:a,$container:p,$element:m}}),window.Shopify.loadFeatures([{name:"shopify-xr",version:"1.0",onLoad:u}]),!(e.length<1)&&(window.Shopify.loadFeatures([{name:"model-viewer-ui",version:"1.0",onLoad:c}]),vela.LibraryLoader.load("modelViewerUiStyles"))}function u(l){if(!l){if(!window.ShopifyXR){document.addEventListener("shopify_xr_initialized",function(f){f.detail.shopifyXREnabled?u():$(i.xrButton).addClass(r.viewInSpaceDisabled)});return}for(var a in o)if(o.hasOwnProperty(a)){var n=o[a];if(n.loaded)continue;var p=$("#ModelJson-"+a);window.ShopifyXR.addModels(JSON.parse(p.html())),n.loaded=!0}window.ShopifyXR.setupXRElements()}}function c(l){if(!l){for(var a in e)if(e.hasOwnProperty(a)){var n=e[a];n.modelViewerUi||(n.modelViewerUi=new Shopify.ModelViewerUI(n.$element)),h(n)}}}function h(l){var a=s[l.sectionId],n=l.$container.closest(i.productMediaGroup);l.$element.on("shopify_model_viewer_ui_toggle_play",function(){vela.updateSlickSwipe(n,!1)}).on("shopify_model_viewer_ui_toggle_pause",function(){vela.updateSlickSwipe(n,!0)}),l.$container.on("mediaVisible",function(){a.$element.attr("data-shopify-model3d-id",l.modelId),l.modelViewerUi.play()}),l.$container.on("mediaHidden",function(){a.$element.attr("data-shopify-model3d-id",a.defaultId),l.modelViewerUi.pause()}).on("xrLaunch",function(){l.modelViewerUi.pause()})}function d(l){for(var a in e)if(e.hasOwnProperty(a)){var n=e[a];n.sectionId===l&&(e[a].modelViewerUi.destroy(),delete e[a])}delete o[l]}return{init:t,removeSectionModels:d}}();function onYouTubeIframeAPIReady(){vela.ProductVideo.loadVideos(vela.ProductVideo.hosts.youtube)}vela.ProductVideo=function(){var o={},e={html5:"html5",youtube:"youtube"},s={productMediaWrapper:".js-product-media",productMediaGroup:".js-product-media-group"},i={enableVideoLooping:"enable-video-looping",videoId:"video-id"};function r(a,n){if(a.length){var p=a.find("iframe, video")[0],f=a.data("mediaId");if(p){o[f]={mediaId:f,sectionId:n,host:c(p),container:a,element:p,ready:function(){u(this)}};var m=o[f];switch(m.host){case e.html5:window.Shopify.loadFeatures([{name:"video-ui",version:"1.1",onLoad:t}]),vela.LibraryLoader.load("plyrShopifyStyles");break;case e.youtube:vela.LibraryLoader.load("youtubeSdk");break}}}}function t(a){if(a){d();return}h(e.html5)}function u(a){if(!a.player){var n=a.container.closest(s.productMediaWrapper),p=n.data(i.enableVideoLooping);switch(a.host){case e.html5:a.player=new Shopify.Plyr(a.element,{loop:{active:p}});var f=$(a.container).closest(s.productMediaGroup);a.player.on("seeking",function(){vela.updateSlickSwipe(f,!1)}),a.player.on("seeked",function(){vela.updateSlickSwipe(f,!0)});break;case e.youtube:var m=n.data(i.videoId);a.player=new YT.Player(a.element,{videoId:m,events:{onStateChange:function(v){v.data===0&&p&&v.target.seekTo(0)}}});break}n.on("mediaHidden xrLaunch",function(){a.player&&(a.host===e.html5&&a.player.pause(),a.host===e.youtube&&a.player.pauseVideo&&a.player.pauseVideo())}),n.on("mediaVisible",function(){a.player&&(a.host===e.html5&&a.player.play(),a.host===e.youtube&&a.player.playVideo&&a.player.playVideo())})}}function c(a){return a.tagName==="VIDEO"?e.html5:a.tagName==="IFRAME"&&/^(https?:\/\/)?(www\.)?(youtube\.com|youtube-nocookie\.com|youtu\.?be)\/.+$/.test(a.src)?e.youtube:null}function h(a){for(var n in o)if(o.hasOwnProperty(n)){var p=o[n];p.host===a&&p.ready()}}function d(){for(var a in o)if(o.hasOwnProperty(a)){var n=o[a];if(n.nativeVideo)continue;n.host===e.html5&&(n.element.setAttribute("controls","controls"),n.nativeVideo=!0)}}function l(a){for(var n in o)if(o.hasOwnProperty(n)){var p=o[n];p.sectionId===a&&(p.player&&p.player.destroy(),delete o[n])}}return{init:r,hosts:e,loadVideos:h,removeSectionVideos:l}}(),vela.Product=function(){function o(e){var s=$(window),i=this.$container=$(e),r=i.attr("data-section-id");this.settings={productPageLoad:!1,preloadImage:!1,enableHistoryState:i.data("enable-history-state"),namespace:".productSection",sectionId:r},this.selectors={productMediaGroup:".js-product-media-group",productMediaGroupItem:".js-product-media-item",productMediaWrapper:".js-product-media",productMediaTypeModel:"[data-product-media-type-model]",productMediaTypeVideo:"[data-product-media-type-video]",productThumbnails:".js-product-thumbnails",productThumbnailVertical:".product-single__media--thumbnails-vertical",productThumbnail:"[data-product-thumbnail]",productImageZoom:"[data-mfp-src]",meta:".product-single__meta",productWrapper:".product-single",productSelectOption:".js-product-select-option--",originalSelectorId:".js-product-select",singleOptionSelector:".js-single-option-selector",slickDots:"[data-slick-dots]",slickNext:"[data-slick-next]",slickPrevious:"[data-slick-previous]",variantColor:"[data-color]"},this.classes={hide:"d-none",priceContainerUnitAvailable:"price-container--unit-available",productInventoryInStock:"product-avaiable__text--instock",productInventoryOutStock:"product-avaiable__text--outstock"},this.slickMediaSettings={slide:this.selectors.productMediaGroupItem,rows:0,accessibility:!0,arrows:!0,appendDots:this.selectors.slickDots,prevArrow:this.selectors.slickPrevious,nextArrow:this.selectors.slickNext,dots:!0,infinite:!1,adaptiveHeight:!0,customPaging:function(t,u){var c=vela.strings.productSlideLabel.replace("[slide_number]",u+1).replace("[slide_max]",t.slideCount),h=$('[data-slick-index="'+u+'"]',this.$container).data("slick-media-label"),d=u===0?' aria-current="true"':"";return'<a href="javascript:void(0)" aria-label="'+c+" "+h+'" aria-controls="slick-slide0'+u+'"'+d+"></a>"}.bind(this)},$("#ProductJson-"+r).html()&&(this.productSingleObject=JSON.parse(document.getElementById("ProductJson-"+r).innerHTML),this.zoomType=i.data("image-zoom-type"),this.isStackedLayout=i.data("stacked-layout"),this.focusableElements=["iframe","input","button","video",'[tabindex="0"]'].join(","),this.slickThumbsSettings={slidesToShow:$(this.selectors.productThumbnails).data("thumbnails-show"),slidesToScroll:1,rows:0,vertical:$(this.selectors.productThumbnailVertical).length>0,accessibility:!0,infinite:!1,focusOnSelect:!0,adaptiveHeight:!0,responsive:[{breakpoint:1230,settings:{slidesToShow:5}},{breakpoint:992,settings:{vertical:!1,slidesToShow:4}}]},!this.isStackedLayout&&$(this.selectors.productMediaGroup,this.$container)&&$(this.selectors.productThumbnails,this.$container)&&(this.slickMediaSettings.asNavFor=this.selectors.productThumbnails+"-"+r,this.slickThumbsSettings.asNavFor=this.selectors.productMediaGroup+"-"+r),this.initBreakpoints(),this.initProductVariant(),this.initModelViewerLibraries(),this.initShopifyXrLaunch(),this.initProductVideo(),this.zoomType&&this.productMediaZoom())}return o.prototype=_.assignIn({},o.prototype,{initBreakpoints:function(){var e=this;enquire.register(vela.variables.mediaTablet,{match:function(){e.zoomType&&$(e.selectors.productImageZoom).length&&$(e.selectors.productImageZoom).off()},unmatch:function(){e.zoomType&&e.productMediaZoom()}}),e.isStackedLayout?enquire.register(vela.variables.mediaTablet,{match:function(){e.createMediaCarousel()},unmatch:function(){e.destroyMediaCarousel()}}):(e.createMediaCarousel(),e.createThumbnailCarousel())},initProductVariant:function(){var e={$container:this.$container,enableHistoryState:this.settings.enableHistoryState||!1,productSelectOption:this.selectors.productSelectOption,singleOptionSelector:this.selectors.singleOptionSelector,originalSelectorId:this.selectors.originalSelectorId+"--"+this.settings.sectionId,product:this.productSingleObject};this.variants=new vela.Variants(e),this.$container.on("variantChange"+this.settings.namespace,this.productPage.bind(this)),this.$container.on("variantMediaChange"+this.settings.namespace,this.showVariantMedia.bind(this))},initModelViewerLibraries:function(){if(this.$container.data("has-model")){var e=$(this.selectors.productMediaTypeModel,this.$container);vela.ProductModel.init(e,this.settings.sectionId)}},initShopifyXrLaunch:function(){$(document).on("shopify_xr_launch",function(){var e=$(this.selectors.productMediaWrapper+":not(."+this.classes.hide+")",this.$container);e.trigger("xrLaunch")}.bind(this))},initProductVideo:function(){var e=this.settings.sectionId;$(this.selectors.productMediaTypeVideo,this.$container).each(function(){var s=$(this);vela.ProductVideo.init(s,e)})},trapCarouselFocus:function(e,s){e&&(e.find(".slick-slide:not(.slick-active)").find(this.focusableElements).attr("tabindex",s?"0":"-1"),e.find(".slick-active").find(this.focusableElements).attr("tabindex","0"))},updateCarouselDotsA11y:function(e){var s=$(this.selectors.slickDots).find("a");s.removeAttr("aria-current").eq(e).attr("aria-current","true")},translateCarouselDots:function(e,s,i){if(!(e<=i.max)){var r=0,t=(e-i.max)*i.width;s>=i.max-1&&(r=(s+2-i.max)*i.width,r=t<r?t:r),$(this.selectors.slickDots).find("ul").css("transform","translateX(-"+r+"px)")}},triggerMediaChangeEvent:function(e){var s=$(this.selectors.productMediaWrapper,this.$container);s.trigger("mediaHidden");var i=$(this.selectors.productMediaWrapper,this.$container).filter('[data-media-id="'+e+'"]');i.trigger("mediaVisible")},showVariantMedia:function(e){var s=e.variant,i=this.settings.sectionId+"-"+s.featured_media.id,r=$(this.selectors.productMediaWrapper+'[data-media-id="'+i+'"]');this.triggerMediaChangeEvent(i);var t;if(!vela.variables.isMobile&&this.isStackedLayout){if(t=r.closest(".slick-slide").index(),t!==0||vela.variables.productPageLoad)if(vela.variables.productPageSticky)$("html, body").animate({scrollTop:r.offset().top},250);else{var u=$(document).scrollTop();r.closest($(this.selectors.productMediaGroupItem,this.$container)).prependTo($(this.selectors.productMediaGroup,this.$container)),$(document).scrollTop(u)}}else{if(t=r.closest(".slick-slide").data("slick-index"),_.isUndefined(t))return;(t!==0||vela.variables.productPageLoad)&&$(this.selectors.productMediaGroup,this.$container).slick("slickGoTo",t)}vela.variables.productPageLoad||(vela.variables.productPageLoad=!0)},setFeaturedMedia:function(){var e=$(this.selectors.productMediaGroup,this.$container).find(".slick-slide.slick-current.slick-active "+this.selectors.productMediaWrapper).attr("data-media-id");this.triggerMediaChangeEvent(e)},createMediaCarousel:function(){if(!($(this.selectors.productMediaGroupItem).length<2||!$(this.selectors.productMediaGroup,this.$container)||this.isCarouselActive)){this.isCarouselActive=!0;var e={max:9,width:20},s=!1;$(this.selectors.productMediaGroupItem,this.$container).on("focusin",function(){s||(this.trapCarouselFocus($(this.selectors.productMediaGroup)),s=!0)}.bind(this)),$(this.selectors.productMediaGroup,this.$container).slick(this.slickMediaSettings).on("beforeChange",function(i,r,t,u){this.updateCarouselDotsA11y(u),this.translateCarouselDots(r.slideCount,u,e)}.bind(this)).on("afterChange",function(i,r){this.trapCarouselFocus(r.$slider),this.setFeaturedMedia()}.bind(this))}},destroyMediaCarousel:function(){!$(this.selectors.productMediaGroup,this.$container).length||!this.isCarouselActive||(this.trapCarouselFocus($(this.selectors.productMediaGroup,this.$container),!0),$(this.selectors.productMediaGroup,this.$container).slick("unslick"),this.isCarouselActive=!1)},createThumbnailCarousel:function(){$(this.selectors.productMediaGroupItem).length<2||!$(this.selectors.productMediaGroup,this.$container)||$(this.selectors.productThumbnails,this.$container).slick(this.slickThumbsSettings)},productMediaZoom:function(){!$(this.selectors.productImageZoom,this.$container).length||vela.variables.isMobile||$(this.selectors.productImageZoom,this.$container).magnificPopup({type:"image",mainClass:"mfp-fade",closeOnBgClick:!0,closeBtnInside:!1,closeOnContentClick:!0,tClose:vela.strings.zoomClose,removalDelay:500,gallery:{enabled:!0,navigateByImgClick:!1,arrowMarkup:'<button title="%title%" type="button" class="mfp-arrow mfp-arrow-%dir%"><span class="mfp-chevron mfp-chevron-%dir%"></span></button>',tPrev:vela.strings.zoomPrev,tNext:vela.strings.zoomNext}})},getBaseUnit:function(e){return e.unit_price_measurement.reference_value===1?e.unit_price_measurement.reference_unit:e.unit_price_measurement.reference_value+e.unit_price_measurement.reference_unit},productPage:function(e){var s=vela.strings.moneyFormat,i=e.variant,r=vela.strings,t={addToCart:".btn--add-to-cart",addToCartText:".btn--add-to-cart .btn__text",quantityElements:".js-quantity-selector",shopifyPaymentButton:".shopify-payment-button",priceContainer:"[data-price-container]",productPrice:".js-product-price",priceA11y:".js-product-price-a11y",comparePrice:".js-product-compare-price",comparePriceA11y:".js-product-compare-price-a11y",comparePriceWrapper:".product-single__price--wrapper",productAvailable:".js-product-avaiable",productAvailableText:".js-product-avaiable-text",unitPrice:"[data-unit-price]",unitPriceBaseUnit:"[data-unit-price-base-unit]",SKU:".js-variant-sku"};if(i){if($(t.priceContainer,this.$container).removeClass(this.classes.hide),$(t.productAvailable,this.$container).removeClass(this.classes.hide),$(t.productPrice,this.$container).attr("aria-hidden","false"),$(t.priceA11y,this.$container).attr("aria-hidden","false"),i.available?($(t.addToCart,this.$container).removeClass("disabled").prop("disabled",!1),$(t.addToCartText,this.$container).html(r.addToCart),$(t.productAvailableText).removeClass(this.classes.productInventoryOutStock).addClass(this.classes.productInventoryInStock).html(vela.strings.inStock),$(t.quantityElements,this.$container).removeClass(this.classes.hide),$(t.shopifyPaymentButton,this.$container).removeClass(this.classes.hide)):($(t.addToCart,this.$container).addClass("disabled").prop("disabled",!0),$(t.addToCartText,this.$container).html(r.soldOut),$(t.productAvailableText).removeClass(this.classes.productInventoryInStock).addClass(this.classes.productInventoryOutStock).html(vela.strings.outStock),$(t.quantityElements,this.$container).addClass(this.classes.hide),$(t.shopifyPaymentButton,this.$container).addClass(this.classes.hide)),$(t.productPrice,this.$container).html(vela.Currency.formatMoney(i.price,s)).removeClass(this.classes.hide),i.compare_at_price>i.price?($(t.comparePrice,this.$container).html(vela.Currency.formatMoney(i.compare_at_price,s)),$(t.comparePriceWrapper,this.$container).removeClass(this.classes.hide),$(t.productPrice,this.$container).addClass("on-sale"),$(t.comparePriceWrapper,this.$container).attr("aria-hidden","false"),$(t.comparePriceA11y,this.$container).attr("aria-hidden","false")):($(t.comparePriceWrapper,this.$container).addClass(this.classes.hide).attr("aria-hidden","true"),$(t.productPrice,this.$container).removeClass("on-sale"),$(t.comparePrice,this.$container).html(""),$(t.comparePriceA11y,this.$container).attr("aria-hidden","true")),i.unit_price){var u=$(t.unitPrice,this.$container),c=$(t.unitPriceBaseUnit,this.$container);u.html(vela.Currency.formatMoney(i.unit_price,s)),c.html(this.getBaseUnit(i)),$(t.priceContainer,this.$container).addClass(this.classes.priceContainerUnitAvailable)}$(t.SKU).html(i.sku!=""?i.sku:"N/A"),vela.settings.currencies&&Currency.convertAll(vela.strings.currency,Currency.cookie.read())}else $(t.addToCart,this.$container).addClass("disabled").prop("disabled",!0),$(t.addToCartText,this.$container).html(r.unavailable),$(t.quantityElements,this.$container).addClass(this.classes.hide),$(t.shopifyPaymentButton,this.$container).addClass(this.classes.hide),$(t.priceContainer,this.$container).addClass(this.classes.hide),$(t.productAvailable,this.$container).addClass(this.classes.hide),$(t.productPrice,this.$container).attr("aria-hidden","true"),$(t.priceA11y,this.$container).attr("aria-hidden","true"),$(t.comparePriceWrapper,this.$container).attr("aria-hidden","true"),$(t.comparePriceA11y,this.$container).attr("aria-hidden","true")},onUnload:function(){this.$container.off(this.settings.namespace),vela.ProductModel.removeSectionModels(this.settings.sectionId),vela.ProductVideo.removeSectionVideos(this.settings.sectionId),this.isStackedLayout&&this.destroyMediaCarousel()}}),o}(),$(document).ready(function(){var o=new vela.Sections;o.register("product-template",vela.Product)});
//# sourceMappingURL=/s/files/1/0012/5334/3284/t/20/assets/vela-product.js.map?v=50154717887115870341672394802
