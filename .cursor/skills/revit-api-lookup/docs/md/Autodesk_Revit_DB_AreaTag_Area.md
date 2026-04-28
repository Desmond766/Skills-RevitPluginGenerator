---
kind: property
id: P:Autodesk.Revit.DB.AreaTag.Area
zh: 面积区域
source: html/16888d1b-a66b-e379-b3f4-2cf62425494d.htm
---
# Autodesk.Revit.DB.AreaTag.Area Property

**中文**: 面积区域

The area that the tag is associated with.

## Syntax (C#)
```csharp
public Area Area { get; }
```

## Remarks
In rare cases, the tag may not be associated to an area. The property will
be Nothing nullptr a null reference ( Nothing in Visual Basic) in these situations.

