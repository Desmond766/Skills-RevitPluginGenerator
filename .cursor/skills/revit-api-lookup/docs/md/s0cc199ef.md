---
kind: property
id: P:Autodesk.Revit.DB.Structure.RebarShapeDefinitionBySegments.MajorSegmentIndex
source: html/fd0d677f-aad6-cb00-1b8f-9bd05a6f3dc6.htm
---
# Autodesk.Revit.DB.Structure.RebarShapeDefinitionBySegments.MajorSegmentIndex Property

Index of a segment that can be considered the most important. Revit
 attempts to preserve the orientation of this segment when a Rebar instance
 changes its RebarShape to one with a different number of segments.

## Syntax (C#)
```csharp
public int MajorSegmentIndex { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: majorSegmentIndex is not between 0 and NumberOfSegments.

