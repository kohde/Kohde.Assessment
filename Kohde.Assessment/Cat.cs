namespace Kohde.Assessment {
    public class Cat : Mammal {
        public string Food { get; set; }

        public string GetDetails() {
            return base.ToString();
        }
    }
}