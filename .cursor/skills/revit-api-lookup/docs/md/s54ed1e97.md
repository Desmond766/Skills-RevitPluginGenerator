---
kind: property
id: P:Autodesk.Revit.DB.Parameter.UserModifiable
zh: 参数、共享参数
source: html/99e14a83-f976-2465-6464-ed3f8a159000.htm
---
# Autodesk.Revit.DB.Parameter.UserModifiable Property

**中文**: 参数、共享参数

Indicates whether the interactive user can modify the value of this parameter.

## Syntax (C#)
```csharp
public bool UserModifiable { get; }
```

## Remarks
Note that for shared parameters IsReadOnly can return false for shared parameters whose UserModifiable property is 
also false, because the value of those parameters can be modified by the API. If a parameter is governed by a formula, 
IsReadOnly would return true, even if the flag for UserModifiable was set to true when the shared parameter was created.

