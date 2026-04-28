---
kind: method
id: M:Autodesk.Revit.UI.RevitCommandId.LookupCommandId(System.String)
source: html/da7c96b5-6347-d712-80ed-a5ae31291aa2.htm
---
# Autodesk.Revit.UI.RevitCommandId.LookupCommandId Method

Looks up and retrieves the Revit command id with the given id string.

## Syntax (C#)
```csharp
public static RevitCommandId LookupCommandId(
	string name
)
```

## Parameters
- **name** (`System.String`) - he Revit command name. Refer to the entries in the Revit journal to find the string to use for a particular command.

## Returns
The Revit command id. Returning "null" if a command with the given name was not found.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

