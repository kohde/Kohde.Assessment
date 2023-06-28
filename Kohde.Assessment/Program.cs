using Kohde.Assessment.Container;
using Kohde.Assessment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Policy;
using System.Text;
using System.Xml.Linq;

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

            // Darren Potts: The instantiation can be simplified from setting each
            // property individually 
            Human human = new Human()
            {
                Name = "John",
                Age = 35,
                Gender = "M"
            };

            // Darren Potts: ToString can be overridden instead of creating a new
            // method
            Console.WriteLine(human.ToString());

            Dog dog = new Dog
            {
                Name = "Walter",
                Age = 7,
                Food = "Epol"
            };
            Console.WriteLine(dog.ToString());

            Cat cat = new Cat
            {
                Name = "Snowball",
                Age = 35,
                Food = "Whiskers"
            };
            Console.WriteLine(cat.ToString());

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
            Dog bulldog;
            try
            {
                // Darren Potts: As far as I understand, an object only needs to be disposed
                // if the class deals with unmanaged resources or has managed resources within
                // the class which require disposing, which this class does not
                // and so does not require to be Disposed. The Garbage Collector will handle 
                // clean up.
                // if need be the try catch can implement a finally to clear up the Dog object
                // if instantiated however the garbage collector will take care of it so it is 
                // not neccessary
                bulldog = new Dog();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                bulldog = null;
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

            // Darren Potts: Replaced methods with generic method
            ShowSomeMammalInformation(human);
            ShowSomeMammalInformation(dog);
            ShowSomeMammalInformation(cat);


            // # SECTION B #
            // BY MAKING USE OF REFLECTION (amongst other things):
            //      => create a method so that the below code snippet will work:
            //      => place a constraint on the new method, so that a new instance will be created when 'dog' is null
            //      => thus is dog = null, the method should create a new instance an not fail

            // UNCOMMENT THE FOLLOWING PIECE OF CODE - IT WILL CAUSE A COMPILER ERROR - BECAUSE YOU HAVE TO CREATE THE METHOD

            Dog dog1 = null;

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

            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }

        #region Assessment B Method

        public static void PerformanceTest()
        {
            // Darren Potts: Use StringBuilder instead, String concatenation creates a new object 
            // each time
            StringBuilder someLongDataString = new StringBuilder();
            const int sLen = 30, loops = 500000; // YOU MAY NOT CHANGE THE NUMBER OF LOOPS IN ANY WAY !!
            var source = new string('X', sLen);

            // DO NOT CHANGE THE ACTUAL FOR LOOP IN ANY WAY !!
            // in other words, you may not change: for (INITIALIZATION; CONDITION; INCREMENT/DECREMENT)
            for (var i = 0; i < loops; i++)
            {
                // Darren Potts: StringBuilder requires the value to be appended instead of the += concatenation
                someLongDataString.Append(source);
            }
        }

        #endregion

        #region Assessment C Method

        public static int GetFirstEvenValue(List<int> numbers)
        {
            // RETURN THE FIRST EVEN NUMBER IN THE SEQUENCE

            // Darren Potts: Made use of FirstOrDefault in the case where the list does 
            // not contain an even number, an exception won't be thrown but will return null 
            // in which case error handling can be done
            var first = numbers.FirstOrDefault(x => x % 2 == 0);
            return first;
        }

        public static string GetSingleStringValue(List<string> stringList)
        {
            // THE OUTPUT MUST RENDER THE FIRST ITEM THAT CONTAINS AN 'a' INSIDE OF IT

            // Darren Potts: Where the test wanted SingleOrDefault to be used
            // in this case there are more than 1 elements that contain the value 'a' 
            // which causes an exception by use of SingleOrDefault.
            // Is there a way it can be accomplished using SingleOrDefault ? 
            var first = stringList.FirstOrDefault(x => x.Contains("a"));
            return first;
        }

        #endregion

        #region Assessment E Method

        public static DisposableObject DisposeSomeObject()
        {
            // IMPROVE THE FOLLOWING PIECE OF CODE
            // as well as the PerformSomeLongRunningOperation method

            // Darren Potts: making use of 'using'statement ensures that a disposable instance is
            // disposed even if an exception occurs within the block of the using statement
            // and is a bit more concise than ty, catch 
            DisposableObject disposableObject = new DisposableObject();

            using (disposableObject)
            {
                disposableObject.PerformSomeLongRunningOperation();
                disposableObject.RaiseEvent("raised event");
                return disposableObject;
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

        // Darren Potts: Created a generic method to display information for all the mammal
        // classes that is constrained by the BaseClass
        public static void ShowSomeMammalInformation<T>(T mammal) where T : BaseClass
        {
            Console.WriteLine($"Name: {mammal.Name} Age: {mammal.Age}");
        }

        // Darren Potts: This was my first attempt, however it does not follow test specifications
        // it does run and return
        public static T GenericTester<T, TBase>(Func<dynamic, T> func, TBase mammal) where TBase : BaseClass, new ()
        {
            if (mammal is null)
                mammal = new TBase();

            return func.Invoke(mammal);
        }

        // Darren Potts: This was my next few attempt, but unfortunately I was unable to figure this one out
        //public static T GenericTester<T, TBase>(Func<TBase, T> func, TBase mammal) where TBase : BaseClass, new()
        //{
            //if (mammal is null)
            //    mammal = new TBase();

            //MethodInfo methodInfo = func.Method;
            //object targetObject = func.Target;

            //MethodInfo generic = methodInfo;
            //var parameters = new object[] { methodInfo, mammal };
            //var result = generic.Invoke(targetObject, parameters);
            //return (T)result;

            //MethodInfo methodInfo = func.Method;
            //object targetObject = func.Target;

            //var result = (T)methodInfo.Invoke(targetObject, new object[]
            //{
            //     func, mammal
            //});

            //T result = (T)methodInfo.Invoke(targetObject, new object[] { mammal });

            //return result;

            //string Func1(Dog x) => x.GetDetails();
            //Type[] typeArgs1 = { typeof(Dog), typeof(string) };
            //var generic1 = method.MakeGenericMethod(typeArgs1);
            //var resultA = generic1.Invoke(typeof(Program), new object[]
            //{
            //    (Func<Dog, string>) Func1, dog
            //});
        //}
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
                // Darren Potts: an exception can be thrown in 2 ways using the throw keyword which
                // preserves the original stack trace so that it can be viewed when the exception is caught
                // and handled later.

                // or by throwing the exception variable again however the stack trace is reset to start
                // at this line of code the stack trace that was originally in the exception is lost.
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

            MethodInfo method = typeof(Program).GetMethod(nameof(Program.DisplaySomeStuff));
            MethodInfo generic = method.MakeGenericMethod(typeof(string[]));
            var parameters = new object[] { new[] { "This is a string to display" } };
            var result = generic.Invoke(null, parameters);
            return (string)result;
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
            // TODO: ???

            // Darren Potts: Use the existing IoC container to register the interface with 
            // its corresponding concrete class
            Ioc.Container.Register<IDevice, SamsungDevice>();
            Ioc.Container.Register<IDeviceProcessor, DeviceProcessor>();

            // 2. resolve the IDeviceProcessor

            // Darren Potts: the relationship is registered to the container,
            // we can create the object by calling Resolve method.
            var deviceProcessor = Ioc.Container.Resolve(typeof(IDeviceProcessor)) as IDeviceProcessor;
            // call the GetDevicePrice method
            Console.WriteLine(deviceProcessor.GetDevicePrice());
        }

        #endregion

        #region Dungeon
        public static string SelectOnlyVowels(this IEnumerable<char> letterString)
        {
            const string vowels = "aeiou";

            string vowelsFound = "";
            foreach (char c in letterString)
            {
                if (vowels.Any(x => x == c))
                {
                   vowelsFound += c;
                }
            }
            return vowelsFound;
        }

        public static IEnumerable<T> CustomWhere<T>(this IEnumerable<T> source, Func<T, bool> filter)
        {
            foreach (var item in source)
            {
                if (filter(item))
                    yield return item;
            }
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
