namespace Kohde.Assessment {
    public class Dog : Mammal {
        public string Food { get; set; }
        public string GetDetails() {
            return base.ToString();
        }
    }
}