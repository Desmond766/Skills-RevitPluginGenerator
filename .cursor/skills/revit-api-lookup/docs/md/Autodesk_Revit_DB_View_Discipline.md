---
kind: property
id: P:Autodesk.Revit.DB.View.Discipline
zh: 视图
source: html/3137c4a8-cd2d-82e0-d602-6552185283c9.htm
---
# Autodesk.Revit.DB.View.Discipline Property

**中文**: 视图

The Discipline of the view.

## Syntax (C#)
```csharp
public ViewDiscipline Discipline { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: A value passed for an enumeration argument is not a member of that enumeration
- **Autodesk.Revit.Exceptions.InvalidOperationException** - View must have a Discipline property
 -or-
 When setting this property: View Discipline must be modifiable.

