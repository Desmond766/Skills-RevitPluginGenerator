---
kind: property
id: P:Autodesk.Revit.DB.FamilyParameter.UserModifiable
source: html/f2748518-3b1b-91d1-abdb-d20ccf3a8b18.htm
---
# Autodesk.Revit.DB.FamilyParameter.UserModifiable Property

Indicates whether the interactive user can modify the value of this parameter.

## Syntax (C#)
```csharp
public bool UserModifiable { get; }
```

## Remarks
Note that for shared parameters IsReadOnly can return false for shared parameters whose UserModifiable property is 
also false, because the value of those parameters can be modified by the API. If a parameter is governed by a formula, 
IsReadOnly would return true, even if the flag for UserModifiable was set to true when the shared parameter was created.

