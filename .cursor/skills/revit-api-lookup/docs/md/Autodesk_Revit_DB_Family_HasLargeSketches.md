---
kind: method
id: M:Autodesk.Revit.DB.Family.HasLargeSketches
zh: 族
source: html/c49820d6-d8f2-de9a-544d-f896a32e39c8.htm
---
# Autodesk.Revit.DB.Family.HasLargeSketches Method

**中文**: 族

Checks whether the family contains sketches with a large number of elements.

## Syntax (C#)
```csharp
public bool HasLargeSketches()
```

## Remarks
Families containing large sketches (typically with 300+ elements) may cause
 performance problems in parametric families (see IsParametric ).
 Thus, before adding any constraints to a family (which will make the family
 parametric,) this method can be queried and the decision about whether the
 family should indeed be turned parametric may be deferred to the end-user.

