# CSharp.Pipe
This lib is made to bring piping to c#.
It dos not add any functionality but it makes the code more readable. Its just syntactic sugar!
## Use
lets say you have these functions :
```cs
    private int _val = 6;

    private int GetById(int id) => _val;
    private static Func<int, int> Add(int x) => y => x + y;

    private Action<int> Save(int id ) => val => _val = val;
```
normally if would lock like 
```cs
    const int id = 2;
    var v = GetById(id);
    v = Add(v)(2);
    Save(id)(v);
```
but with the piping it looks like
```cs
    const int id = 2;
    GetById(id)
        .Pipe(Add(2))
        .Pipe(Save(id));
```
More examples in the tests

## Install
```
Install-Package CSharp.Pipe 
```
```
dotnet add package CSharp.Pipe
```
