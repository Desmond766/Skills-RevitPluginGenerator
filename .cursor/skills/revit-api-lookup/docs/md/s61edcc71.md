---
kind: method
id: M:Autodesk.Revit.DB.Lighting.LightFamily.GetLightSourceTransform
source: html/f8f1034e-a53a-92cf-1569-b5e3ea942840.htm
---
# Autodesk.Revit.DB.Lighting.LightFamily.GetLightSourceTransform Method

Returns a Transform value for the transform of light source.

## Syntax (C#)
```csharp
public Transform GetLightSourceTransform()
```

## Returns
The light source transform.

## Remarks
When the user moves or rotates the light source in family editor,
 the returned Transform gets changed accordingly.

