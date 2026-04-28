---
kind: method
id: M:Autodesk.Revit.DB.CompoundStructure.GetRegionsAlongLevel(System.Double)
source: html/484c680f-0545-bb6e-c987-ba813751db2c.htm
---
# Autodesk.Revit.DB.CompoundStructure.GetRegionsAlongLevel Method

Returns the ids of the regions encountered as the vertically compound structure is traversed
 at a constant height above the bottom a wall to which this structure is applied.

## Syntax (C#)
```csharp
public IList<int> GetRegionsAlongLevel(
	double height
)
```

## Parameters
- **height** (`System.Double`) - Distance from the bottom of the wall.

## Returns
The ids of the regions intersected by the specified line.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The height is outside valid range. It should be in the range of [0, SampleHeight].

