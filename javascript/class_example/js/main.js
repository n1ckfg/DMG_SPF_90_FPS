"use strict";

var dots = [];
var numDots = 50;

function setup() {
	createCanvas(960, 540);
	for (var i=0; i<numDots; i++) {
		dots.push(new Dot(random(width), random(height)));
	}
}

function draw() {
	background(0);
	for (var i=0; i<dots.length; i++) {
		dots[i].run();
	}
}

class Dot {

	constructor(x, y) {
		this.p = createVector(x, y);
		this.s = random(10, 30);
		this.colorOrig = color(127);
		this.colorHover = color(200);
		this.colorClick = color(0, 127, 255);
		this.colorNow = this.colorOrig;
		this.hovered = false;
		this.clicked = false;
	}

	draw() {
		fill(this.colorNow);
		ellipse(this.p.x, this.p.y, this.s, this.s);
	}

	update() {
		this.hovered = false;
		this.clicked = false;

		if (this.hitDetect(mouseX, mouseY, 5, 5, this.p.x, this.p.y, this.s, this.s)) {
			this.hovered = true;
			if (mouseIsPressed) this.clicked = true;
		}

		if (this.hovered && !this.clicked) {
			this.colorNow = this.colorHover;
		} else if (this.hovered && this.clicked) {
			this.colorNow = this.colorClick;
		} else {
			this.colorNow = this.colorOrig;
		}
	}

	run() {
		this.update();
		this.draw();
	}

	hitDetect(x1, y1, w1, h1, x2, y2, w2, h2) {
	    w1 /= 2;
	    h1 /= 2;
	    w2 /= 2;
	    h2 /= 2; 
	    if(x1 + w1 >= x2 - w2 && x1 - w1 <= x2 + w2 && y1 + h1 >= y2 - h2 && y1 - h1 <= y2 + h2) {
	        return true;
	    } else {
	        return false;
	    }
	}

}


