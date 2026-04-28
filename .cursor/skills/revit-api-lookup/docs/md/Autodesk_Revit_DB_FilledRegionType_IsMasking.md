---
kind: property
id: P:Autodesk.Revit.DB.FilledRegionType.IsMasking
source: html/fd52beff-fc1d-ff30-3e60-454a1d863a44.htm
---
# Autodesk.Revit.DB.FilledRegionType.IsMasking Property

If true then the FilledRegion will cover the lines and edges of objects behind it.
 If false then lines and edges will remain visible.

## Syntax (C#)
```csharp
public bool IsMasking { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: In a family a FilledRegionType with a solid fill pattern isMasking must always be true.

