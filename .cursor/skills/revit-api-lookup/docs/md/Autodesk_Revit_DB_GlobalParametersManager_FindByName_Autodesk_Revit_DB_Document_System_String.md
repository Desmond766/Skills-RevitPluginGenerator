---
kind: method
id: M:Autodesk.Revit.DB.GlobalParametersManager.FindByName(Autodesk.Revit.DB.Document,System.String)
source: html/7c7a7bd3-18e8-d9be-d9a7-66cd9ecdccc7.htm
---
# Autodesk.Revit.DB.GlobalParametersManager.FindByName Method

Finds whether a global parameter with the given name exists in the input document.

## Syntax (C#)
```csharp
public static ElementId FindByName(
	Document document,
	string name
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document expected to contain the global parameter.
- **name** (`System.String`) - Name of the global parameter

## Returns
ElementId of the parameter element, or InvalidElementId if it was not found.

## Remarks
No exception is thrown when no parameter with such a name exists in the document;
 instead, the method returns an ElementId.InvalidElementId.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

