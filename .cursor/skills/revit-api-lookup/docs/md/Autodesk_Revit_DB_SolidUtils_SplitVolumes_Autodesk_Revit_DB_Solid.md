---
kind: method
id: M:Autodesk.Revit.DB.SolidUtils.SplitVolumes(Autodesk.Revit.DB.Solid)
source: html/0ba1e838-c300-ed47-bd2e-7fc3e2dd80d8.htm
---
# Autodesk.Revit.DB.SolidUtils.SplitVolumes Method

Splits a solid geometry into several separate solids.

## Syntax (C#)
```csharp
public static IList<Solid> SplitVolumes(
	Solid solid
)
```

## Parameters
- **solid** (`Autodesk.Revit.DB.Solid`) - The solid.

## Returns
The split solid geometries.

## Remarks
If no splitting is done, a copy of the input solid will be returned in the output array.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Failed to split the solid geometry.

