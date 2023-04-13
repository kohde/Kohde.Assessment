namespace Kohde.Assessment
{
    public class Human : Mammal, IGender
    {
        public Human() { }
        public Human(int age, string name, string gender) : base(age, name)
        {
            Gender = gender;
        }
        public string Gender { get; set; }
    
        public override string ToString()
        {
            return base.ToString();
        }
    }
}