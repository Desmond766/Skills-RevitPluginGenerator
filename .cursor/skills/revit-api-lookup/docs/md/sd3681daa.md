---
kind: method
id: M:Autodesk.Revit.DB.CompoundStructure.IsValidSegmentId(System.Int32)
source: html/680bccec-130e-238e-4b41-bbbcac24fdb8.htm
---
# Autodesk.Revit.DB.CompoundStructure.IsValidSegmentId Method

Determines whether the specified integer is actually the id of a segment in this CompoundStructure.

## Syntax (C#)
```csharp
public bool IsValidSegmentId(
	int segmentId
)
```

## Parameters
- **segmentId** (`System.Int32`) - The id of a segment in this CompoundStructure.

## Returns
True if the specified segment is valid, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This operation is valid only for vertically compound structures.

