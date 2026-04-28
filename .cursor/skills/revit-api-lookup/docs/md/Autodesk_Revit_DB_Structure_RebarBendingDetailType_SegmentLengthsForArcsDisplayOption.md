---
kind: property
id: P:Autodesk.Revit.DB.Structure.RebarBendingDetailType.SegmentLengthsForArcsDisplayOption
source: html/44c6e740-4983-648e-e201-25a7013c658a.htm
---
# Autodesk.Revit.DB.Structure.RebarBendingDetailType.SegmentLengthsForArcsDisplayOption Property

Identifies if the arc segment lengths are represented using dimensions or just as text.
 Only RebarShapes whose definition is RebarShapeDefinitionByArc are considered that have arc segments.

## Syntax (C#)
```csharp
public BendingDetailSegmentLengthsDisplayOptions SegmentLengthsForArcsDisplayOption { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: A value passed for an enumeration argument is not a member of that enumeration

