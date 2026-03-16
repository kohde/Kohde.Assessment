using Kohde.Assessment.Container;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
            //CHANGE: Introduced a base class "Entity" to contain share properties and behavior.
            //Human, Cat and Dog inherit from this class and only implement properties specific to them
            //Added IEntity interface to define common contract for entities to implement consistently, enabling polymorphism 

            Human human = new Human();
            human.Name = "John";
            human.Age = 35;
            human.Gender = "M";
            Console.WriteLine(human.GetDetails());

            Dog dog = new Dog();
            dog.Name = "Walter";
            dog.Age = 7;
            dog.Food = "Epol";
            Console.WriteLine(dog.GetDetails());

            Cat cat = new Cat();
            cat.Name = "Snowball";
            cat.Age = 35;
            cat.Food = "Whiskers";
            Console.WriteLine(cat.GetDetails());

            #endregion

            #region Assessment B

            // you'll notice the following piece of code takes an
            // age to execute - CORRECT THIS
            // IT MUST EXECUTE IN UNDER A SECOND
            PerformanceTest();

            #endregion

            #region Assessment C

            // correct the following LINQ statement found in their respective methods
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
            try
            {
                //CHANGE: Prevent disposing a null instance o avoid runtime error
                // Use safe casting to avoid InvalidCastException if dog does not exist
                // Only call Dispose() if cast succeeds
                Dog bulldog = new Dog(); //can not displose a non existing instance/null <-
                var disposeDog = bulldog as IDisposable; //<- Prevent InvalidCastException if dog does not exist
                disposeDog?.Dispose(); //<- only execute if cast was successful
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

            ShowSomeMammalInformation(human);
            ShowSomeMammalInformation(dog);
            ShowSomeMammalInformation(cat);


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


            const string abc = "asduqwezxc";
            foreach (var vowel in abc.SelectOnlyVowels())
            {
                Console.WriteLine("{0}", vowel);
            }

            // < REQUIRED OUTPUT => a u e

            // > UNCOMMENT THE CODE BELOW AND CREATE A METHOD SO THAT THE FOLLOWING CODE WILL WORK
            // > DECLARE ALL THE METHODS WITHIN THE PROGRAM CLASS !!
            // > DO NOT ALTER THE EXISTING CODE


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
            #endregion
        }

        #region Assessment B Method
        //CHANGE: Improve perfomance by replacing repeated string concatenation with StringBuilder
        //Improves perfomance when building large strings in a loop since stringbuilder is mutable and does not create new instances in memory for each iteration
        public static void PerformanceTest()
        {
            var someLongDataString = "";
            const int sLen = 30, loops = 500000; // YOU MAY NOT CHANGE THE NUMBER OF LOOPS IN ANY WAY !!
            var source = new string('X', sLen);

            var builder = new StringBuilder(sLen * loops); //introduce stringbuilder because its mutable, can change <-

            // DO NOT CHANGE THE ACTUAL FOR LOOP IN ANY WAY !!
            // in other words, you may not change: for (INITIALIZATION; CONDITION; INCREMENT/DECREMENT)
            for (var i = 0; i < loops; i++) 
            {
                builder.Append(source);
            }
            someLongDataString = builder.ToString();
        }

        #endregion

        #region Assessment C Method
        //CHANGE: Use FirstOrDefault to find the first even number in the sequence
        //If no even number exists, return the default value instead of throwing an exception<-
        public static int GetFirstEvenValue(List<int> numbers)
        {
            // RETURN THE FIRST EVEN NUMBER IN THE SEQUENCE
            var first = numbers.FirstOrDefault(x => x % 2 == 0);
            return first;
        }
        //CHANGE: Use FirstOrDefault to find the first string containing the letter "a"
        //If no match of this nature is found, return null instead of throwing an error <-
        public static string GetSingleStringValue(List<string> stringList)
        {
            // THE OUTPUT MUST RENDER THE FIRST ITEM THAT CONTAINS AN 'a' INSIDE OF IT
            var first = stringList.FirstOrDefault(x => x.Contains("a"));
            return first;
        }

        #endregion

        #region Assessment E Method
        //CHANGE: Replaced Try/Finally with a using block to ensure Dispose is automatically called, simplifying the code
        public static DisposableObject DisposeSomeObject()
        {
            // IMPROVE THE FOLLOWING PIECE OF CODE
            // as well as the PerformSomeLongRunningOperation method

            using (var disposableObject = new DisposableObject())
            {
                disposableObject.PerformSomeLongRunningOperation();
                disposableObject.RaiseEvent("raised event");

                return disposableObject;
            }

        }

        #endregion

        #region Assessment F Methods
        //CHANGE: Replaced multiple methods that shared the same logic with a generic method to remove duplicated logic and enable code reuse
        public static void ShowSomeMammalInformation<T>(T mammal) where T : Entity //this has been created and has shared properties "Name" and "Age" which I notice are used here
        {
            Console.WriteLine("Name:" + mammal.Name + " Age: " + mammal.Age);
        }

        //CHANGE: Implemented a generic tester method that acepts a Func delegateImplement a Generic Tester method that accepts and function delegate 
        //If the provided object is null, allow creation using the generic "T : new" 
        //To ensure the function always gets a valid object
        public static TResult GenericTester<T, TResult>(Func<T, TResult> func, T obj) where T : new()
        {
            if (obj == null)
            {
                obj = new T();
            }

            return func(obj);
        }

        #endregion

        #region Assessment G Methods
        //CHANGE: Replaced "throw e" with "throw" to utilize rethrow the same exception as "ThrowException" method, thus we know the exact error that occured
        //Its like passing error back creating a new one
        public static void CatchAndRethrowExplicitly()
        {
            try
            {
                ThrowException();
            }
            catch (ArithmeticException e)
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
        //CHANGE: Used reflection to find and call the "DisplaySomeStuff" method
        //This allows the call of the method dynamically without referencing it directly
        public static string CallMethodWithReflection()
        {
            // BY MAKING USE OF ONLY REFLECTION
            // CALL THE FOLLOWING METHOD: DisplaySomeStuff [WHICH IN JUST BELOW THIS ONE]
            // AND RETURN THE STRING CONTENT

            Type program = typeof(Program);
            var method = program.GetMethod("DisplaySomeStuff");
            var genericMethod = method.MakeGenericMethod(typeof(string));
            var result = genericMethod.Invoke(null, new object[] { "Reflection" });

            return (string)result;
            // DO NOT CHANGE THE NAME, RETURN TYPE OR ANY IMPLEMENTATION OF THIS METHOD NOR THE BELOW METHOD
        }

        public static string DisplaySomeStuff<T>(T toDisplay) where T : class
        {
            return string.Format("Here it is: {0}", toDisplay);
        }

        #endregion

        #region
        //CHANGE: Method extracts vowels from a string but checking input and returning vowels as it finds them
        public static IEnumerable<char> SelectOnlyVowels(this IEnumerable<char> input)
        {
            var vowels = "aeiou";
            foreach (char c in input)
            {
                if (vowels.Contains(char.ToLower(c)))
                {
                    yield return c;
                }
            }
        }

        #endregion

        #region
        //CHANGE: Create filtering method similar to Linq "Where" to find and return items that match given conditions
        public static IEnumerable<T> CustomWhere<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            foreach (var item in source)
            {
                if (predicate(item))
                {
                    yield return item;
                }
            }
        }

        #endregion
        #region IoC / DI
        //CHANGE: Registered inrerfaces with their implementations in the container so that the IoC container knows which concrete classes to create when
        //they are requested. Resolve IDeviceProcessor so dependencies are handled automatically
        //Resolved IDeviceProcessor and used it to call Ge
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
            // TODO: ???
            var container = Ioc.Container;

            container.Register<IDevice, SamsungDevice>();
            container.Register<IDeviceProcessor, DeviceProcessor>();

            // 2. resolve the IDeviceProcessor
            var deviceProcessor = container.Resolve<IDeviceProcessor>();
            deviceProcessor.GetDevicePrice();
            // call the GetDevicePrice method
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
