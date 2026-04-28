---
kind: method
id: M:Autodesk.Revit.DB.Visual.AssetPropertyDoubleArray3d.SetValueAsXYZ(Autodesk.Revit.DB.XYZ)
source: html/65289109-d566-49ef-087a-564a398c8ec4.htm
---
# Autodesk.Revit.DB.Visual.AssetPropertyDoubleArray3d.SetValueAsXYZ Method

Sets the value property as a vector or point XYZ.

## Syntax (C#)
```csharp
public void SetValueAsXYZ(
	XYZ xyz
)
```

## Parameters
- **xyz** (`Autodesk.Revit.DB.XYZ`) - The new value.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The input value is invalid for this AssetPropertyDoubleArray3d property.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The asset property is not editable.

