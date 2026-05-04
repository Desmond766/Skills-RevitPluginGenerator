---
kind: method
id: M:Autodesk.Revit.DB.JoinGeometryUtils.UnjoinGeometry(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.Element,Autodesk.Revit.DB.Element)
source: html/929c26e0-4613-ebad-5fe0-76b66f4ae087.htm
---
# Autodesk.Revit.DB.JoinGeometryUtils.UnjoinGeometry Method

Removes a join between two elements.

## Syntax (C#)
```csharp
public static void UnjoinGeometry(
	Document document,
	Element firstElement,
	Element secondElement
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document containing the two elements.
- **firstElement** (`Autodesk.Revit.DB.Element`) - The first element to be unjoined.
- **secondElement** (`Autodesk.Revit.DB.Element`) - The second element to be unjoined. This element must be joined to the fist element.

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
 -or-
 The elements cannot be unjoined.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Please remove or add segments on curtain grids instead of joining or unjoining geometry of the panels.

