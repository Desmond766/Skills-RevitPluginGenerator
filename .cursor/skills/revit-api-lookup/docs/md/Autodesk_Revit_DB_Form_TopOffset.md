---
kind: property
id: P:Autodesk.Revit.DB.Form.TopOffset
zh: 对话框、窗口、窗体
source: html/338aee66-8550-80b2-7782-534b8c87a7e4.htm
---
# Autodesk.Revit.DB.Form.TopOffset Property

**中文**: 对话框、窗口、窗体

Retrieve/set the top offset of the form object. It is only valid for locked form.

## Syntax (C#)
```csharp
public double TopOffset { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when this is not a locked form.
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when the value is invalid.
- **Autodesk.Revit.Exceptions.ApplicationException** - Thrown when it fail to get/set TopOffset.

