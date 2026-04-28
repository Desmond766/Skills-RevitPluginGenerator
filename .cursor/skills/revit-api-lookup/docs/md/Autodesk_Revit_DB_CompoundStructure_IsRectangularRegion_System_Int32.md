---
kind: method
id: M:Autodesk.Revit.DB.CompoundStructure.IsRectangularRegion(System.Int32)
source: html/95361f1e-ea42-932a-3417-7238c4558e0c.htm
---
# Autodesk.Revit.DB.CompoundStructure.IsRectangularRegion Method

Determines whether the specified region is rectangular.

## Syntax (C#)
```csharp
public bool IsRectangularRegion(
	int regionId
)
```

## Parameters
- **regionId** (`System.Int32`) - The id of a region.

## Returns
True if the specified region is a rectangle, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - It is not a valid region id.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This operation is valid only for vertically compound structures.

