namespace Kohde.Assessment
{
    public class Human : INameAge
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }

        public Human(string name, int age, string gender)
        {
            Name = name;
            Age = age;
            Gender = gender;
        }

        public Human(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public Human() { }

        public string GetDetails()
        {
            return "Name: " + Name + " Age: " + Age;
        }
    }
}