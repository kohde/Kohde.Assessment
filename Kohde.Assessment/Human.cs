namespace Kohde.Assessment
{
    //A Human is a Mammal and will always be able to do what a Mammal can do
    public class Human : Mammal
    {
        public string Gender { get; set; }

        public Human(string name, int age, string gender) : base(name, age)
        {
            Gender = gender;
        }
        public Human() : base()
        {
        }
        public override string ToString()
        {
            return $"{base.ToString()}, {Gender}";
        }
    }
}