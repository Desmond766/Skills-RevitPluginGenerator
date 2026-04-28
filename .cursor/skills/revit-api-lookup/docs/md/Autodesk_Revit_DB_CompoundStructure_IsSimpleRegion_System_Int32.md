---
kind: method
id: M:Autodesk.Revit.DB.CompoundStructure.IsSimpleRegion(System.Int32)
source: html/49160dba-ba08-a7e8-5b99-770d33a8e325.htm
---
# Autodesk.Revit.DB.CompoundStructure.IsSimpleRegion Method

Determines whether the region is a simple region in this CompoundStructure.

## Syntax (C#)
```csharp
public bool IsSimpleRegion(
	int regionId
)
```

## Parameters
- **regionId** (`System.Int32`) - The id of a region in this vertically compound structure.

## Returns
True if the region is simple, false otherwise.

## Remarks
A region is simple if it rectangular and spans the height of the wall.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - It is not a valid region id.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This operation is valid only for vertically compound structures.

