namespace Kohde.Assessment
{
    public class Human: Mammal
    {
        public string Gender { get; set; }

        public Human(string name, int age, string gender): base(name, age)
        {
            Gender = gender;
        }

        public Human() { }

        public override string ToString()
        {
            return GetDetails() + " Gender: " + Gender;
        }
    }
}