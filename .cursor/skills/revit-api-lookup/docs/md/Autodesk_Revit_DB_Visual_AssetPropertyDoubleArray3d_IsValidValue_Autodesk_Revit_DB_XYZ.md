---
kind: method
id: M:Autodesk.Revit.DB.Visual.AssetPropertyDoubleArray3d.IsValidValue(Autodesk.Revit.DB.XYZ)
source: html/cc1abfdf-c7ae-ffcb-5e1d-22b287618ea3.htm
---
# Autodesk.Revit.DB.Visual.AssetPropertyDoubleArray3d.IsValidValue Method

Checks that the value is a valid value for this property.

## Syntax (C#)
```csharp
public bool IsValidValue(
	XYZ xyz
)
```

## Parameters
- **xyz** (`Autodesk.Revit.DB.XYZ`) - The value to be checked.

## Returns
True if the value is valid for the property.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Cannot check validity for a property not being edited in AppearanceAssetEditScope.

