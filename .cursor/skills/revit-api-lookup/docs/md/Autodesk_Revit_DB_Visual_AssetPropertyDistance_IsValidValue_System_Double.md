---
kind: method
id: M:Autodesk.Revit.DB.Visual.AssetPropertyDistance.IsValidValue(System.Double)
source: html/346a4b68-b6a0-ca70-37b9-53e8a50fe00c.htm
---
# Autodesk.Revit.DB.Visual.AssetPropertyDistance.IsValidValue Method

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

