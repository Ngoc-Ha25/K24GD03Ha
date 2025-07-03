using System;
using System.Runtime.InteropServices;

namespace LAB6
{
    internal class Program
    {
      
        static void Main(string[] args)
        {
            Func<double, double, double> myFunc01 = delegate (double a, double b)
            {
                return a * b;
            };
            Console.WriteLine("Func Tich: " + myFunc01?.Invoke(5, 10));
            Func<double, double, double> myFunc02 = delegate (double a, double b)
            {
                return a / b;
            };
            Console.WriteLine("Func Thuong: " + myFunc02?.Invoke(5, 10));
            Func<int, int, int> myFunc03 = (a, b) => a * b;
            int result = myFunc03(4, 5);
            Console.WriteLine("Tich: " + result);

        }
    }
    
}




//public delegate void Display();

//class Events
//{
//    public event Display Print;


//    public void Show()
//    {
//        Console.WriteLine("This is an event-driven program");
//        Print?.Invoke();
//    }
//}
//public void HandleEvent()
//{
//    Console.WriteLine("Su kien da duoc xu ly");
//}

//static void Main(string[] args)
//{
//    Events objEvents = new Events();
//    objEvents.Print += () => Console.WriteLine("Su kien da duoc xu ly");
//    objEvents.Show();
//    Console.ReadLine();
//}




//public delegate void Logger();
//class LogSystem
//{
//    public static void LogToFile() => Console.WriteLine("Ghi vào file");
//    public static void LogToConsole() => Console.WriteLine("Hiển thị console");
//}
//static void Main(string[] args)
//{
//    Logger logger = LogSystem.LogToFile;
//    logger += LogSystem.LogToConsole;
//    logger();
//}




//delegate void XinChao(string s);

//static void Main(string[] args)
//{
//    Console.WriteLine("DELEGATE");

//    XinChao btn01 = delegate (string s)
//    {
//        Console.WriteLine("BTN01: " + s);
//    };

//    XinChao btn02 = delegate (string s)
//    {
//        Console.WriteLine("BTN02: " + s);
//    };

//    XinChao btn03 = delegate (string s)
//    {
//        Console.WriteLine("BTN03: " + s);
//    };
//    XinChao btn04 = (string s) => Console.WriteLine("LAMDA: " + s);

//    btn01?.Invoke("A");
//    btn02?.Invoke("B");
//    btn03?.Invoke("C");
//    btn04?.Invoke("D");

//    Console.ReadLine();
//}



//delegate void MyDelegateVD00();
//delegate void MyDelegateVD02(string s);
//delegate int TinhToan1ThamSo(int a);
//delegate float TinhToan2ThamSo(float a, float b);
//public static float TinhCong(float a, float b)
//{
//    return a + b;
//}
//static void ShowTextDemo()
//{
//    Console.WriteLine("Đây là phương thức ShowTextDemo.");
//}
//static void ShowTextSDemo(string s)
//{
//    Console.WriteLine($"Xin chào, {s}!");
//}

//static void Main(string[] args)
//{
//    Console.WriteLine("=== DELEGATE DEMO ===");
//    MyDelegateVD00 myVD00 = new MyDelegateVD00(ShowTextDemo);
//    myVD00?.Invoke();
//    MyDelegateVD00 myVD01 = null;
//    if (myVD01 != null)
//        myVD01();
//    myVD01?.Invoke();
//    MyDelegateVD02 myVD02 = ShowTextSDemo;
//    myVD02?.Invoke("TOM");

//    TinhToan2ThamSo myTinhToanDLG = TinhCong;
//    float a = 5;
//    float b = 10;
//    float tong = myTinhToanDLG(a, b);
//    Console.WriteLine($"Tổng của {a} + {b} = {tong}");
//    Console.ReadLine();
//}





//public delegate double Temperature(double temp);

//public static double FahrenheitToCelsius(double temp)
//{

//    return ((temp - 32) / 9) * 5;
//}
//static void Main(string[] args)
//{
//    Temperature tempConversion = new Temperature(FahrenheitToCelsius);

//    double tempF = 96;

//    double tempC = tempConversion(tempF);

//    Console.WriteLine("Temperature in Fahrenheit = {0:F}", tempF);

//    Console.WriteLine("Temperature in Celsius = {0:F}", tempC);



//}