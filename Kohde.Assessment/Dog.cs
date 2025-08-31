namespace Kohde.Assessment
{
    //The Dog is inherently a Pet and will always be able to do what a Pet can do
    //The Dog class allows us to properties and methods specific to dogs while still being able to do what a Pet can do
    public class Dog : Pet, IPet
    {
        public Dog(string name, int age, string food) : base(name, age, food)
        {
        }
        public Dog() : base()
        {
        }
    }
}