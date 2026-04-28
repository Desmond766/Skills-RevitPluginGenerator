---
kind: method
id: M:Autodesk.Revit.DB.JoinGeometryUtils.SwitchJoinOrder(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.Element,Autodesk.Revit.DB.Element)
source: html/447f0dd2-40cf-4e1a-711a-44ad21f825b9.htm
---
# Autodesk.Revit.DB.JoinGeometryUtils.SwitchJoinOrder Method

Reverses the order in which two elements are joined.

## Syntax (C#)
```csharp
public static void SwitchJoinOrder(
	Document document,
	Element firstElement,
	Element secondElement
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document containing the two elements.
- **firstElement** (`Autodesk.Revit.DB.Element`) - The first element.
- **secondElement** (`Autodesk.Revit.DB.Element`) - The second element. This element must be joined to the first element.

## Remarks
The cutting element becomes the cut element and vice versa after the join order is switched.
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
 The elements cannot be joined.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Unable to switch the join order of these elements.

