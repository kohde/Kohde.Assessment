namespace Kohde.Assessment
{
    public class Human : MammalBase
    {
        /*
         *bcodendaal notes:
         *Because Gender was no defined on all the classes my assumption is that we only want gender specified for Humans.
         *There might be a case to say that Gender is applicable to all Mammals and if that is the requirement I would move this property to the base class as well.
        */
        public Human() { }
        public Human(string gender, string name, int age)
        {
            Gender = gender;
            Name = name;
            Age = age;
        }
        public string Gender { get; set; }
    }
}