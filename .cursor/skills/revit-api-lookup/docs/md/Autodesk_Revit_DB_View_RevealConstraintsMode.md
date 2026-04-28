---
kind: property
id: P:Autodesk.Revit.DB.View.RevealConstraintsMode
zh: 视图
source: html/595ac091-570c-6051-149e-f481ca829bca.htm
---
# Autodesk.Revit.DB.View.RevealConstraintsMode Property

**中文**: 视图

Indicates whether the Reveal Constraints mode is activated in the view.

## Syntax (C#)
```csharp
public bool RevealConstraintsMode { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - When setting this property: View has a view type that does not allow Reveal Constraints mode to be activated.

