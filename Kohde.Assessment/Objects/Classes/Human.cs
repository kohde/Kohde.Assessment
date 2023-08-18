namespace Kohde.Assessment.Objects.Classes
{
    public class Human : Entity
    {
        public string Gender { get; set; }

        public Human(int age, string gender, string name) : base(age, name)
        {
            Gender = gender;
        }

        public Human() { }

        public override string ToString()
        {
            return $"{base.GetDetails()} Gender: {Gender}";
        }
    }
}