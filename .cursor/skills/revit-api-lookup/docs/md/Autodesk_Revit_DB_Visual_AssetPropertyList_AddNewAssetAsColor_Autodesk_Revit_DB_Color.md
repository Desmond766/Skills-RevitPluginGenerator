---
kind: method
id: M:Autodesk.Revit.DB.Visual.AssetPropertyList.AddNewAssetAsColor(Autodesk.Revit.DB.Color)
source: html/c8a21c81-bcde-b82c-bf8a-de5c22182d76.htm
---
# Autodesk.Revit.DB.Visual.AssetPropertyList.AddNewAssetAsColor Method

Adds a new AssetPropertyDouble4 property to the list containing a value matching the input color.

## Syntax (C#)
```csharp
public void AddNewAssetAsColor(
	Color value
)
```

## Parameters
- **value** (`Autodesk.Revit.DB.Color`) - The color value to add.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The asset property is not editable.

