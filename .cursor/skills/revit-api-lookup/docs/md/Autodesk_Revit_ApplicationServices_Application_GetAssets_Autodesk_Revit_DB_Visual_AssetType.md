---
kind: method
id: M:Autodesk.Revit.ApplicationServices.Application.GetAssets(Autodesk.Revit.DB.Visual.AssetType)
source: html/61c6b555-8a43-69a1-16d8-43ab26cb4d28.htm
---
# Autodesk.Revit.ApplicationServices.Application.GetAssets Method

Gets all the Assets of the specified type.

## Syntax (C#)
```csharp
public IList<Asset> GetAssets(
	AssetType assetType
)
```

## Parameters
- **assetType** (`Autodesk.Revit.DB.Visual.AssetType`) - The asset type.

## Returns
Returns an array of all the Assets within Revit of the specified type.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

