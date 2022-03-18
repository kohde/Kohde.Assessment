using System;

namespace Kohde.Assessment.Implementations
{
    public class Human : Mammal
    {
        #region Private Properties

        private string _name;
        private int _age;
        private string _gender;

        #endregion

        #region Properties

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

        public string Gender
        {
            get => _gender;
            set
            {
                _gender = value;
            }
        }

        #endregion

        #region Methods

        public void ShowDetails()
        {
            var details = GetDetails();

            Console.WriteLine(details);
        }

        public override string GetDetails()
        {
            return "Name: " + _name + " Age: " + _age;
        }

        public override string ToString()
        {
            return base.ToString();
        }

        #endregion
    }
}