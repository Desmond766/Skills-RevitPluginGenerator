---
kind: method
id: M:Autodesk.Revit.DB.Plumbing.PlumbingUtils.ConnectPipePlaceholdersAtTee(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.ElementId)
source: html/c4664927-c5e7-3ccd-f401-3a8cc5fb4231.htm
---
# Autodesk.Revit.DB.Plumbing.PlumbingUtils.ConnectPipePlaceholdersAtTee Method

Connects two placeholders that looks like Tee connection.

## Syntax (C#)
```csharp
public static bool ConnectPipePlaceholdersAtTee(
	Document document,
	ElementId placeholder1Id,
	ElementId placeholder2Id
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document.
- **placeholder1Id** (`Autodesk.Revit.DB.ElementId`) - The first element Id of pipe placeholder.
- **placeholder2Id** (`Autodesk.Revit.DB.ElementId`) - The second element Id of pipe placeholder which connects to first.

## Returns
True if connection succeeds, false otherwise.

## Remarks
The second placeholder must have physically connection with the first one.
 If connection fails, the placeholders cannot be physically connected.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The element id placeholder1Id is not pipe placeholder.
 -or-
 The element id placeholder2Id is not pipe placeholder.
 -or-
 The elements belong to different types of system.
 -or-
 The curve placeholder2Id does not connect on the curve placeholder1Id or vice versa.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

