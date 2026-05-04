---
kind: method
id: M:Autodesk.Revit.DB.MaterialNode.GetAppearanceOverride
source: html/550190e7-9d66-fa2b-62d2-4c4eaa13fa64.htm
---
# Autodesk.Revit.DB.MaterialNode.GetAppearanceOverride Method

Returns appearance properties that override the preset appearance of the material.

## Syntax (C#)
```csharp
public Asset GetAppearanceOverride()
```

## Returns
An instance of a rendering material asset, of null if there is no override.

## Remarks
The returned instance of an Asset is valid only if there is an overide, which happens
 if there are decals applied to the face that has the base material. In such cases the
 rendering engine takes the asset of the material and merges it with the decal,
 which results to this override asset. If there are no decals, this instance is null
 and the HasOverriddenAppearance returns False.

