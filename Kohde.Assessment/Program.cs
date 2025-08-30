using Kohde.Assessment.Container;
using System;
using System.Collections.Generic;
using System.Linq;

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
            //Human human = new Human();
            //human.Name = "John";
            //human.Age = 35;
            //human.Gender = "M";
            //Console.WriteLine(human.GetDetails());

            //Dog dog = new Dog();
            //dog.Name = "Walter";
            //dog.Age = 7;
            //dog.Food = "Epol";
            //Console.WriteLine(dog.GetDetails());

            //Cat cat = new Cat();
            //cat.Name = "Snowball";
            //cat.Age = 35;
            //cat.Food = "Whiskers";
            //Console.WriteLine(cat.GetDetails());

            // we're keeping explicit variables (human, dog, cat) so they can be reused 
            // in later assessments (e.g. Assessment F).
            // Also add them into a List<Organism> to demonstrate polymorphism in Assessment A.
            var human = new Human { Name = "John", Age = 35, Gender = "M" };
            var dog = new Dog { Name = "Walter", Age = 7, Food = "Epol" };
            var cat = new Cat { Name = "Snowball", Age = 3, Food = "Whiskers" };

            // Instead of handling each type individually, 
            // we now rely on polymorphism via the abstract base class "Organism"
            // This makes the code more maintainable and extensible
            var organisms = new List<Organism> { human, dog, cat };

            //Polymorphic call: GetDetails() works for all Organisms types 
            foreach (var organism in organisms)
            {
                Console.WriteLine(organism.GetDetails());
            }

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
            //try
            //{
            //    Dog bulldog = null;
            //    var disposeDog = (IDisposable) bulldog; //invalid cast, bulldog is null
            //    disposeDog.Dispose(); //calling Dispose() on null
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}

            try
            {
                Dog bulldog = null;

                // Use safe-cast with "as"
                // in this way, if Dog is not IDisposable OR bulldog is null, disposeDog will just be null
                var disposeDog = bulldog as IDisposable;

                // Check for null before calling Dispose
                if (disposeDog != null)
                {
                    disposeDog.Dispose();
                }
                else
                {
                    Console.WriteLine("bulldog is either null or not disposable.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
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
            //ShowSomeHumanInformation(human);
            //ShowSomeDogInformation(dog);
            //ShowSomeCatInformation(cat);

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
                //after fix: now the stack trace is not just pointing to here, but also to the original throw location
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
            //Original issue: "someLongDataString" was a normal string.
            //Each concatenation created a NEW string, leading to O(n^2) time.
            //With 500k iterations, this takes seconds or even minutes.
            //Solution: Use StringBuilder which is optimized for such operations.

            var sBuilder = new System.Text.StringBuilder();
            var someLongDataString = "";
            const int sLen = 30, loops = 500000; // YOU MAY NOT CHANGE THE NUMBER OF LOOPS IN ANY WAY !!
            var source = new string('X', sLen);

            // DO NOT CHANGE THE ACTUAL FOR LOOP IN ANY WAY !!
            // in other words, you may not change: for (INITIALIZATION; CONDITION; INCREMENT/DECREMENT)
            for (var i = 0; i < loops; i++)
            {
                // StringBuilder.Append is O(1)-constant time amortized.
                sBuilder.Append(source);
            }
        }

        #endregion

        #region Assessment C Method

        public static int GetFirstEvenValue(List<int> numbers)
        {
            // RETURN THE FIRST EVEN NUMBER IN THE SEQUENCE
            //var first = numbers.Where(x => x % 2 == 0).First();

            // By using the Where will load all even numbers into memory first
            // and then return the first one, which is inefficient.
            // Using FirstOrDefault stops as soon as the first match is found
            // and returns the default value (0) if no even number is present.

            return numbers.FirstOrDefault(x => x % 2 == 0);
        }

        public static string GetSingleStringValue(List<string> stringList)
        {
            // THE OUTPUT MUST RENDER THE FIRST ITEM THAT CONTAINS AN 'a' INSIDE OF IT
            //var first = stringList.Where(x => x.IndexOf("a") != -1).Single();

            // Using Single() expects exactly one match, which can throw exceptions if there are none or multiple.
            // Using SingleOrDefault ensures that exactly one element is returned
            // or null if there is no match. If multiple matches exist, an exception will be thrown.

            return stringList.SingleOrDefault(x => x.Contains("a"));
        }

        #endregion

        #region Assessment E Method

        public static DisposableObject DisposeSomeObject()
        {
            // IMPROVE THE FOLLOWING PIECE OF CODE
            // as well as the PerformSomeLongRunningOperation method
            //var disposableObject = new DisposableObject();
            //try
            //{
            //    disposableObject.PerformSomeLongRunningOperation();
            //    disposableObject.RaiseEvent("raised event");
            //}
            //finally
            //{
            //    //the issue here is that the method disposes the object inside finally meaning that the caller gets a useless object as it is already disposed
            //    disposableObject.Dispose();
            //}

            //return disposableObject;


            // rule in this is don’t dispose in the method if you intend to return the object, instead the caller should own disposal.
            var disposableObject = new DisposableObject();
            try
            {
                disposableObject.PerformSomeLongRunningOperation();
                disposableObject.RaiseEvent("raised event");
                disposableObject.Dispose(); // dispose before returning
                return disposableObject; // return a usable object
            }
            catch
            {
                // ensure disposal if something went wrong
                disposableObject.Dispose();
                throw;
            }
        }

        #endregion

        #region Assessment F Methods

        public static void ShowSomeHumanInformation(Human human)
        {
            Console.WriteLine("Name:" + human.Name + " Age: " + human.Age);
        }

        public static void ShowSomeDogInformation(Dog dog)
        {
            Console.WriteLine("Name:" + dog.Name + " Age: " + dog.Age);
        }

        public static void ShowSomeCatInformation(Cat cat)
        {
            Console.WriteLine("Name:" + cat.Name + " Age: " + cat.Age);
        }

        /// <summary>
        /// Since the above methods are almost identical, we can use a generic method
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="organism"></param>
        public static void ShowSomeMammalInformation<T>(T mammal) where T : Organism
        {
            Console.WriteLine("Name:" + mammal.Name + " Age: " + mammal.Age);
        }

        /// <summary>
        /// Generic method ensures we can create an instance if obj is null
        /// Uses reflection to instantiate if needed
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="selector"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static TResult GenericTester<T, TResult>(Func<T, TResult> selector, T obj) where T : class, new()
        {
            // If obj is null, create an instance dynamically (reflection not strictly needed because of new())
            if (obj == null)
            {
                obj = Activator.CreateInstance<T>();
            }

            return selector(obj);
        }

        #endregion

        #region Assessment G Methods

        public static void CatchAndRethrowExplicitly()
        {
            try
            {
                ThrowException();
            }
            catch (ArithmeticException e)
            {
                //throw e; // this is bad practice as the original stack trace is lost (you only see form throw e and not from ThrowException() where it started)
                throw; // this preserves the original stack trace
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
            //throw new NotImplementedException(); // ATT: REMOVE THIS LINE

            // Use reflection to get the current type (Program) and find the method by name
            var type = typeof(Program);

            // Get MethodInfo for DisplaySomeStuff
            var method = type.GetMethod("DisplaySomeStuff", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Public);

            if (method == null)
                throw new Exception("Method DisplaySomeStuff not found via reflection.");

            // Make generic method concrete
            var genericMethod = method.MakeGenericMethod(typeof(string));

            // Invoke with a dummy argument (any string)
            var result = genericMethod.Invoke(null, new object[] { "Hello Reflection" }) as string;

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
            Ioc.Container.Register<IDevice, SamsungDevice>();          // IDevice resolves to SamsungDevice
            Ioc.Container.Register<IDeviceProcessor, DeviceProcessor>(); // IDeviceProcessor resolves to DeviceProcessor

            // 2. resolve the IDeviceProcessor
            var deviceProcessor = Ioc.Container.Resolve<IDeviceProcessor>();
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
