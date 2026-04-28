---
kind: method
id: M:Autodesk.Revit.UI.ToggleButtonData.#ctor(System.String,System.String)
source: html/309eb3ec-4fb5-e4d0-e44c-183a48afe0ba.htm
---
# Autodesk.Revit.UI.ToggleButtonData.#ctor Method

Constructs a new instance of ToggleButtonData, where the ToggleButton will not be associated to an ExternalCommand.

## Syntax (C#)
```csharp
public ToggleButtonData(
	string name,
	string text
)
```

## Parameters
- **name** (`System.String`) - The internal name of the new button.
- **text** (`System.String`) - The user visible text seen on the new button.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when Nothing nullptr a null reference ( Nothing in Visual Basic) is passed for one or more arguments.
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when an empty string is passed for one or more arguments.

