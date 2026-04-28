---
kind: method
id: M:Autodesk.Revit.DB.Structure.StructuralConnectionSettings.GetStructuralConnectionSettings(Autodesk.Revit.DB.Document)
source: html/58eaed43-a72c-2bf8-3926-0d7c8040e85b.htm
---
# Autodesk.Revit.DB.Structure.StructuralConnectionSettings.GetStructuralConnectionSettings Method

Obtains the StructuralConnectionSettings object for the specified project document.

## Syntax (C#)
```csharp
public static StructuralConnectionSettings GetStructuralConnectionSettings(
	Document document
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - A project document.

## Returns
The StructuralConnectionSettings object.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - document is not a project document.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

