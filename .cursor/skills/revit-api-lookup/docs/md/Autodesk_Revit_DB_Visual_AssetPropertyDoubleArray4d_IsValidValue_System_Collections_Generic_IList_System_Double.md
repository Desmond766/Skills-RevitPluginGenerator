---
kind: method
id: M:Autodesk.Revit.DB.Visual.AssetPropertyDoubleArray4d.IsValidValue(System.Collections.Generic.IList{System.Double})
source: html/7fa5d0ab-3771-829f-1291-514bfdac93a8.htm
---
# Autodesk.Revit.DB.Visual.AssetPropertyDoubleArray4d.IsValidValue Method

Checks that the value is a valid value for this property.

## Syntax (C#)
```csharp
public bool IsValidValue(
	IList<double> value
)
```

## Parameters
- **value** (`System.Collections.Generic.IList < Double >`) - The value to be checked.

## Returns
True if the value is valid for the property.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Cannot check validity for a property not being edited in AppearanceAssetEditScope.

