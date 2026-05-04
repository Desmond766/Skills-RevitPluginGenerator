---
kind: method
id: M:Autodesk.Revit.DB.Visual.AssetPropertyInteger.IsValidValue(System.Int32)
source: html/737b2e8b-855f-1964-8db4-69c1f42e2c1f.htm
---
# Autodesk.Revit.DB.Visual.AssetPropertyInteger.IsValidValue Method

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

