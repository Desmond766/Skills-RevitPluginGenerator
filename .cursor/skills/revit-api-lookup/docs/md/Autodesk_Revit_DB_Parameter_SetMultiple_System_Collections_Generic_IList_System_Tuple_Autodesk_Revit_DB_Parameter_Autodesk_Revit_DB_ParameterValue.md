---
kind: method
id: M:Autodesk.Revit.DB.Parameter.SetMultiple(System.Collections.Generic.IList{System.Tuple{Autodesk.Revit.DB.Parameter,Autodesk.Revit.DB.ParameterValue}})
zh: 参数、共享参数
source: html/504f16ac-3842-d16f-3557-22fd787474c1.htm
---
# Autodesk.Revit.DB.Parameter.SetMultiple Method

**中文**: 参数、共享参数

Sets multiple parameters to new values.

## Syntax (C#)
```csharp
public static List<Parameter> SetMultiple(
	IList<Tuple<Parameter, ParameterValue>> values
)
```

## Parameters
- **values** (`System.Collections.Generic.IList < Tuple < Parameter , ParameterValue >>`) - A list of pairs of parameters and their corresponding values.

## Returns
The list of parameters that were not set successfully, if any.

## Remarks
This method is provided as a performance optimization. Note that it will throw an
exception if any parameter would throw an exception, so validate ahead of time.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The parameter is read-only.
- **Autodesk.Revit.Exceptions.ArgumentException** - Value must be a finite number.

