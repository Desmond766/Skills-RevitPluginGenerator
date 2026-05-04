---
kind: method
id: M:Autodesk.Revit.DB.FaceWall.IsWallTypeValidForFaceWall(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId)
source: html/507024ad-93ae-15be-a92b-21540dd5220c.htm
---
# Autodesk.Revit.DB.FaceWall.IsWallTypeValidForFaceWall Method

Identifies if a wall type may be applied to a face wall.

## Syntax (C#)
```csharp
public static bool IsWallTypeValidForFaceWall(
	Document document,
	ElementId wallType
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document.
- **wallType** (`Autodesk.Revit.DB.ElementId`) - The wall type.

## Returns
True if the wall type is valid for face wall, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

