---
kind: property
id: P:Autodesk.Revit.DB.Form.AreProfilesConstrained
zh: 对话框、窗口、窗体
source: html/2b231a7a-2cff-530d-4f7b-d51b2268362e.htm
---
# Autodesk.Revit.DB.Form.AreProfilesConstrained Property

**中文**: 对话框、窗口、窗体

Get/set if the form's profiles are constrained.

## Syntax (C#)
```csharp
public bool AreProfilesConstrained { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - When setting this property to 'true' 
 This operation can only be performed on a swept blend form.

