// Nullable value types (C# reference)
// https://learn.microsoft.com/zh-tw/dotnet/csharp/language-reference/builtin-types/nullable-value-types


#region Nullable value type basics
using DemoNullableReferenceType;

{
    // int?, double?, bool?, char? 
    // is a type of Nullable<T>, which is a strucutre (struct)
    // Nullable<T> is a structure that wraps a value type

    int x;           // 未設值, 那麼是 default, 0. x 不可能包括 null 值 
    int? a=10;       // 如果未設值, 會是 default, null.  nullable value type 變數必需設值. 
    if (a is int value) Console.WriteLine($"a = {value}");
    if (a is null) Console.WriteLine("a is null");

    int? b = 10;

    if (b.HasValue)
    {
        Console.WriteLine($"b is {b.Value}");
    }
    else
    {
        Console.WriteLine("b does not have a value");
    }
    b = null;
    //Console.WriteLine($"b is null, then b's value is {b.Value}");

    // actually. I'd like to use 'is' instead of 'hasValue' and 'Value'
}
#endregion

// boxing : nullable value type 使用 boxing 方式
// boxing 的話, 會變成 object, 放在 heap (堆積)

#region nullable context 
// see https://learn.microsoft.com/en-us/dotnet/csharp/nullable-references#nullable-contexts
// disable, enable, warnings, annotations

// you can set <WarningsAsErrors>Nullable</WarningsAsErrors>
// in .csproj file to make nullable warnings as errors
#endregion

#region lifted operators - operators that work on nullable value types
// 數學運算, 以及邏輯運算
// 中文: 增益運算元 (這個詞不必記) 
{
    // 任何運算子是 null 的話, 結果是 null 
    int? a = 10;
    int? b = null;
    int? c = 10;

    a++;          // a is 11
    a = a * c;    // a is 100
    a = a + b;    // a is null, because b is null

    // bool ( &, | ) 不符合 lifted operators 的規則
    // see: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/boolean-logical-operators#nullable-boolean-logical-operators
    // 我會建議直接使用 pattern matching, 不要跟 “複雜” 打架

    bool? ba = null;
    bool? bb = false;
    Console.WriteLine($"bool: null && false = {ba & bb} ");

    // For the comparison operators <, >, <=, and >=, if one or both operands are null, the result is false;
    int? da = 10;
    Console.WriteLine($"{da} >= null is {da >= null}");
    Console.WriteLine($"{da} < null is {da < null}");
    Console.WriteLine($"{da} == null is {da == null}");
    // Output:
    // 10 >= null is False
    // 10 < null is False
    // 10 == null is False

    int? db = null;
    int? dc = null;
    Console.WriteLine($"null >= null is {db >= dc}");
    Console.WriteLine($"null == null is {db == dc}");
    // Output:
    // null >= null is False
    // null == null is True
}
#endregion

//
// 以下，是 nullable 相關的運算元介紹. Nullable 機制都適用. (value type, reference type)
//


#region Annotations for variables
{
    string? HandleName(string? name) => name;

    string? name = null;
    name = HandleName(name);

    // use ! (null forgiving operator), I (developer) am sure and responsible it is not null
    //Console.WriteLine(name!.Length);
}
#endregion

#region ?? and ??= operators - the null-coalescing operators
// 讀成 '沒值的話..' 
{
    int? c = null;
    int d = c ?? 28;
    Console.WriteLine($"d is {d}");  // output: b is 28
    
    int? e = null; 
    int? f = null;

    f ??= e ?? 10;
    Console.WriteLine($"f is {f}");

    int? bn = null;

    //int bm1 = bn;    // Doesn't compile
    //int bn2 = (int)bn; // Compiles, but throws an exception if n is null
}
#endregion


#region 是否有值運算元 (value type, reference type 都適用)
// ?. 以及 ?[] 讀成 "有值的話"
// 無值的話, 不往下做，結果當做 null
// null;   // 是空敍述，沒有執行任何東西 
// nullable value type (實值), nullable reference type (物件) 都適用
{
    var users = new List<ChatUser?>()
    {
        new ChatUser(), 
        null 
    };

    foreach (var user in users)
        Console.WriteLine($"Welcom, user {user?.NickName}");   // 使用 ?.

    var user1 = users?[1];
    var nickname = users?[1]?.NickName;
    user1?.DoChat();

}
#endregion

