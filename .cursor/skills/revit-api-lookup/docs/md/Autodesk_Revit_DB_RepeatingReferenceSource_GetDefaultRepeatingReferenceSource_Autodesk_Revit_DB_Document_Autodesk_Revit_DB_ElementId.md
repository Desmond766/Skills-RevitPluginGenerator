---
kind: method
id: M:Autodesk.Revit.DB.RepeatingReferenceSource.GetDefaultRepeatingReferenceSource(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId)
source: html/2f9772ee-a2ba-8b07-d480-5cef37a23edf.htm
---
# Autodesk.Revit.DB.RepeatingReferenceSource.GetDefaultRepeatingReferenceSource Method

Returns the default repeating reference source for a given element.

## Syntax (C#)
```csharp
public static RepeatingReferenceSource GetDefaultRepeatingReferenceSource(
	Document document,
	ElementId elementId
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document that contains the element.
- **elementId** (`Autodesk.Revit.DB.ElementId`) - The id of the element.

## Returns
The default repeating reference source of the given element.

## Remarks
The element must support repeating references. Use HasRepeatingReferenceSource() to find out whether an element has any repeating references.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The element elementId does not exist in the document
 -or-
 The element does not have any repeating reference sources.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

