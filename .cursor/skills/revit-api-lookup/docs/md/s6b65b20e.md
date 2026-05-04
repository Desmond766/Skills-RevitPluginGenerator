---
kind: method
id: M:Autodesk.Revit.DB.AppearanceAssetElement.GetRenderingAsset
source: html/fdf7c733-319d-d355-3dc5-4c776b8ba9e5.htm
---
# Autodesk.Revit.DB.AppearanceAssetElement.GetRenderingAsset Method

Gets the rendering asset for the appearance asset element.

## Syntax (C#)
```csharp
public Asset GetRenderingAsset()
```

## Returns
The rendering asset held by this appearance asset element.

## Remarks
The retrieved Asset may be empty if it is loaded from material library without any modification.
 In this case, you can use Application.GetAssets(AssetType.Appearance) to load all preset appearance assets, and retrieve the asset by its name.

