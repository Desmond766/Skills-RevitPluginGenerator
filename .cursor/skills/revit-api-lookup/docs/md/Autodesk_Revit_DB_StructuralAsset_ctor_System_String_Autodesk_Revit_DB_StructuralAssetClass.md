---
kind: method
id: M:Autodesk.Revit.DB.StructuralAsset.#ctor(System.String,Autodesk.Revit.DB.StructuralAssetClass)
source: html/6f292dff-6ea1-b440-f20a-76790fbc6119.htm
---
# Autodesk.Revit.DB.StructuralAsset.#ctor Method

Constructs an instance of StructuralAsset.

## Syntax (C#)
```csharp
public StructuralAsset(
	string name,
	StructuralAssetClass structuralAssetClass
)
```

## Parameters
- **name** (`System.String`) - The name of the asset.
- **structuralAssetClass** (`Autodesk.Revit.DB.StructuralAssetClass`) - The type of structural material that this asset will describe.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

