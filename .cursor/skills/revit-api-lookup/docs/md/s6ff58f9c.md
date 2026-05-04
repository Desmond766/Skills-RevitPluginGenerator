---
kind: method
id: M:Autodesk.Revit.DB.CompoundStructure.SetExtendableRegionIds(System.Boolean,System.Collections.Generic.IList{System.Int32})
source: html/2d4b6163-0425-9c97-3d17-1087243e4cc5.htm
---
# Autodesk.Revit.DB.CompoundStructure.SetExtendableRegionIds Method

Sets the extendable region ids for the compound structure.

## Syntax (C#)
```csharp
public void SetExtendableRegionIds(
	bool top,
	IList<int> regionIds
)
```

## Parameters
- **top** (`System.Boolean`) - If true, set ids of regions which are extendable at the top, otherwise
 set the ids of regions which are extendable at the bottom.
- **regionIds** (`System.Collections.Generic.IList < Int32 >`) - The ids of regions which will be extendable.

## Remarks
Regions along the top or bottom of the wall may be set to be extendable.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The region ids are not valid.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This operation is valid only for vertically compound structures.

