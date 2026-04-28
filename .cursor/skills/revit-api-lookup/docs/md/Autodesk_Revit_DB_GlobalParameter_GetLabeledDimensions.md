---
kind: method
id: M:Autodesk.Revit.DB.GlobalParameter.GetLabeledDimensions
source: html/97d29291-74c4-2da5-2ac5-2fa0c0ac9d0c.htm
---
# Autodesk.Revit.DB.GlobalParameter.GetLabeledDimensions Method

Returns all dimension elements that are currently labeled by this global parameter.

## Syntax (C#)
```csharp
public ISet<ElementId> GetLabeledDimensions()
```

## Returns
Collection of Element Ids.

## Remarks
In case of a reporting parameter the returned collection will contain
 at most one element - the driving dimension, if it has been set already.
 It is because reporting parameters may have only one dimension labeled.
 For non-reporting parameters the set would contain all dimensions that
 have been labeled by this global parameter.

