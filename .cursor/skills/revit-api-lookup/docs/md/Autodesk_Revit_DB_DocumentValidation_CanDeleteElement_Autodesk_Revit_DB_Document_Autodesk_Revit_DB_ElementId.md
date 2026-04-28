---
kind: method
id: M:Autodesk.Revit.DB.DocumentValidation.CanDeleteElement(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId)
source: html/e9c8b6a3-5c37-a413-c1aa-c47f8f166a6c.htm
---
# Autodesk.Revit.DB.DocumentValidation.CanDeleteElement Method

Indicates if an element can be deleted.

## Syntax (C#)
```csharp
public static bool CanDeleteElement(
	Document document,
	ElementId elementId
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document.
- **elementId** (`Autodesk.Revit.DB.ElementId`) - The id of the element to check.

## Returns
True if the element can be deleted, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

