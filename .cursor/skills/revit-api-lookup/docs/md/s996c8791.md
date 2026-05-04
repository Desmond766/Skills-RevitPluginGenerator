---
kind: method
id: M:Autodesk.Revit.DB.Visual.AssetPropertyDoubleArray4d.IsValidValue(Autodesk.Revit.DB.Color)
source: html/fe8cef50-42ec-7735-4660-3ba5a3dd6d82.htm
---
# Autodesk.Revit.DB.Visual.AssetPropertyDoubleArray4d.IsValidValue Method

Checks that the value is a valid value for this property.

## Syntax (C#)
```csharp
public bool IsValidValue(
	Color color
)
```

## Parameters
- **color** (`Autodesk.Revit.DB.Color`) - The value to be checked.

## Returns
True if the value is valid for the property.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Cannot check validity for a property not being edited in AppearanceAssetEditScope.

