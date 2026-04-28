---
kind: method
id: M:Autodesk.Revit.DB.CompoundStructure.GetRegionEnvelope(System.Int32)
source: html/ab2f1bd3-bd9b-5f73-4a0d-0af599bcc173.htm
---
# Autodesk.Revit.DB.CompoundStructure.GetRegionEnvelope Method

Gets the envelope that a specified region spans.

## Syntax (C#)
```csharp
public BoundingBoxUV GetRegionEnvelope(
	int regionId
)
```

## Parameters
- **regionId** (`System.Int32`) - The id of the region.

## Returns
The envelope of the region.

## Remarks
This envelope indicates the external boundary of the region. The
 coordinate system it defines is used in the results of GetSegmentCoordinate().

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - It is not a valid region id.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This operation is valid only for vertically compound structures.

