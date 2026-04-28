---
kind: property
id: P:Autodesk.Revit.DB.Family.IsUserCreated
zh: 族
source: html/074099dc-3e29-1a4b-1768-2e59f865cf10.htm
---
# Autodesk.Revit.DB.Family.IsUserCreated Property

**中文**: 族

Determine whether the family has been defined by the user.

## Syntax (C#)
```csharp
public bool IsUserCreated { get; }
```

## Remarks
Some families are created internally and cannot be saved or reloaded.
 This function will return False for such internal families.

