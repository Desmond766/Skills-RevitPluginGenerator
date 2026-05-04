---
kind: method
id: M:Autodesk.Revit.DB.Plumbing.PlumbingUtils.ConnectPipePlaceholdersAtCross(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.ElementId)
source: html/267fc56d-a31d-987c-569c-e47f2b3d235c.htm
---
# Autodesk.Revit.DB.Plumbing.PlumbingUtils.ConnectPipePlaceholdersAtCross Method

Connects placeholders that looks like Cross connection.

## Syntax (C#)
```csharp
public static bool ConnectPipePlaceholdersAtCross(
	Document document,
	ElementId placeholder1Id,
	ElementId placeholder2Id,
	ElementId placeholder3Id
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document.
- **placeholder1Id** (`Autodesk.Revit.DB.ElementId`) - The first element Id of pipe placeholder.
- **placeholder2Id** (`Autodesk.Revit.DB.ElementId`) - The second element Id of pipe placeholder that intersects with first one.
- **placeholder3Id** (`Autodesk.Revit.DB.ElementId`) - The third element Id of pipe placeholder that intersects with first one.

## Returns
True if connection succeeds, false otherwise.

## Remarks
If connection fails, the placeholders cannot be physically connected.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The element id placeholder1Id is not pipe placeholder.
 -or-
 The element id placeholder2Id is not pipe placeholder.
 -or-
 The element id placeholder3Id is not pipe placeholder.
 -or-
 The elements belong to different types of system.
 -or-
 The curve placeholder2Id does not connect on the curve placeholder1Id or vice versa.
 -or-
 The curve placeholder3Id does not connect on the curve placeholder1Id or vice versa.
 -or-
 The curve placeholder2Id and placeholder3Id are not collinear.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

