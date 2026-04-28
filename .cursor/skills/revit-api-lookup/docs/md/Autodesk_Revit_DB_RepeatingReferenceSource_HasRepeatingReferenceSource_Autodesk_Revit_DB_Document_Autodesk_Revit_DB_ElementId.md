---
kind: method
id: M:Autodesk.Revit.DB.RepeatingReferenceSource.HasRepeatingReferenceSource(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId)
source: html/e5abe003-f93b-b841-86cf-6129dab783ef.htm
---
# Autodesk.Revit.DB.RepeatingReferenceSource.HasRepeatingReferenceSource Method

Determines whether an element has any repeating reference sources that can be used when creating component repeaters.

## Syntax (C#)
```csharp
public static bool HasRepeatingReferenceSource(
	Document document,
	ElementId elementId
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document that contains the element.
- **elementId** (`Autodesk.Revit.DB.ElementId`) - The id of the element.

## Returns
True if the element has any repeating reference sources.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The element elementId does not exist in the document
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

