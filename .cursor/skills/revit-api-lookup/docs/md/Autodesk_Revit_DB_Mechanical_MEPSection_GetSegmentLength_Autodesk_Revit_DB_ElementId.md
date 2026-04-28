---
kind: method
id: M:Autodesk.Revit.DB.Mechanical.MEPSection.GetSegmentLength(Autodesk.Revit.DB.ElementId)
source: html/162a98dd-114f-4a5a-bd02-ca9ae2c937fe.htm
---
# Autodesk.Revit.DB.Mechanical.MEPSection.GetSegmentLength Method

Get the length for the specified segment id in this section.

## Syntax (C#)
```csharp
public double GetSegmentLength(
	ElementId segmentId
)
```

## Parameters
- **segmentId** (`Autodesk.Revit.DB.ElementId`) - The element id which can be duct segment and pipe segment.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The ElementId segmentId does not correspond to a valid section segment member.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

