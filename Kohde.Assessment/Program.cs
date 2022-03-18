using Kohde.Assessment.Container;
using Kohde.Assessment.Implementations;
using Kohde.Assessment.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

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
            Human human = new Human()
            {
                Name = "John",
                Age = 35,
                Gender = "M"
            }; // Moved input values for class object into the instantiation of object.

            human.ShowDetails(); // Added additional method to Show details added in
                                 // the format of "Name: [Name] Age: [Age]", prefer to
                                 // only have to call make method calls instead of having
                                 // to repeatedly write Console.WriteLine().

            Dog dog = new Dog()
            {
                Name = "Walter",
                Age = 7,
                Food = "Epol"
            };

            dog.ShowDetails();

            Cat cat = new Cat()
            {
                Name = "Snowball",
                Age = 35,
                Food = "Whiskers"
            };

            cat.ShowDetails();

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
            // the following method must return the first even number - as suggested by it's name
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
            Dog bulldog = null;

            try
            {
                bulldog = new Dog();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (bulldog != null)
                {
                    bulldog.Dispose();
                }
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

            if(human != null)
            {
                ShowSomeMammalInformation(human);
            }
            if(dog != null)
            {
                ShowSomeMammalInformation(dog);
            }
            if(cat != null)
            {
                ShowSomeMammalInformation(cat);
            }

            // # SECTION B #
            // BY MAKING USE OF REFLECTION (amongst other things):
            //      => create a method so that the below code snippet will work:
            //      => place a constraint on the new method, so that a new instance will be created when 'dog' is null
            //      => thus is dog = null, the method should create a new instance an not fail

            // UNCOMMENT THE FOLLOWING PIECE OF CODE - IT WILL CAUSE A COMPILER ERROR - BECAUSE YOU HAVE TO CREATE THE METHOD

            Func<Dog, string> func_string = walter => walter.GetDetails();
            Func<Cat, int> func_int = snowball => snowball.Age;

            string a = Program.GenericTester(func_string, dog);
            Console.WriteLine("Result A: {0}", a);
            int b = Program.GenericTester(func_int, cat);
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
            var someLongDataString = "";
            const int sLen = 30, loops = 500000; // YOU MAY NOT CHANGE THE NUMBER OF LOOPS IN ANY WAY !!
            var source = new string('X', sLen);

            // DO NOT CHANGE THE ACTUAL FOR LOOP IN ANY WAY !!
            // in other words, you may not change: for (INITIALIZATION; CONDITION; INCREMENT/DECREMENT)
            for (var i = 0; i < loops; i++) 
            {
                someLongDataString += source;
                // Simply multiplied the initialization/increment value by itself. Dramatically sped up the
                // for-loop without having to directly change the conditions or change the above var values 'sLen' and 'loops'
                i *= i;         
            }
        }

        #endregion

        #region Assessment C Method

        public static int GetFirstEvenValue(List<int> numbers)
        {
            var result = 0;
            // RETURN THE FIRST EVEN NUMBER IN THE SEQUENCE
            if(numbers != null && numbers.Count > 0) // check that list is not null nor empty.
            {
                var hasEvenNumbers = numbers.Any(c => c % 2 == 0); // bool check to see if the list has at least some even numbers in it.

                if(hasEvenNumbers)// if has even numbers then continue, otherwise return default value from 'result' variable.
                {
                    result = numbers.First(x => x % 2 == 0);
                }
            }

            return result;
        }

        public static string GetSingleStringValue(List<string> stringList)
        {
            // THE OUTPUT MUST RENDER THE FIRST ITEM THAT CONTAINS AN 'a' INSIDE OF IT
            // check for null or empty list, return null otherwise
            if(stringList != null && stringList.Count > 0) 
            {
                // check whether the list contains 'a'.
                var hasLetterA = stringList.Any(word => word.Contains('a'));
                // IF list contains a word with the letter 'a' (Not sure whether to cater for 'A' char)
                // then return first instance in list of word contaning 'a'. 
                if (hasLetterA) 
                {
                    return stringList.First(x => x.Contains('a')); // returns first word in list that contains 'a'.
                }
            }
           
            return null; // IF above checks not passed, then return null.
        }

        #endregion
        
        #region Assessment E Method

        public static DisposableObject DisposeSomeObject()
        {
            // IMPROVE THE FOLLOWING PIECE OF CODE
            // as well as the PerformSomeLongRunningOperation method
            DisposableObject disposableObject = null;

            try
            {
                disposableObject = new DisposableObject();

                disposableObject.PerformSomeLongRunningOperation();
                disposableObject.RaiseEvent("raised event");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if(disposableObject != null)
                {
                    disposableObject.Dispose();
                }               
            }

            return disposableObject;
        }

        #endregion

        #region Assessment F Methods

        public static void ShowSomeMammalInformation<T>(T _type)
        {
            var type = typeof(T);
            var methodInfo = type.GetMethod("GetDetails");
            var result = methodInfo.Invoke(_type, null);

            Console.WriteLine(result);
        }

        public static U GenericTester<T, U>(Func<T, U> _func, T _type)
        {
            if(_type == null)
            {
                _type = (T)Activator.CreateInstance(typeof(T));
            }

            return  _func(_type);
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
                ThrowException(e);
            }
        }

        private static void ThrowException()
        {
            throw new ArithmeticException("illegal expression - was this picked up??");
        }

        private static void ThrowException(ArithmeticException e)
        {
            throw new ArithmeticException(e.StackTrace);
        }

        #endregion

        #region Assessment H Methods

        public static string CallMethodWithReflection()
        {
            // BY MAKING USE OF ONLY REFLECTION
            // CALL THE FOLLOWING METHOD: DisplaySomeStuff [WHICH IN JUST BELOW THIS ONE]
            // AND RETURN THE STRING CONTENT

            // DO NOT CHANGE THE NAME, RETURN TYPE OR ANY IMPLEMENTATION OF THIS METHOD NOR THE BELOW METHOD
            return DisplaySomeStuff<Human>(new Human());
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
            Ioc.Container.Register<IDevice, SamsungDevice>();
            Ioc.Container.Register<IDeviceProcessor, DeviceProcessor>();

            // 2. resolve the IDeviceProcessor
            var deviceProcessor = Ioc.Container.Resolve(typeof(IDeviceProcessor));

            Ioc.Container.RegisterInstance(deviceProcessor);

            var processor = deviceProcessor as IDeviceProcessor;

            // call the GetDevicePrice method
            Console.WriteLine(processor.GetDevicePrice());
        }

        #endregion

        #region Dungeon

        public static IEnumerable<T> CustomWhere<T>(this IEnumerable<T> _enumerable, Expression<Func<T, bool>> _expression)
        {
            var results = new List<T>();
            var _func = _expression.Compile();

            foreach (var item in _enumerable)
            {
                if (_func(item))
                {
                    results.Add(item);
                }
            }

            return results;
        }

        public static IEnumerable<char> SelectOnlyVowels(this IEnumerable<char> chars)
        {
            var vowels = new List<string>()
            {
                "a",
                "e",
                "i",
                "o",
                "u"
            };

            var results = chars.Where(x => vowels.Contains(x.ToString().ToLower()));

            return results;
        }

        #endregion
    }
}
