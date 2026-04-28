---
kind: method
id: M:Autodesk.Revit.DB.CompoundStructure.GetSegmentEndPoints(System.Int32,System.Int32,Autodesk.Revit.DB.UV@,Autodesk.Revit.DB.UV@)
source: html/4e6f1ee9-53cf-15fd-0e6e-f684941f107a.htm
---
# Autodesk.Revit.DB.CompoundStructure.GetSegmentEndPoints Method

Gets the end points of a segment.

## Syntax (C#)
```csharp
public void GetSegmentEndPoints(
	int segmentId,
	int regionId,
	out UV end1,
	out UV end2
)
```

## Parameters
- **segmentId** (`System.Int32`) - The segment id.
- **regionId** (`System.Int32`) - The region id.
- **end1** (`Autodesk.Revit.DB.UV %`) - One end point.
- **end2** (`Autodesk.Revit.DB.UV %`) - The other end point.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The segment id is invalid.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This operation is valid only for vertically compound structures.

