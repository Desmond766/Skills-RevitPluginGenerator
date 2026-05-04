---
kind: method
id: M:Autodesk.Revit.DB.Visual.AssetPropertyList.InsertNewAssetAsColor(Autodesk.Revit.DB.Color,System.Int32)
source: html/4106b999-e3c2-eefa-fe82-8ddf5c661f95.htm
---
# Autodesk.Revit.DB.Visual.AssetPropertyList.InsertNewAssetAsColor Method

Insert a new AssetPropertyDouble4 containing the input value to this list.

## Syntax (C#)
```csharp
public void InsertNewAssetAsColor(
	Color value,
	int index
)
```

## Parameters
- **value** (`Autodesk.Revit.DB.Color`) - The color value to insert.
- **index** (`System.Int32`) - An integer index.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - index is out of range.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The asset property is not editable.

