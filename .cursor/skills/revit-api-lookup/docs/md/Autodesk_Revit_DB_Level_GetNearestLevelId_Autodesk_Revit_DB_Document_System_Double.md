---
kind: method
id: M:Autodesk.Revit.DB.Level.GetNearestLevelId(Autodesk.Revit.DB.Document,System.Double)
zh: 标高
source: html/1c70cf7c-bcca-7ebf-99e3-8514e159f089.htm
---
# Autodesk.Revit.DB.Level.GetNearestLevelId Method

**中文**: 标高

Returns id of the Level which is closest to the specified elevation.

## Syntax (C#)
```csharp
public static ElementId GetNearestLevelId(
	Document document,
	double elevation
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document.
- **elevation** (`System.Double`) - Target Elevation.

## Remarks
The level can be at, above or below the target elevation.
 If there is more than one Level at the same distance from the elevation, the Level with the lowest Id will be returned.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

