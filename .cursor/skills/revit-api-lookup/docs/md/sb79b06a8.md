---
kind: method
id: M:Autodesk.Revit.DB.Visual.AssetPropertyString.IsValidValue(System.String)
source: html/9a338de0-035d-83ce-2278-22d3be4da1cf.htm
---
# Autodesk.Revit.DB.Visual.AssetPropertyString.IsValidValue Method

Checks that the value is a valid value for this property.

## Syntax (C#)
```csharp
public bool IsValidValue(
	string value
)
```

## Parameters
- **value** (`System.String`) - The value to be checked.

## Returns
True if the value is valid for the property.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Cannot check validity for a property not being edited in AppearanceAssetEditScope.

