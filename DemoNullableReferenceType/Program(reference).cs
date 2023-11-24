// Nullable reference types
// https://learn.microsoft.com/en-us/dotnet/csharp/nullable-references

using DemoNullableReferenceType;

#region Nullable oblivious vs. nullable aware 
string s = null; 
#endregion


#region Basics of Nullable reference type
// compiler null-state check for null reference type 
// string? 不會建立出新的型別，仍然是 string 型別, 但是由 compiler 判斷 null-state 提出警告或錯誤
// 其它物件型別也是相同道理 
{
    string message = "Hello, World!";
    int length = message.Length;         // dereferencing "message"
    Console.WriteLine(message);
}
#endregion

#region nullable reference type and its constructor
// https://learn.microsoft.com/en-us/dotnet/csharp/nullable-references#null-state-analysis

// The null state analysis doesn't trace into called methods. 
// constructor consideration - constructor chaining or nullable attributes 
// see Student.cs

Person person = new Person();
var student = new Student();

// https://learn.microsoft.com/zh-tw/dotnet/csharp/language-reference/attributes/nullable-analysis

#endregion

#region Data Class Example
{
    var user = new User("Art", "Tsai", DateTime.Now.AddYears(-35)); 
}
#endregion

#region Known Pitfalls
// Structs and Arrays
// https://docs.microsoft.com/en-us/dotnet/csharp/nullable-references#known-pitfalls

#endregion

