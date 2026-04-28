---
kind: method
id: M:Autodesk.Revit.DB.Instance.GetTotalTransform
source: html/8c8aff2b-5ff9-e43a-3b5c-308cd0174f1f.htm
---
# Autodesk.Revit.DB.Instance.GetTotalTransform Method

Gets the total transform, which includes the true north transform for instances like import instances.

## Syntax (C#)
```csharp
public Transform GetTotalTransform()
```

## Returns
The calculated total transform.

## Remarks
For most of other instances, it simply returns the inherent transform.

