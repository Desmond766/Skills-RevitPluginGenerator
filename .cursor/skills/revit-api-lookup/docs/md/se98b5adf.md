---
kind: method
id: M:Autodesk.Revit.DB.Mechanical.MechanicalUtils.ConnectDuctPlaceholdersAtCross(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.ElementId)
source: html/40648bfb-d174-a451-71fd-9c4213532efb.htm
---
# Autodesk.Revit.DB.Mechanical.MechanicalUtils.ConnectDuctPlaceholdersAtCross Method

Connects a pair of placeholders that can intersect in a Cross connection.

## Syntax (C#)
```csharp
public static bool ConnectDuctPlaceholdersAtCross(
	Document document,
	ElementId placeholder1Id,
	ElementId placeholder2Id
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document.
- **placeholder1Id** (`Autodesk.Revit.DB.ElementId`) - The element id of the first duct placeholder.
- **placeholder2Id** (`Autodesk.Revit.DB.ElementId`) - The element id of the second duct placeholder.

## Returns
True if connection succeeds, false otherwise.

## Remarks
The placeholders must intersect each other. If connection succeeds, a new
 placeholder duct is created. If connection fails, the placeholders cannot be physically connected.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The element id placeholder1Id is not duct placeholder.
 -or-
 The element id placeholder2Id is not duct placeholder.
 -or-
 The elements belong to different types of system.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

