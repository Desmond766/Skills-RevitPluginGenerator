---
kind: method
id: M:Autodesk.Revit.DB.CompoundStructure.GetWidth(System.Int32)
source: html/668c8be8-3a70-9362-29ae-7fdc07988394.htm
---
# Autodesk.Revit.DB.CompoundStructure.GetWidth Method

Computes the width of the envelope (2d bounding box) of the specified region.

## Syntax (C#)
```csharp
public double GetWidth(
	int regionId
)
```

## Parameters
- **regionId** (`System.Int32`) - The id of a region in this vertically compound structure.

## Returns
The width of the envelope (2d bounding box) of the region.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - It is not a valid region id.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This operation is valid only for vertically compound structures.

