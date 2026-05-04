---
kind: method
id: M:Autodesk.Revit.DB.CompoundStructure.GetSimpleCompoundStructure(System.Double,System.Double)
source: html/9c3b9719-8d01-4db3-4cb1-69a8a70f37ac.htm
---
# Autodesk.Revit.DB.CompoundStructure.GetSimpleCompoundStructure Method

Takes a horizontal slice through a sample wall to which this CompoundStructure is applied
 and returns a simple compound structure which describes that slice, i.e. a series of
 parallel layers.

## Syntax (C#)
```csharp
public CompoundStructure GetSimpleCompoundStructure(
	double wallHeight,
	double distAboveBase
)
```

## Parameters
- **wallHeight** (`System.Double`) - The height of the wall.
- **distAboveBase** (`System.Double`) - The distance from the base of the wall at which to take the section.
 If distAboveBase < 0, then internally distAboveBase = 0 is used.
 If distAboveBase > wallHeight, then internally distAboveBase = wallHeight is used.

## Returns
A simple CompoundStructure representing a series of parallel layers.

## Remarks
If IsVerticallyCompound is false, the output is a copy of this CompoundStructure.

