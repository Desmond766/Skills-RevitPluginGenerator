---
kind: method
id: M:Autodesk.Revit.DB.Mechanical.MechanicalUtils.ConnectDuctPlaceholdersAtCross(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.ElementId)
source: html/478e5140-7b77-a70f-ed92-6dc90d7e1979.htm
---
# Autodesk.Revit.DB.Mechanical.MechanicalUtils.ConnectDuctPlaceholdersAtCross Method

Connects a trio of placeholders that can intersect in a Cross connection.

## Syntax (C#)
```csharp
public static bool ConnectDuctPlaceholdersAtCross(
	Document document,
	ElementId placeholder1Id,
	ElementId placeholder2Id,
	ElementId placeholder3Id
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document.
- **placeholder1Id** (`Autodesk.Revit.DB.ElementId`) - The element id of the first duct placeholder.
- **placeholder2Id** (`Autodesk.Revit.DB.ElementId`) - The element id of the second duct placeholder.
- **placeholder3Id** (`Autodesk.Revit.DB.ElementId`) - The element id of third duct placeholder.

## Returns
True if connection succeeds, false otherwise.

## Remarks
If connection fails, the placeholders cannot be physically connected.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The element id placeholder1Id is not duct placeholder.
 -or-
 The element id placeholder2Id is not duct placeholder.
 -or-
 The element id placeholder3Id is not duct placeholder.
 -or-
 The elements belong to different types of system.
 -or-
 The curve placeholder2Id does not connect on the curve placeholder1Id or vice versa.
 -or-
 The curve placeholder3Id does not connect on the curve placeholder1Id or vice versa.
 -or-
 The curve placeholder2Id and placeholder3Id are not collinear.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

