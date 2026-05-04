---
kind: property
id: P:Autodesk.Revit.DB.Structure.LineLoad.IsProjected
source: html/482ec1fe-b5f4-75fb-2f17-440a6170aa37.htm
---
# Autodesk.Revit.DB.Structure.LineLoad.IsProjected Property

Indicates if the load is projected.

## Syntax (C#)
```csharp
public bool IsProjected { get; set; }
```

## Remarks
Returns true if the line load is projected, false otherwise.
 This parameter will take effect only if LineLoad.OrientTo property is set to LoadOrientTo.Project.

