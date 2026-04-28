---
kind: method
id: M:Autodesk.Revit.DB.Steel.SteelElementProperties.GetReference(Autodesk.Revit.DB.Document,System.Guid)
source: html/34024d32-4696-8d23-b739-4b5f2e0f3370.htm
---
# Autodesk.Revit.DB.Steel.SteelElementProperties.GetReference Method

This method will return the reference for the given fabrication id.

## Syntax (C#)
```csharp
public static Reference GetReference(
	Document aDoc,
	Guid guid
)
```

## Parameters
- **aDoc** (`Autodesk.Revit.DB.Document`) - Document in which to search for the reference.
- **guid** (`System.Guid`) - The fabrication id for which a reference is required.

## Returns
The reference to the element or subelement corresponding to the given id.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

