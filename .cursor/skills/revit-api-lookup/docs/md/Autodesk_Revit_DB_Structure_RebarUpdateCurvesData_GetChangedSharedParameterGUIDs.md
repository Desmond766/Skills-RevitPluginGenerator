---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarUpdateCurvesData.GetChangedSharedParameterGUIDs
source: html/52f33c35-c8b3-0fce-7f05-5a6280e44a93.htm
---
# Autodesk.Revit.DB.Structure.RebarUpdateCurvesData.GetChangedSharedParameterGUIDs Method

Returns an array containing the shared parameter GUIDs that were changed since the last regeneration.
 Array is empty if no shared params were changed since the last regeneration.

## Syntax (C#)
```csharp
public IList<Guid> GetChangedSharedParameterGUIDs()
```

## Returns
Returns an array containing the elementId of the shared params that were changed since the last regeneration.

