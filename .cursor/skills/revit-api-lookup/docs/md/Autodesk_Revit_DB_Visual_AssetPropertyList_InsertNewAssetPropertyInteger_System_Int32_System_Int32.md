---
kind: method
id: M:Autodesk.Revit.DB.Visual.AssetPropertyList.InsertNewAssetPropertyInteger(System.Int32,System.Int32)
source: html/bb7e373c-5d1d-5b8a-a92a-0b343548d7c1.htm
---
# Autodesk.Revit.DB.Visual.AssetPropertyList.InsertNewAssetPropertyInteger Method

Insert a new AssetPropertyInteger containing the input value to this list.

## Syntax (C#)
```csharp
public void InsertNewAssetPropertyInteger(
	int value,
	int index
)
```

## Parameters
- **value** (`System.Int32`) - The integer value to insert.
- **index** (`System.Int32`) - An integer index.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - index is out of range.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The asset property is not editable.

