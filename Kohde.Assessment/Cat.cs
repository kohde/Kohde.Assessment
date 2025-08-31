namespace Kohde.Assessment
{
    //The Cat is inherently a Pet and will awlas be able to do what a Pet can do
    //The Cat class allows us to properties and methods specific to cats while still being able to do what a Pet can do
    public class Cat: Pet, IPet
    {
        public Cat(string name, int age, string food): base(name, age, food)
        {
        }
        public Cat() : base()
        {
        }
    }
}