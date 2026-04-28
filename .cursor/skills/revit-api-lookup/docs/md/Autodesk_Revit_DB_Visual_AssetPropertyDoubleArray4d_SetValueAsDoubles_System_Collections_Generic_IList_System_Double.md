---
kind: method
id: M:Autodesk.Revit.DB.Visual.AssetPropertyDoubleArray4d.SetValueAsDoubles(System.Collections.Generic.IList{System.Double})
source: html/86bf0125-c816-b2ac-32c1-966685159463.htm
---
# Autodesk.Revit.DB.Visual.AssetPropertyDoubleArray4d.SetValueAsDoubles Method

Sets the value of the property.

## Syntax (C#)
```csharp
public void SetValueAsDoubles(
	IList<double> value
)
```

## Parameters
- **value** (`System.Collections.Generic.IList < Double >`) - The new value as doubles.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The input value is invalid for this AssetPropertyDoubleArray4d property.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The asset property is not editable.

