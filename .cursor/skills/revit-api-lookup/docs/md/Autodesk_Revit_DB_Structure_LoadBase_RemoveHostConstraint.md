---
kind: method
id: M:Autodesk.Revit.DB.Structure.LoadBase.RemoveHostConstraint
source: html/f94ac73c-c975-70e5-f905-966439f5163a.htm
---
# Autodesk.Revit.DB.Structure.LoadBase.RemoveHostConstraint Method

Removes constraint from host for this load.

## Syntax (C#)
```csharp
public void RemoveHostConstraint()
```

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This LoadBase is not a constraint load.
- **Autodesk.Revit.Exceptions.ModificationForbiddenException** - Thrown when the load is an AreaLoad and the host is an Analytical Panel with curved profile.

