---
kind: method
id: M:Autodesk.Revit.DB.Visual.AssetPropertyEnum.IsValidValue(System.Int32)
source: html/a078ee7d-9be4-9804-62e2-273f9f9ab9a3.htm
---
# Autodesk.Revit.DB.Visual.AssetPropertyEnum.IsValidValue Method

Checks that the value is a valid value for this property.

## Syntax (C#)
```csharp
public bool IsValidValue(
	int value
)
```

## Parameters
- **value** (`System.Int32`) - The value to be checked.

## Returns
True if the value is valid for the property.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Cannot check validity for a property not being edited in AppearanceAssetEditScope.

