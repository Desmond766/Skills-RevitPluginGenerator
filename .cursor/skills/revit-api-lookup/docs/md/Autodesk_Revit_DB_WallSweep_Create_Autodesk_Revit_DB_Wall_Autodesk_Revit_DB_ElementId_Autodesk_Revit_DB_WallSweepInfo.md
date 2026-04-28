---
kind: method
id: M:Autodesk.Revit.DB.WallSweep.Create(Autodesk.Revit.DB.Wall,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.WallSweepInfo)
zh: 创建、新建、生成、建立、新增
source: html/7df3ded1-396f-c394-6aec-10bf64c152a2.htm
---
# Autodesk.Revit.DB.WallSweep.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates a new wall sweep or reveal.

## Syntax (C#)
```csharp
public static WallSweep Create(
	Wall wall,
	ElementId wallSweepType,
	WallSweepInfo wallSweepInfo
)
```

## Parameters
- **wall** (`Autodesk.Revit.DB.Wall`) - The wall upon which to create the new sweep or reveal.
- **wallSweepType** (`Autodesk.Revit.DB.ElementId`) - The wall sweep or reveal type.
- **wallSweepInfo** (`Autodesk.Revit.DB.WallSweepInfo`) - The information that describes the new wall sweep or reveal.

## Returns
The new wall sweep.

## Remarks
The wall sweep's profile and type are taken from the wall sweep type properties. The
 values set in the WallSweepInfo are ignored.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The wall sweep info represents a fixed wall sweep. Fixed wall sweeps may not be assigned to standalone wall sweep elements.
 -or-
 The WallSweepInfo id must be set to -1 for a non-fixed wall sweep.
 -or-
 wall may not host a wall sweep or reveal.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

