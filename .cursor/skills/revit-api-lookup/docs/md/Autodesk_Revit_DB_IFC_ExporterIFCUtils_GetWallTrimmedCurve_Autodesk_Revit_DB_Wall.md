---
kind: method
id: M:Autodesk.Revit.DB.IFC.ExporterIFCUtils.GetWallTrimmedCurve(Autodesk.Revit.DB.Wall)
source: html/a5c5ae79-7239-9e59-c5ac-4dbe83e0420f.htm
---
# Autodesk.Revit.DB.IFC.ExporterIFCUtils.GetWallTrimmedCurve Method

Obtains the curve of the wall trimmed or extended according to the end conditions of the wall.

## Syntax (C#)
```csharp
public static Curve GetWallTrimmedCurve(
	Wall pVWall
)
```

## Parameters
- **pVWall** (`Autodesk.Revit.DB.Wall`) - The wall.

## Returns
The trimmed or extended curve.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

