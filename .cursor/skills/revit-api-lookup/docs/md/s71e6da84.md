---
kind: method
id: M:Autodesk.Revit.DB.Mechanical.MechanicalUtils.ConnectDuctPlaceholdersAtElbow(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.ElementId)
source: html/9cbf2d10-9495-abba-2c6f-d7fa44eb4756.htm
---
# Autodesk.Revit.DB.Mechanical.MechanicalUtils.ConnectDuctPlaceholdersAtElbow Method

Connects a pair of placeholders that can intersect in an Elbow connection.

## Syntax (C#)
```csharp
public static bool ConnectDuctPlaceholdersAtElbow(
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
The placeholders must meet at a physical end connection.
 If connection fails, the placeholders cannot be physically connected.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The element id placeholder1Id is not duct placeholder.
 -or-
 The element id placeholder2Id is not duct placeholder.
 -or-
 The elements belong to different types of system.
 -or-
 The curve placeholder1Id and placeholder2Id are not physically connected.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

