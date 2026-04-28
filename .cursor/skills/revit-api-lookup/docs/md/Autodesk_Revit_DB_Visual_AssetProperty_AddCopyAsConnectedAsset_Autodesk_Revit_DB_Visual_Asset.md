---
kind: method
id: M:Autodesk.Revit.DB.Visual.AssetProperty.AddCopyAsConnectedAsset(Autodesk.Revit.DB.Visual.Asset)
source: html/dce50799-b956-e3f9-86c2-e67aaf78c69c.htm
---
# Autodesk.Revit.DB.Visual.AssetProperty.AddCopyAsConnectedAsset Method

Makes a copy of the asset and connects it to this property.

## Syntax (C#)
```csharp
public void AddCopyAsConnectedAsset(
	Asset pRenderingAsset
)
```

## Parameters
- **pRenderingAsset** (`Autodesk.Revit.DB.Visual.Asset`) - The asset to duplicate and associate with this property as a connected asset.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The asset property is not editable.
 -or-
 Cannot check validity for a property not being edited in AppearanceAssetEditScope.
 -or-
 Asset property is already connected to one asset.

