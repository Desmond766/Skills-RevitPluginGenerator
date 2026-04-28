---
kind: method
id: M:Autodesk.Revit.DB.Macros.MacroModule.AddMacro(System.String,System.String,System.String)
source: html/d1a54b7e-5a69-c2f1-f9ba-3e00b5c2c7fc.htm
---
# Autodesk.Revit.DB.Macros.MacroModule.AddMacro Method

Adds a macro to the module.

## Syntax (C#)
```csharp
public Macro AddMacro(
	string name,
	string description,
	string code
)
```

## Parameters
- **name** (`System.String`) - The macro name.
- **description** (`System.String`) - The description.
- **code** (`System.String`) - The code string, which should be the lines between the main bounding brackets of a method.

## Returns
The new macro.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Cannot add the Macro due to no permission.

