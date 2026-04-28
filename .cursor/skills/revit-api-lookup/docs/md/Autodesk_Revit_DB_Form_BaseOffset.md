---
kind: property
id: P:Autodesk.Revit.DB.Form.BaseOffset
zh: 对话框、窗口、窗体
source: html/d8bcb330-b182-4e67-ed96-2656afa5ee7b.htm
---
# Autodesk.Revit.DB.Form.BaseOffset Property

**中文**: 对话框、窗口、窗体

Retrieve/set the base offset of the form object. It is only valid for locked form.

## Syntax (C#)
```csharp
public double BaseOffset { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when this is not a locked form.
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when the value is invalid.
- **Autodesk.Revit.Exceptions.ApplicationException** - Thrown when it fail to get/set BaseOffset.

