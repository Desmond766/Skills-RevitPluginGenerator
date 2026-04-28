---
kind: method
id: M:Autodesk.Revit.DB.GlobalParametersManager.IsUniqueName(Autodesk.Revit.DB.Document,System.String)
source: html/30f6c20b-2ddd-b584-8770-d7968bf70c29.htm
---
# Autodesk.Revit.DB.GlobalParametersManager.IsUniqueName Method

Tests whether a name is unique among existing global parameters of a given document.

## Syntax (C#)
```csharp
public static bool IsUniqueName(
	Document document,
	string name
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - Document in which a new parameter is to be added.
- **name** (`System.String`) - A name of a parameter being added.

## Returns
True if the given %name% does not exist yet among existing global parameters nof the document; False otherwise.

## Remarks
Typically, this method is used before a new global parameters is created, for
 all global parameters must have their names unique in the scope of a document.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

