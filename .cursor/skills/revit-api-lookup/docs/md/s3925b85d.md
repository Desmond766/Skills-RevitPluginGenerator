---
kind: method
id: M:Autodesk.Revit.UI.ToggleButtonData.#ctor(System.String,System.String,System.String,System.String)
source: html/079c68bf-3bb5-7146-2631-91a33885b9c5.htm
---
# Autodesk.Revit.UI.ToggleButtonData.#ctor Method

Constructs a new instance of ToggleButtonData, where the ToggleButton will execute an ExternalCommand when clicked.

## Syntax (C#)
```csharp
public ToggleButtonData(
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

