---
kind: method
id: M:Autodesk.Revit.DB.Plumbing.PlumbingUtils.ConnectPipePlaceholdersAtCross(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.ElementId)
source: html/0339bfd3-6155-9f9b-2c3f-f44aa6d7eb69.htm
---
# Autodesk.Revit.DB.Plumbing.PlumbingUtils.ConnectPipePlaceholdersAtCross Method

Connects placeholders that looks like Cross connection.

## Syntax (C#)
```csharp
public static bool ConnectPipePlaceholdersAtCross(
	Document document,
	ElementId placeholder1Id,
	ElementId placeholder2Id
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document.
- **placeholder1Id** (`Autodesk.Revit.DB.ElementId`) - The first element Id of pipe placeholder.
- **placeholder2Id** (`Autodesk.Revit.DB.ElementId`) - The second element Id of pipe placeholder.

## Returns
True if connection succeeds, false otherwise.

## Remarks
The placeholders must intersect each other. If connection succeeds, a new
 placeholder is created. If connection fails, the placeholders cannot be physically connected.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The element id placeholder1Id is not pipe placeholder.
 -or-
 The element id placeholder2Id is not pipe placeholder.
 -or-
 The elements belong to different types of system.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

