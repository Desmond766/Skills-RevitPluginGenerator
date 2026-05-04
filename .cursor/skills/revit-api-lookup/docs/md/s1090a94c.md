---
kind: method
id: M:Autodesk.Revit.DB.JoinGeometryUtils.GetJoinedElements(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.Element)
source: html/3a1b0e1e-e7f2-cb08-9983-c36137cac754.htm
---
# Autodesk.Revit.DB.JoinGeometryUtils.GetJoinedElements Method

Returns all elements joined to given element.

## Syntax (C#)
```csharp
public static ICollection<ElementId> GetJoinedElements(
	Document document,
	Element element
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document containing the element.
- **element** (`Autodesk.Revit.DB.Element`) - The element.

## Returns
The set of elements that are joined to the given element.

## Remarks
This functionality is not available for family documents.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - document is not a project document.
 -or-
 The element element was not found in the given document.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

