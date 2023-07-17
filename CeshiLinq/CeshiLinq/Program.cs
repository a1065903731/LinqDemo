using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CeshiLinq
{
    class Program
    {
        private delegate string DelLambda();//没有参数
        private delegate void DelLambdaOne(string Param);//一个参数
        private delegate int DelLambdaTwo(int Param1, int param2);//两个参数表达多个
        //测试分支上传 ylb @2023-7-17 13:58:59

        // Func表示有返回值,前面两个int入参，最后一个int回参
        static Func<int, int, int> add = (a, b) => a + b;
        // Action没有返回值
        static Action printl = () => Console.WriteLine(" print1 called");
        static Action<string> print2 = x =>
         {
             Console.WriteLine("print2 called");
             Console.WriteLine($"hello {x}");
         };

         static void Main(string[] args)
        {
            Test4();
            Console.ReadKey();
        }

        private static void Test1()
        {
            var lstUser = new List<User>
            {
                new User{strName="张三",nAge=25,dtBirthday=DateTime.Parse("2008-03-01") },
                new User{strName="李四",nAge=30,dtBirthday=DateTime.Parse("2008-03-02") },
                new User{strName="王五",nAge=20,dtBirthday=DateTime.Parse("1989-03-02") },
                new User{strName="叶少",nAge=41,dtBirthday=DateTime.Parse("1996-03-22") },
                new User{strName="张三",nAge=38,dtBirthday=DateTime.Parse("1998-05-15") }
            };
            Console.WriteLine("姓张的人有哪些:");
            var res1 = from user in lstUser
                       where user.strName.StartsWith("张")
                       select user;
            foreach (var user in res1)
            {
                Console.WriteLine(user.strName);
            }

            Console.WriteLine();
            Console.WriteLine("年龄在20-30之间（包括20 30）:");
            var res2 = from user in lstUser
                       where user.nAge >= 20 && user.nAge <= 30
                       select user;
            foreach (var user in res2)
            {
                Console.WriteLine(user.strName);
            }

            Console.WriteLine();
            Console.WriteLine("名字为张三年龄最大的一个人");
            var res3 = from user in lstUser
                       where user.strName == "张三"
                       orderby user.nAge descending
                       select user.strName + " 年龄为 " + user.nAge.ToString();
            foreach (var user in res3)
            {
                Console.WriteLine(user.ToString());
                break;
            }
        }

        private static void Test2()
        {
            DelLambda delLambda = () => { return "我没有参数的Lambda"; };
            Console.WriteLine(delLambda());
            printl();
            print2("Action-lambda 打印参数");
        }
        private static void Test3()
        {
            DelLambdaOne delLambdaOne = x => { Console.WriteLine(x); };
            delLambdaOne("只有一个参数的Lambda");
        }
        private static void Test4()
        {
            DelLambdaTwo delLambdaTwo = (p1,p2) => { return p1 * p2; };
            Console.WriteLine("{0}*{1}={2}",10,2, delLambdaTwo(10,2));
            Console.WriteLine("{0}+{1}={2}", 10, 2, add(10, 2));
        }
    }
}
