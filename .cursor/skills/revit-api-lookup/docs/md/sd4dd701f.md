---
kind: method
id: M:Autodesk.Revit.DB.CompoundStructure.GetOffsetForLocationLine(Autodesk.Revit.DB.WallLocationLine)
source: html/6deb6602-4fdc-a01e-170c-e8a3e953bc4b.htm
---
# Autodesk.Revit.DB.CompoundStructure.GetOffsetForLocationLine Method

Returns the offset from the center of the compound structure to the given location line value.

## Syntax (C#)
```csharp
public double GetOffsetForLocationLine(
	WallLocationLine wallLocationLine
)
```

## Parameters
- **wallLocationLine** (`Autodesk.Revit.DB.WallLocationLine`) - The alignment type of the wall's location line.

## Returns
The offset.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This operation is valid only vertically homogeneous compound structures.

