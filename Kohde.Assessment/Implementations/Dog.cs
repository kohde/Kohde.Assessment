using System;

namespace Kohde.Assessment.Implementations
{
    public class Dog : Mammal
    {
        #region Private Properties

        private string _name;
        private int _age;
        private string _food;

        #endregion

        #region Properties

        public string Food
        {
            get => _food;
            set
            {
                _food = value;
            }
        }

        public override string Name
        {
            get => _name;
            set
            {
                _name = value;
            }
        }

        public override int Age
        {
            get => _age;
            set
            {
                _age = value;
            }
        }

        #endregion

        #region Methods

        public override string GetDetails()
        {
            return "Name: " + _name + " Age: " + _age.ToString();
        }

        public void ShowDetails()
        {
            var details = GetDetails();

            Console.WriteLine(details);
        }

        #endregion
    }
}