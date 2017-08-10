ArrayList<Dot> dots = new ArrayList<Dot>();
int numDots = 50;

void setup() {
  size(960, 540, P2D);
  for (int i=0; i<numDots; i++) {
    dots.add(new Dot(random(width), random(height)));
  }
}

void draw() {
  background(0);
  for (int i=0; i<dots.size(); i++) {
    dots.get(i).run();
  }
}