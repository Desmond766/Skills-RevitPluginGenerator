---
kind: method
id: M:Autodesk.Revit.DB.Visual.AssetProperty.GetSingleConnectedAsset
source: html/3a190829-9269-0e56-8b9b-a53b89de35a6.htm
---
# Autodesk.Revit.DB.Visual.AssetProperty.GetSingleConnectedAsset Method

Gets the single connected asset attached to this asset property, if it exists.

## Syntax (C#)
```csharp
public Asset GetSingleConnectedAsset()
```

## Returns
The connected asset, or Nothing nullptr a null reference ( Nothing in Visual Basic) if there is no connected asset.

## Remarks
Throws if there is more than one connected asset.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Asset is connected to more than one asset.

