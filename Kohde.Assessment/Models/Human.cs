namespace Kohde.Assessment
{

    /// <summary>
    /// Human specific class
    /// </summary>
    public class Human : PartyDetailsBase
    {
        public Human() { }

        public Human(string Name, int Age, string Gender) : base(Name: Name, Age: Age)
        {
            this.Gender = Gender;
        }


        public string Gender { get; set; }


        public override string ToString() => $"{Name}_{Age}_{Gender}";

    }
}