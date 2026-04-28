---
kind: method
id: M:Autodesk.Revit.DB.DirectContext3D.EffectInstance.IsValid
source: html/1303d1fd-6b1b-e3f0-c412-4b65cceb3aa1.htm
---
# Autodesk.Revit.DB.DirectContext3D.EffectInstance.IsValid Method

Tests whether the effect instance is valid for rendering.

## Syntax (C#)
```csharp
public bool IsValid()
```

## Returns
True if the effect instance is valid for rendering, false otherwise.

## Remarks
The effect instances are internally associated with low-level graphics state and may become invalidated when
 the state changes. Therefore, an application should test each effect instance for validity before using it when
 submitting geometry. If the effect instance becomes invalid, the application should re-create it.

