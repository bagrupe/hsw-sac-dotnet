var myBool = true;

System.Console.WriteLine(myBool.GetType());

var myNumber1 = 1_000_000;
var myNumber2 = 1_000_000L;
var myNumber3 = 1_000_000_000_000;

System.Console.WriteLine(myNumber1.GetType());
System.Console.WriteLine(myNumber2.GetType());
System.Console.WriteLine(myNumber3.GetType());

var myFloat1 = 1.5f;
var myFloat2 = 1.5;
var myFloat3 = 1.23456789;

System.Console.WriteLine(myFloat1.GetType());
System.Console.WriteLine(myFloat2.GetType());
System.Console.WriteLine(myFloat3.GetType());