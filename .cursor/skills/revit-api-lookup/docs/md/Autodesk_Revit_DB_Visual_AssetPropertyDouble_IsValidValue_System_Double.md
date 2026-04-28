---
kind: method
id: M:Autodesk.Revit.DB.Visual.AssetPropertyDouble.IsValidValue(System.Double)
source: html/df722fce-25a3-1c26-0f92-7982aeb27143.htm
---
# Autodesk.Revit.DB.Visual.AssetPropertyDouble.IsValidValue Method

Checks that the value is a valid value for this property.

## Syntax (C#)
```csharp
public bool IsValidValue(
	double value
)
```

## Parameters
- **value** (`System.Double`) - The value to be checked.

## Returns
True if the value is valid for the property.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Cannot check validity for a property not being edited in AppearanceAssetEditScope.

