---
kind: property
id: P:Autodesk.Revit.DB.SketchPlane.IsSuitableForModelElements
source: html/6edfc06e-039d-940e-2b67-8d57e79757e8.htm
---
# Autodesk.Revit.DB.SketchPlane.IsSuitableForModelElements Property

Identifies if the sketch plane can be assigned to model elements.

## Syntax (C#)
```csharp
public bool IsSuitableForModelElements { get; }
```

## Remarks
Sketch planes with this property set to true are suitable to be used to create model elements. Planes where this property is false will be rejected when used to create model curves, symbolic curves, generic forms, or other sketched elements.

