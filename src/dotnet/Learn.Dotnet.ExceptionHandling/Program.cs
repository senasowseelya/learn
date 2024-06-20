using System;
namespace Learn.Dotnet.ThrowVsThrowEx
{
    public class Program
    {
        static void Main(string[] args)
        {
            ClassWithThrow obj = new();
            obj.FirstMethod();
            Console.WriteLine("==========");
            ClassWithThrowEx objEx = new();
            objEx.FirstMethod();
        }

    }

    public class ClassWithThrow
    {
        public void FirstMethod()
        {
            try
            {
                SecondMethod();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }
        public void SecondMethod()
        {
            ThirdMethod();
        }
        public void ThirdMethod()
        {
            try
            {
                var constant = 0;
                var x = 3 / constant;
            }
            //Here i am throwing the exception using "throw" keyword which preserves the stack trace.
            catch
            {
                throw;
            }
        }
    }

    public class ClassWithThrowEx
    {
        public void FirstMethod()
        {
            try
            {
                SecondMethod();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }
        public void SecondMethod()
        {
            try
            {
                ThirdMethod();

            }
            catch (Exception ex)
            {
                //here i am throwing the exception using "throw ex" other than "throw"
                //which clears previous stack trace and creates a new stack trace from here.
                throw ex;
            }
        }
        public void ThirdMethod()
        {
            int constant = 0;
            int x = 3 / constant;
        }
    }
}
