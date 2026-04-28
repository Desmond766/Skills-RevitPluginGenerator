---
kind: method
id: M:Autodesk.Revit.DB.ViewSheetSetting.Rename(System.String)
zh: 重命名
source: html/5c5f1d32-0df7-6c62-edb2-31758a0654f0.htm
---
# Autodesk.Revit.DB.ViewSheetSetting.Rename Method

**中文**: 重命名

Rename the current view sheet set.

## Syntax (C#)
```csharp
public bool Rename(
	string newName
)
```

## Parameters
- **newName** (`System.String`) - View sheet set name to be renamed as.

## Returns
False if Rename operation fails, otherwise True.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when the input name is already existed in current view sheet set list.

