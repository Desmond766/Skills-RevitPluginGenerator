---
kind: property
id: P:Autodesk.Revit.DB.View.DetailLevel
zh: 视图
source: html/a4e9896a-606e-8b97-c8a7-a8397419145e.htm
---
# Autodesk.Revit.DB.View.DetailLevel Property

**中文**: 视图

The detail level of this view.

## Syntax (C#)
```csharp
public ViewDetailLevel DetailLevel { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: Cannot set ViewDetailLevel to Unassigned
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: A value passed for an enumeration argument is not a member of that enumeration
- **Autodesk.Revit.Exceptions.InvalidOperationException** - When setting this property: View does not have a Detail Level property
 -or-
 When setting this property: Detail Level cannot be modified.

