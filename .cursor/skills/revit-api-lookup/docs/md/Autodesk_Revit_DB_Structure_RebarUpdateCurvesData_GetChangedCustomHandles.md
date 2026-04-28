---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarUpdateCurvesData.GetChangedCustomHandles
source: html/5e52f5fb-0160-7bde-c9cc-c654129984f6.htm
---
# Autodesk.Revit.DB.Structure.RebarUpdateCurvesData.GetChangedCustomHandles Method

Returns an array containing custom handles that were changed since the last regeneration.
 Array is empty if no handles were changed since the last regeneration.

## Syntax (C#)
```csharp
public IList<int> GetChangedCustomHandles()
```

## Returns
Returns an array containing the tags of custom handles that were changed since the last regeneration.

