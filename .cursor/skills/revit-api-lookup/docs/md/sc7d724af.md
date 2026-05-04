---
kind: method
id: M:Autodesk.Revit.DB.JoinGeometryUtils.IsCuttingElementInJoin(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.Element,Autodesk.Revit.DB.Element)
source: html/917ea88b-27cb-e3b1-391f-ecd061975595.htm
---
# Autodesk.Revit.DB.JoinGeometryUtils.IsCuttingElementInJoin Method

Determines whether the first of two joined elements is cutting the second element.

## Syntax (C#)
```csharp
public static bool IsCuttingElementInJoin(
	Document document,
	Element firstElement,
	Element secondElement
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document containing the two elements.
- **firstElement** (`Autodesk.Revit.DB.Element`) - The first element.
- **secondElement** (`Autodesk.Revit.DB.Element`) - The second element.

## Returns
True if the secondElement is cut by the firstElement, false if the secondElement is cut by the firstElement.

## Remarks
This functionality is not available for family documents.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - document is not a project document.
 -or-
 The element firstElement was not found in the given document.
 -or-
 The element secondElement was not found in the given document.
 -or-
 The elements are not joined.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

