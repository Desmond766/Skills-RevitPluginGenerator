---
kind: method
id: M:Autodesk.Revit.DB.Visual.AssetPropertyList.InsertNewAssetPropertyDouble(System.Double,System.Int32)
source: html/cf8c55b5-957b-4b6e-6d52-4bd80626141a.htm
---
# Autodesk.Revit.DB.Visual.AssetPropertyList.InsertNewAssetPropertyDouble Method

Inserts a new AssetPropertyDouble containing the input value to this list.

## Syntax (C#)
```csharp
public void InsertNewAssetPropertyDouble(
	double value,
	int index
)
```

## Parameters
- **value** (`System.Double`) - The double value to insert.
- **index** (`System.Int32`) - An integer index.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - index is out of range.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The asset property is not editable.

