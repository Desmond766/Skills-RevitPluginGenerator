---
kind: method
id: M:Autodesk.Revit.DB.Visual.AssetPropertyList.IsValidValue(System.Collections.Generic.IList{Autodesk.Revit.DB.Visual.AssetProperty})
source: html/5b3e8e0a-4957-981d-9900-0847178f1d2f.htm
---
# Autodesk.Revit.DB.Visual.AssetPropertyList.IsValidValue Method

Check that value is valid.

## Syntax (C#)
```csharp
public bool IsValidValue(
	IList<AssetProperty> value
)
```

## Parameters
- **value** (`System.Collections.Generic.IList < AssetProperty >`) - The array of properties to validate.

## Returns
Returns true if the array of properties is valid, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Cannot check validity for a property not being edited in AppearanceAssetEditScope.

