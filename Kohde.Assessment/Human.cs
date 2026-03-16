namespace Kohde.Assessment
{
    public class Human : Entity
    {
        public string Gender { get; set; }

        //public Human(string name, int age, string gender): base (name, age) 
        //{
        //    Gender = gender;
        //}

        public override string GetDetails()
        {
            return base.GetDetails() +  $" Gender: {Gender}" ;
        }

        public override string ToString()
        {
            return GetDetails();
        }
    }

}