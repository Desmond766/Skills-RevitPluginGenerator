---
kind: property
id: P:Autodesk.Revit.DB.Structure.BendingDetailCustomFieldProperties.SegmentLengthsForArcsDisplayOption
source: html/cd040975-377e-9c8a-19a0-190f93d1b5ba.htm
---
# Autodesk.Revit.DB.Structure.BendingDetailCustomFieldProperties.SegmentLengthsForArcsDisplayOption Property

Identifies if the arc segment lengths are represented using dimensions or just as text.
 Only RebarShapes whose definition is RebarShapeDefinitionByArc are considered that have arc segments.

## Syntax (C#)
```csharp
public BendingDetailSegmentLengthsDisplayOptions SegmentLengthsForArcsDisplayOption { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: A value passed for an enumeration argument is not a member of that enumeration

