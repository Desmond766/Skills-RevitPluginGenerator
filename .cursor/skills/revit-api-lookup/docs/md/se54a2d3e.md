---
kind: method
id: M:Autodesk.Revit.DB.Mechanical.MechanicalUtils.ConnectDuctPlaceholdersAtTee(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.ElementId)
source: html/9e85e3aa-6f29-54fb-882a-cca23fd72751.htm
---
# Autodesk.Revit.DB.Mechanical.MechanicalUtils.ConnectDuctPlaceholdersAtTee Method

Connects a pair of placeholders that can intersect in a Tee connection.

## Syntax (C#)
```csharp
public static bool ConnectDuctPlaceholdersAtTee(
	Document document,
	ElementId placeholder1Id,
	ElementId placeholder2Id
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document.
- **placeholder1Id** (`Autodesk.Revit.DB.ElementId`) - The element Id of the first duct placeholder.
- **placeholder2Id** (`Autodesk.Revit.DB.ElementId`) - The element Id of the second duct placeholder.

## Returns
True if connection succeeds, false otherwise.

## Remarks
The placeholders must have a physical intersection.
 If connection fails, the placeholders cannot be physically connected.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The element id placeholder1Id is not duct placeholder.
 -or-
 The element id placeholder2Id is not duct placeholder.
 -or-
 The elements belong to different types of system.
 -or-
 The curve placeholder2Id does not connect on the curve placeholder1Id or vice versa.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

