# Unit testing

## Setup

### In the solution folder
```
dotnet new --install bunit.template::1.0.0-preview-02
```

```language
dotnet new bunit -o BlazorTodoListWasmUT
```


```language
dotnet sln BlazorTraining.sln add BlazorTodoListWasmUT
dotnet add .\BlazorTodoListWasmUT\BlazorTodoListWasmUT.csproj reference .\BlazorTodoListWasm\
```

### in the test project folder

> is it really necessary ?
> should not `dotnet restore` by enough?

````
dotnet add package bunit --version 1.0.16
````


https://blog.stevensanderson.com/2019/08/29/blazor-unit-testing-prototype/

https://www.telerik.com/blogs/unit-testing-blazor-components-bunit-justmock

https://github.com/mihail-vladov/Blazor-unit-testing/tree/master/BlazorUnitTests
