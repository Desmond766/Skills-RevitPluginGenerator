---
kind: method
id: M:Autodesk.Revit.DB.JoinGeometryUtils.AreElementsJoined(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.Element,Autodesk.Revit.DB.Element)
source: html/69178304-668a-bcbd-b459-33de2146942d.htm
---
# Autodesk.Revit.DB.JoinGeometryUtils.AreElementsJoined Method

Determines whether two elements are joined.

## Syntax (C#)
```csharp
public static bool AreElementsJoined(
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
True if the two elements are joined.

## Remarks
This functionality is not available for family documents.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - document is not a project document.
 -or-
 The element firstElement was not found in the given document.
 -or-
 The element secondElement was not found in the given document.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

