---
kind: method
id: M:Autodesk.Revit.DB.Visual.AssetProperty.AddConnectedAsset(System.String)
source: html/bb4fdff5-a1b3-c215-c8ac-c1e6abaaea69.htm
---
# Autodesk.Revit.DB.Visual.AssetProperty.AddConnectedAsset Method

Adds a new connected asset attached to this asset property, if it allows it.

## Syntax (C#)
```csharp
public void AddConnectedAsset(
	string schema
)
```

## Parameters
- **schema** (`System.String`) - The schema name.

## Remarks
Cannot add a connected asset if one is already connected.
 Use RemoveConnectedAsset() to avoid an exception being thrown.
 A new preset asset is created and connected to the property.
 For "UnifiedBitmap", it contains an empty property unifiedbitmap_Bitmap.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The schema name is not valid.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The asset property is not editable.
 -or-
 Cannot check validity for a property not being edited in AppearanceAssetEditScope.
 -or-
 Asset property is already connected to one asset.

