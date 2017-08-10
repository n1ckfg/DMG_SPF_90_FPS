class Dot {
  
  PVector p;
  float s;
  color colorOrig, colorHover, colorClick, colorNow;
  boolean hovered, clicked;
  
  Dot(float x, float y) {
    p = new PVector(x, y);
    s = random(10, 30);
    colorOrig = color(127);
    colorHover = color(200);
    colorClick = color(0, 127, 255);
    colorNow = colorOrig;
    hovered = false;
    clicked = false;
  }

  void draw() {
    fill(colorNow);
    ellipse(p.x, p.y, s, s);
  }

  void update() {
    hovered = false;
    clicked = false;

    if (hitDetect(mouseX, mouseY, 5, 5, p.x, p.y, s, s)) {
      hovered = true;
      if (mousePressed) clicked = true;
    }

    if (hovered && !clicked) {
      colorNow = colorHover;
    } else if (hovered && clicked) {
      colorNow = colorClick;
    } else {
      colorNow = colorOrig;
    }
  }

  void run() {
    update();
    draw();
  }

  boolean hitDetect(float x1, float y1, float w1, float h1, float x2, float y2, float w2, float h2) {
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