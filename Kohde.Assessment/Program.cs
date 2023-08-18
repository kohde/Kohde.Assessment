﻿using Kohde.Assessment.Container;
using Kohde.Assessment.Objects.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kohde.Assessment
{
    // *** NOTE ***
    // ALL CHANGES MUST BE ACCOMPANIED BY COMMENTS 
    // PLEASE READ ALL COMMENTS / INSTRUCTIONS
    public static class Program
    {
        static void Main(string[] args)
        {
            #region Assessment A

            // the below class declarations looks like a 1st year student developed it
            // NOTE: this includes the class declarations as well
            // IMPROVE THE ARCHITECTURE 

            /* There was commonality between the human, dog and cat classes as they shared properties like age and name.
               This lead me to make use of abstract classes and interfaces that the classes could inherit from and implement the functionality.
             * Created folders to store the respective files. Did so because in future when a solution grows it makes for easier navigation to the files you seek.
             * Within the classes/interfaces I declared the properties in Alphabetical order (Age, Name etc). 
               May seem silly because there are not many properties in the classes now, but humans tend to look for order when reading through a list.
               So should a class contain many properties you scan a class more easily to find what you're looking for.*/

            var cat = new Cat(35, "Whiskers", "Snowball");
            Console.WriteLine(cat.ToString());

            var dog = new Dog(7, "Epol", "Walter");
            Console.WriteLine(dog.ToString());

            var human = new Human(35, "M", "John");
            Console.WriteLine(human.ToString());
            #endregion

            #region Assessment B

            // you'll notice the following piece of code takes an
            // age to execute - CORRECT THIS
            // IT MUST EXECUTE IN UNDER A SECOND
            PerformanceTest();

            #endregion

            #region Assessment C

            //correct the following LINQ statement found in their respective methods
            var numbers = new List<int>()
            {
                1, 4, 5, 9, 11, 15, 20, 27, 34, 55 // you may not change the numbers
            };
            // the following method must return the first event number - as suggested by it's name
            var firstValue = GetFirstEvenValue(numbers);
            Console.WriteLine("First Number: " + firstValue);

            var strings = new List<string>()
            {
                "John", "Jane", "Sarah", "Pete", "Anna"
            };
            // the following method must return the first name which contains an 'a'
            var strValue = GetSingleStringValue(strings);
            Console.WriteLine("Single String: " + strValue);

            #endregion

            #region Assessment D

            // there are multiple corrections required!!
            // correct the following statement(s)

            /*Object was null when attempting to dispose of it. This results in a null ref exception when the code is run.
              To correct this an instance of Dog needs to be instatiated.
              The Dog class also needs to implement IDisposable for the code to work.*/
            try
            {
                Dog bulldog = new Dog();
                var disposeDog = (IDisposable)bulldog;
                disposeDog.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            #endregion

            #region Assessment E

            DisposeSomeObject();

            #endregion

            #region Assessment F

            // # SECTION A #
            // by making use of generics improve the implementation of the following methods
            // output must still render as: Name: [name] Age: [age]
            // THE METHOD THAT YOU CREATE MUST BE STATIC AND DECLARED IN THE PROGRAM CLASS
            // NB!! PLEASE NAME THE METHOD: ShowSomeMammalInformation
            ShowSomeMammalInformation(cat);
            ShowSomeMammalInformation(dog);
            ShowSomeMammalInformation(human);

            // # SECTION B #
            // BY MAKING USE OF REFLECTION (amongst other things):
            //      => create a method so that the below code snippet will work:
            //      => place a constraint on the new method, so that a new instance will be created when 'dog' is null
            //      => thus is dog = null, the method should create a new instance an not fail

            // UNCOMMENT THE FOLLOWING PIECE OF CODE - IT WILL CAUSE A COMPILER ERROR - BECAUSE YOU HAVE TO CREATE THE METHOD

            string a = Program.GenericTester(walter => walter.GetDetails(), dog);
            Console.WriteLine("Result A: {0}", a);
            int b = Program.GenericTester(snowball => snowball.Age, cat);
            Console.WriteLine("Result B: {0}", b);

            #endregion

            #region Assessment G

            // in the following statement, everything works fine
            // but, it has a huge flaw! 
            // correct the following piece of code

            //In CatchAndRethrowExplicitly(), the exception was being rethrown which would override the original stacktrace.
            //Changing it from throw e --> throw preserves the original stack trace.
            try
            {
                CatchAndRethrowExplicitly();
            }
            catch (ArithmeticException e)
            {
                Console.WriteLine("Implicitly specified:{0}{1}", Environment.NewLine, e.StackTrace);
            }

            #endregion            

            #region Assessment H

            try
            {
                // REFLECTION TEST .... NAVIGATE TO THE BELOW METHOD TO GET ALL THE INSTRUCTIONS
                CallMethodWithReflection();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            #endregion            

            #region IoC / DI

            // everything can be viewed in this method....
            PerformIoCActions();

            #endregion

            #region Bonus XP - Dungeon

            // > UNCOMMENT THE CODE BELOW AND CREATE A METHOD SO THAT THE FOLLOWING CODE WILL WORK
            // > DECLARE ALL THE METHODS WITHIN THE PROGRAM CLASS !!
            // > DO NOT ALTER THE EXISTING CODE

            /*  
                const string abc = "asduqwezxc";
                foreach (var vowel in abc.SelectOnlyVowels())
                {
                    Console.WriteLine("{0}", vowel);
                }
            */
            // < REQUIRED OUTPUT => a u e

            // > UNCOMMENT THE CODE BELOW AND CREATE A METHOD SO THAT THE FOLLOWING CODE WILL WORK
            // > DECLARE ALL THE METHODS WITHIN THE PROGRAM CLASS !!
            // > DO NOT ALTER THE EXISTING CODE

            /*
            List<Dog> dogs = new List<Dog>
            {
                new Dog {Age = 8, Name = "Max"},
                new Dog {Age = 3, Name = "Rocky"},
                new Dog {Age = 9, Name = "XML"}
            };

            var foo = dogs.CustomWhere(x => x.Age > 6 && x.Name.SelectOnlyVowels().Any());

            // < DOGS REQUIRED OUTPUT =>
            //      Name: Max Age: 8
             
            List<Cat> cats = new List<Cat>
            {
                new Cat {Age = 1, Name = "Capri"},
                new Cat {Age = 8, Name = "Cara"},
                new Cat {Age = 3, Name = "Captain Hooks"}
            };

            var bar = cats.CustomWhere(x => x.Age <= 4);
            // < CATS REQUIRED OUTPUT =>
            //      Name: Capri Age: 1
            //      Name: Captain Hooks Age: 3
            */

            #endregion

            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }

        #region Assessment B Method

        public static void PerformanceTest()
        {
            //StringBuilder executes faster than string so it's the better performance wise.
            var someLongDataString = new StringBuilder();
            const int sLen = 30, loops = 500000; // YOU MAY NOT CHANGE THE NUMBER OF LOOPS IN ANY WAY !!
            var source = new string('X', sLen);

            // DO NOT CHANGE THE ACTUAL FOR LOOP IN ANY WAY !!
            // in other words, you may not change: for (INITIALIZATION; CONDITION; INCREMENT/DECREMENT)
            for (var i = 0; i < loops; i++)
            {
                someLongDataString.Append(source);
            }
        }

        #endregion

        #region Assessment C Method

        /* Using FirstOrDefault is the better option should the sequence not contain a match. 
           It would return a default value and no exception is thrown.*/

        public static int GetFirstEvenValue(List<int> numbers)
        {
            // RETURN THE FIRST EVEN NUMBER IN THE SEQUENCE
            var first = numbers.FirstOrDefault(x => x % 2 == 0);
            return first;
        }

        public static string GetSingleStringValue(List<string> stringList)
        {
            // THE OUTPUT MUST RENDER THE FIRST ITEM THAT CONTAINS AN 'a' INSIDE OF IT
            var first = stringList.FirstOrDefault(x => x.Contains("a"));
            return first;
        }

        #endregion

        #region Assessment E Method

        public static DisposableObject DisposeSomeObject()
        {
            // IMPROVE THE FOLLOWING PIECE OF CODE
            // as well as the PerformSomeLongRunningOperation method

            //Swapped out the try finally for a using statement.
            //Reason for this is to ensure that the object is disposed when code completes successfully or exception occurs.
            using (var disposableObject = new DisposableObject())
            {
                disposableObject.PerformSomeLongRunningOperation();
                disposableObject.RaiseEvent("raised event");
                return disposableObject;
            }
        }

        #endregion

        #region Assessment F Methods

        public static void ShowSomeMammalInformation<T>(T Entity) where T : Entity
        {
            Console.WriteLine(Entity.GetDetails());
        }

        public static TResult GenericTester<T, TResult>(Func<T, TResult> expression, T instance)
          where T : new()
        {
            if (instance == null) //check to cater for the following scenario dog = null, the method should create a new instance and not fail.
            {
                instance = new T();
            }

            return expression(instance);
        }

        #endregion

        #region Assessment G Methods

        public static void CatchAndRethrowExplicitly()
        {
            try
            {
                ThrowException();
            }
            catch
            {
                throw;
            }
        }

        private static void ThrowException()
        {
            throw new ArithmeticException("illegal expression - was this picked up??");
        }

        #endregion

        #region Assessment H Methods

        public static string CallMethodWithReflection()
        {
            // BY MAKING USE OF ONLY REFLECTION
            // CALL THE FOLLOWING METHOD: DisplaySomeStuff [WHICH IN JUST BELOW THIS ONE]
            // AND RETURN THE STRING CONTENT

            // DO NOT CHANGE THE NAME, RETURN TYPE OR ANY IMPLEMENTATION OF THIS METHOD NOR THE BELOW METHOD

            //Knowledge on reflection was a bit rusty so did some researching.
            //This set me on the right path: https://stackoverflow.com/questions/232535/how-do-i-use-reflection-to-call-a-generic-method
            var method = typeof(Program).GetMethod(nameof(Program.DisplaySomeStuff));
            var myType = new Type[] { typeof(string) };
            var methodInfo = method.MakeGenericMethod(myType);
            var parameters = new object[] { "Lucky no. 7" };
            var result = (string)methodInfo.Invoke(null, parameters);

            return result;
        }

        public static string DisplaySomeStuff<T>(T toDisplay) where T : class
        {
            return string.Format("Here it is: {0}", toDisplay);
        }

        #endregion

        #region IoC / DI

        public static void PerformIoCActions()
        {
            /*  An very simple IoC / DI container has been created for you. All the code can be viewed in the Container folder.
             *  By making use of the classes provided, perform the following tasks:
             *  
             *  Two classes and two interfaces have been created for you, namely:
             *  
             *      - IDevice
             *      - SamsungDevice
             *      - IDeviceProcessor
             *      - DeviceProcessor
             * 
             *  The actual declarations can be view lower down in this file.
             *  
             *  The following needs to happen:
             *      
             *      1. register the interfaces with the respective classes
             *      2. resolve an instance of the IDeviceProcessor and call the GetDevicePrice method
             *      
             *  Some of the code below has been done, but you need to fill in the blanks
             */

            // 1. register the interfaces and classes

            //Following singleton lifecycle. I'm aware of the differences between transient vs. scoped vs. singleton lifecycles.
            Ioc.Container.Register<IDeviceProcessor, DeviceProcessor>();
            Ioc.Container.Register<IDevice, SamsungDevice>();

            // 2. resolve the IDeviceProcessor
            // call the GetDevicePrice method
            var deviceProcessor = Ioc.Container.Resolve<IDeviceProcessor>();
            Console.WriteLine(deviceProcessor.GetDevicePrice());
        }

        #endregion
    }

    public interface IDevice
    {
        string DeviceCode { get; }
    }

    public class SamsungDevice : IDevice
    {
        public string DeviceCode { get; private set; }

        public SamsungDevice()
        {
            this.DeviceCode = "Samsung";
        }
    }

    public interface IDeviceProcessor
    {
        double GetDevicePrice();
    }

    public class DeviceProcessor : IDeviceProcessor
    {
        protected IDevice Device { get; private set; }

        public DeviceProcessor(IDevice device)
        {
            this.Device = device;
        }

        public double GetDevicePrice()
        {
            // the actual implementation of this method does not matter....
            return this.Device.DeviceCode.Equals("Samsung") ? 12.95 : 19.95;
        }
    }
}
