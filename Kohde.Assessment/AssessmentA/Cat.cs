﻿namespace Kohde.Assessment.AssessmentA
{
    public class Cat : Mammal
    {
        public string Food { get; set; }

        public override string GetDetails()
        {
            return "Name: " + Name + "Age: " + Age;
        }
    }
}