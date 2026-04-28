---
kind: method
id: M:Autodesk.Revit.DB.Visual.AssetPropertyList.RemoveAssetProperty(System.Int32)
source: html/27891835-e0df-098f-d8aa-2f9f98f2efe8.htm
---
# Autodesk.Revit.DB.Visual.AssetPropertyList.RemoveAssetProperty Method

Remove the AssetProperty from the list.

## Syntax (C#)
```csharp
public void RemoveAssetProperty(
	int index
)
```

## Parameters
- **index** (`System.Int32`) - Index to remove the AssetProperty from.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - index is out of range.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The asset property is not editable.

