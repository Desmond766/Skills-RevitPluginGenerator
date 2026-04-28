---
kind: property
id: P:Autodesk.Revit.DB.View.DisplayStyle
zh: 视图
source: html/cb080c50-c86f-80e9-7706-d5998d122b3a.htm
---
# Autodesk.Revit.DB.View.DisplayStyle Property

**中文**: 视图

The DisplayStyle of the view.
 Returns DisplayStyle.Wireframe if the view has no display style.

## Syntax (C#)
```csharp
public DisplayStyle DisplayStyle { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: DisplayStyle cannot be set to Undefined.
 -or-
 When setting this property: DisplayStyle of Drafting Views can be set only to Wireframe or HLR
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: A value passed for an enumeration argument is not a member of that enumeration
- **Autodesk.Revit.Exceptions.InvalidOperationException** - When setting this property: DisplayStyle cannot be modified.
 -or-
 When setting this property: This view does not contain display-related properties.

