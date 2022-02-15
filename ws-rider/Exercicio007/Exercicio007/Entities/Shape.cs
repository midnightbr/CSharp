using Exercicio007.Entities.Enums;

namespace Exercicio007.Entities {
    abstract class Shape {
        public Color Color { get; set; }

        protected Shape(Color color) {
            Color = color;
        }

        public abstract double Area();
    }
}
