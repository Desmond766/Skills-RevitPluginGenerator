---
kind: method
id: M:Autodesk.Revit.DB.GlobalParameter.SetValue(Autodesk.Revit.DB.ParameterValue)
source: html/df012c22-6e65-8de5-1057-f15660d02288.htm
---
# Autodesk.Revit.DB.GlobalParameter.SetValue Method

Sets a new value of the global parameter.

## Syntax (C#)
```csharp
public void SetValue(
	ParameterValue value
)
```

## Parameters
- **value** (`Autodesk.Revit.DB.ParameterValue`) - An instance of one of the value classes derived from ParameterValue.

## Remarks
Note that a value can only be set for parameters that are neither
 formula-driven nor dimension-driven, as those have their values determined
 by evaluating the formula or by the dimension, respectively. The argument this method accepts is of the same type of ParameterValue 
 that is returned by GetValue () () () . However, the type can also be easily deduced:
 Text parameters accept only StringParameterValue .
 Integer and YesNo parameters accept only IntegerParameterValue .
 All other types of parameters accept only DoubleParameterValue .
 Curiously, the actual value of a YesNo parameter can be only either 0 or 1.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The given value argument is not a valid instance of ParameterValue!
 -or-
 The given parameter value arguments is not of the storage type the global parameter expects.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This is a formula-driven parameter. As such it does not allow the current operation.
 -or-
 This is a dimension-driven parameter. As such it does not allow the current operation.

