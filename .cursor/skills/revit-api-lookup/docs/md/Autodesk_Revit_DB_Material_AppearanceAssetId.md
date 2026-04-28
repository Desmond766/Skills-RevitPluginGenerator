---
kind: property
id: P:Autodesk.Revit.DB.Material.AppearanceAssetId
zh: 材质、材料
source: html/d02d0677-341a-8d1a-d3eb-35ff82f01695.htm
---
# Autodesk.Revit.DB.Material.AppearanceAssetId Property

**中文**: 材质、材料

The ElementId of the AppearanceAssetElement.

## Syntax (C#)
```csharp
public ElementId AppearanceAssetId { get; set; }
```

## Remarks
This is the id to the element that contains visual material information used for rendering.
 In some cases where the material is created without setting up custom render appearance properties
 (for example, when the material is created via an import, or when it is created by the API),
 this property will be InvalidElementId. In that situation the standard material properties such as
 Color and Transparency will dictate the appearance of the material during rendering.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null

