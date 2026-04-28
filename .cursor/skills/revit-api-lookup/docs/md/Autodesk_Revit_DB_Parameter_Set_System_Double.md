---
kind: method
id: M:Autodesk.Revit.DB.Parameter.Set(System.Double)
zh: 参数、共享参数
source: html/a3e195e5-5601-2ffb-511b-693052137fa8.htm
---
# Autodesk.Revit.DB.Parameter.Set Method

**中文**: 参数、共享参数

Sets the parameter to a new real number value.

## Syntax (C#)
```csharp
public bool Set(
	double value
)
```

## Parameters
- **value** (`System.Double`) - The new double value to which the parameter is to be set.

## Returns
The Set method will return True if the parameter was successfully set to the new value, otherwise false.

## Remarks
You should only use this method if the StorageType property reports the type of the
parameter as a Double.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The parameter is read-only.
- **Autodesk.Revit.Exceptions.ArgumentException** - Value must be a finite number.

