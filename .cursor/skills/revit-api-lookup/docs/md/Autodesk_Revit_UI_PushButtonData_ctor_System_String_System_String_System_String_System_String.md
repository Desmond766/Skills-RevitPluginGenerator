---
kind: method
id: M:Autodesk.Revit.UI.PushButtonData.#ctor(System.String,System.String,System.String,System.String)
zh: 按钮
source: html/69de97ea-b34e-108d-0cbb-dd766852a4b4.htm
---
# Autodesk.Revit.UI.PushButtonData.#ctor Method

**中文**: 按钮

Constructs a new instance of PushButtonData.

## Syntax (C#)
```csharp
public PushButtonData(
	string name,
	string text,
	string assemblyName,
	string className
)
```

## Parameters
- **name** (`System.String`) - The internal name of the new button.
- **text** (`System.String`) - The user visible text seen on the new button.
- **assemblyName** (`System.String`) - The assembly path of the button.
- **className** (`System.String`) - The name of the class containing the implementation for the command.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when Nothing nullptr a null reference ( Nothing in Visual Basic) is passed for one or more arguments.
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when an empty string is passed for one or more arguments.

