// ----------------- Main -------------- //
// ----------------- Main -------------- //


function Main() {
	this.scrollTop = 0;
	this.inViewElments = document.querySelectorAll('.animateInView');
	this.inViewTopPosArray = [];
	this.mainMenu = document.querySelectorAll('.main-menu');

	this.init = function () {
		var self = this;


		//mobile menu
		document.querySelector('#mobile-drop .icon-close').onclick = function () {
			self.mobileMenuToggle('close');
		};
		Array.prototype.map.call(document.querySelectorAll('.mobile-menu-btn'), function (btn) {
			btn.onclick = function () {
				self.mobileMenuToggle('open');
			};
		});
		Array.prototype.map.call(document.querySelectorAll('#mobile-drop a'), function (link) {
			link.onclick = function () {
				self.mobileMenuToggle('close');
			};
		});

		//document scroll
		this.scrollHandler();
		window.addEventListener("scroll", function () {
			requestAnimationFrame(self.scrollHandler.bind(self));
		}, false);


		//window resize
		var resizeTimer;
		window.addEventListener("resize", function () {
			clearTimeout(resizeTimer);
			resizeTimer = setTimeout(function () {
				self.onResize()
			}.bind(self), 250);
		}, false);


		//btns mousedown
		Array.prototype.map.call(document.querySelectorAll('.btn'), function (btn) {
			btn.addEventListener("mousedown", function () {
				btn.classList.add("pressed");
			}, false);
			btn.addEventListener("mouseup", function () {
				btn.classList.remove("pressed");
			}, false);
		});


		this.inView();
		//and again after assets are fully loaded and when re-focused on tab
		window.addEventListener("load", this.inView.bind(this), false);
		document.addEventListener("visibilitychange", function () {
			if (document.visibilityState === 'visible') self.inView.bind(self);
		}, false);

	};


	//scroll handler
	this.scrollHandler = function () {
		this.scrollTop = (window.pageYOffset || document.documentElement.scrollTop) - (document.documentElement.clientTop || 0);

		var self = this;
		Array.prototype.map.call(this.mainMenu, function (menu) {
			menu.classList.toggle("scrolled", self.scrollTop > 300);
		});

		this.inViewIsActive();
	};

	//inView position top handler
	this.inView = function () {
		if (!this.inViewElments || this.inViewElments.length === 0) return;

		//clear array:
		this.inViewTopPosArray = [];

		var self = this;
		Array.prototype.map.call(this.inViewElments, function (elm) {
			self.inViewTopPosArray.push(self.getCoords(elm));
		});
	};

	this.getCoords = function (elem) {
		var boxTop = Math.round(elem.getBoundingClientRect().top);

		var body = document.body;
		var docEl = document.documentElement;

		var clientTop = docEl.clientTop || body.clientTop || 0;

		return boxTop + this.scrollTop - clientTop - window.innerHeight;
	};

	//inView scroll class toggle handler
	this.inViewIsActive = function () {
		if (!this.inViewElments || this.inViewElments.length === 0) return;
		var offset = 150;

		var self = this;
		Array.prototype.map.call(this.inViewElments, function (elm, index) {
			elm.classList.toggle("active", self.scrollTop > (self.inViewTopPosArray[index] + offset));
		});
	};

	//mobile menu open/close
	this.mobileMenuToggle = function (action) {
		var menu = document.getElementById('mobile-drop');

		if (action === 'close') {
			menu.classList.remove("active");
		} else {
			menu.classList.add("active");
		}
	};

	//window resize
	this.onResize = function () {
		//console.log('resize');
		this.inView();
	};
}

function HomePage() {
	this.init = function () {
		var self = this;
		document.querySelector('.video-screen').onclick = function () {
			self.handleVideo('play');
		};
		document.querySelector('.btn.video').onclick = function () {
			self.handleVideo('play');
		};
		document.querySelector('#video .close').onclick = function () {
			self.handleVideo('close');
		};
		document.querySelector('#video .bg').onclick = function () {
			self.handleVideo('close');
		};
	};

	//video play
	this.handleVideo = function (action) {
		var vid = document.getElementById('video');

		if (action === 'play') {
			document.body.style.overflowY = 'hidden';
			vid.style.display = 'block';
			vid.querySelector('iframe').setAttribute('src', 'https://www.youtube.com/embed/SSD_jHWwNUU?rel=0&amp;controls=1&amp;showinfo=0&amp;autoplay=1');
		} else {
			document.body.style.overflowY = 'auto';
			vid.style.display = 'none';
			vid.querySelector('iframe').setAttribute('src', '');
		}
	};
}


// ----------------- Coding -------------- //
// ----------------- Coding -------------- //
function Coding() {

	this.init = function () {
		var num = 0;
		var limit = 1;

		var self = this;
		this.loop(num);
		setInterval(function () {
			if (window.pageYOffset > window.innerHeight) return;

			num += 1;
			self.loop(num);
			if (num === limit) {
				num = -1;
			}
		}.bind(this), 7000);
	};

	this.loop = function (num) {
		this.splitMethod(num);
		this.loadResults(num);
	};

	this.splitMethod = function (num) {
		var ideMethods = document.querySelectorAll('#ide-method li');
		document.getElementById('codota-loader').style.display = 'block';

		Array.prototype.map.call(ideMethods, function (method) {
			method.style.display = 'none';
		});

		var txt = ideMethods[num].textContent;
		txt = txt.replace(/\S/g, '<span>$&</span>');
		ideMethods[num].innerHTML = txt;
		ideMethods[num].style.display = 'block';
	};

	this.loadResults = function (num) {
		var methods = document.querySelectorAll('#coding .method li');
		var predictions = document.querySelectorAll('#coding .predictions li');
		var snippets = document.querySelectorAll('#coding .snippets li');
		setTimeout(function () {
			document.getElementById('codota-loader').style.display = 'none';
		}, 1000);

		Array.prototype.map.call(methods, function (method) {
			method.style.display = 'none';
		});
		methods[num].style.display = 'block';

		Array.prototype.map.call(predictions, function (prediction) {
			prediction.style.display = 'none';
		});
		predictions[num].style.display = 'block';

		Array.prototype.map.call(snippets, function (snippet) {
			snippet.style.display = 'none';
		});
		snippets[num].style.display = 'block';
	};

}


function init() {
	var main = new Main();
	main.init();

	if (document.getElementById('coding')) {
		var coding = new Coding();
		coding.init();
	}
}


//wait for DOm ready event
if (document.readyState === 'complete') {
	init();
} else {
	document.addEventListener('DOMContentLoaded', function () {
		init();
	});
}







