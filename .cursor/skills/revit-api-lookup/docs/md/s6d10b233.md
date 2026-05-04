---
kind: property
id: P:Autodesk.Revit.DB.Dimension.Origin
zh: 原点
source: html/df8b9dc6-9d36-ac2b-04cf-816d88f039b8.htm
---
# Autodesk.Revit.DB.Dimension.Origin Property

**中文**: 原点

The dimension origin.

## Syntax (C#)
```csharp
public XYZ Origin { get; }
```

## Remarks
The origin is the middle point of the dimension line that makes up the dimension.
 This property is for use with single-segment dimensions only.
 For multi-segment dimensions use the corresponding property of the
 DimensionSegment class.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when:
 SpotDimension has more than one segments.

