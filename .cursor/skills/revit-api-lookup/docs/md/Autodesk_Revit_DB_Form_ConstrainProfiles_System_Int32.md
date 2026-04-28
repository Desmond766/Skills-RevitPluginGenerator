---
kind: method
id: M:Autodesk.Revit.DB.Form.ConstrainProfiles(System.Int32)
zh: 对话框、窗口、窗体
source: html/6912f3a9-e563-60d3-09dd-89919583481c.htm
---
# Autodesk.Revit.DB.Form.ConstrainProfiles Method

**中文**: 对话框、窗口、窗体

Constrain form profiles using the specified profile as primary. This is an advanced version of property "AreProfilesConstrained", allowing specify the primary profile.

## Syntax (C#)
```csharp
public void ConstrainProfiles(
	int primaryProfileIndex
)
```

## Parameters
- **primaryProfileIndex** (`System.Int32`) - Index to specify the profile used as primary profile.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This operation can only be performed on a swept blend form.

