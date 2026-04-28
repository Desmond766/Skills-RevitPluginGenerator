---
kind: method
id: M:Autodesk.Revit.DB.Visual.AssetPropertyFloat.IsValidValue(System.Single)
source: html/f7204a19-39a1-3c07-eea2-3e0bea2d017a.htm
---
# Autodesk.Revit.DB.Visual.AssetPropertyFloat.IsValidValue Method

Checks that the value is a valid value for this property.

## Syntax (C#)
```csharp
public bool IsValidValue(
	float value
)
```

## Parameters
- **value** (`System.Single`) - The value to be checked.

## Returns
True if the value is valid for the property.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Cannot check validity for a property not being edited in AppearanceAssetEditScope.

