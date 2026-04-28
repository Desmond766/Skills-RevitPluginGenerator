---
kind: method
id: M:Autodesk.Revit.DB.PartMakerMethodToDivideVolumes.IsValidSketchPlane(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId)
source: html/4dd193b5-2f9a-d200-6e8e-365657f6770d.htm
---
# Autodesk.Revit.DB.PartMakerMethodToDivideVolumes.IsValidSketchPlane Method

Identifies if provided sketch plane is valid.

## Syntax (C#)
```csharp
public static bool IsValidSketchPlane(
	Document document,
	ElementId sketchPlaneId
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document.
- **sketchPlaneId** (`Autodesk.Revit.DB.ElementId`) - SketchPlane ids to be tested for validity for PartMaker.

## Returns
True if SketchPlane valid, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

