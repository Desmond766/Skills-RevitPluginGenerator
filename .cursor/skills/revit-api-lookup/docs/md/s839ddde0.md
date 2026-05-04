---
kind: method
id: M:Autodesk.Revit.DB.AppearanceAssetElement.SetRenderingAsset(Autodesk.Revit.DB.Visual.Asset)
source: html/a10fc05d-e6e5-0827-45bb-e5d0c314e5c8.htm
---
# Autodesk.Revit.DB.AppearanceAssetElement.SetRenderingAsset Method

Sets the rendering asset for the appearance asset element.

## Syntax (C#)
```csharp
public void SetRenderingAsset(
	Asset asset
)
```

## Parameters
- **asset** (`Autodesk.Revit.DB.Visual.Asset`) - The new rendering asset. It should be an appearance asset.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - The asset is not an appearance asset.

