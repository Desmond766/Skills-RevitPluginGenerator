---
kind: property
id: P:Autodesk.Revit.DB.Family.IsEditable
zh: 族
source: html/d7d3ef05-d2bd-b770-47df-96b7fd280f9f.htm
---
# Autodesk.Revit.DB.Family.IsEditable Property

**中文**: 族

True if the family supports editing, false otherwise.

## Syntax (C#)
```csharp
public bool IsEditable { get; }
```

## Remarks
The family will not be editable if it is in-place, not saveable, or represents the primary family inside a family document.

