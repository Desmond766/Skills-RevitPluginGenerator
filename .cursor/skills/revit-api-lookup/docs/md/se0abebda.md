---
kind: method
id: M:Autodesk.Revit.DB.Plumbing.PlumbingUtils.ConnectPipePlaceholdersAtElbow(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.ElementId)
source: html/fb253656-e397-25cb-44a4-ac6c15ed783d.htm
---
# Autodesk.Revit.DB.Plumbing.PlumbingUtils.ConnectPipePlaceholdersAtElbow Method

Connects placeholders that looks like elbow connection.

## Syntax (C#)
```csharp
public static bool ConnectPipePlaceholdersAtElbow(
	Document document,
	ElementId placeholder1Id,
	ElementId placeholder2Id
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document.
- **placeholder1Id** (`Autodesk.Revit.DB.ElementId`) - The element Id of pipe placeholder.
- **placeholder2Id** (`Autodesk.Revit.DB.ElementId`) - The element Id of pipe placeholder.

## Returns
True if connection succeeds, false otherwise.

## Remarks
There must be a physical end connection of placeholders.
 If connection fails, the placeholders cannot be physically connected.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The element id placeholder1Id is not pipe placeholder.
 -or-
 The element id placeholder2Id is not pipe placeholder.
 -or-
 The elements belong to different types of system.
 -or-
 The curve placeholder1Id and placeholder2Id are not physically connected.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

