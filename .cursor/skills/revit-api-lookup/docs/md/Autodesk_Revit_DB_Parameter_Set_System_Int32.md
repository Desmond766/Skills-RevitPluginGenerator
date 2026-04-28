---
kind: method
id: M:Autodesk.Revit.DB.Parameter.Set(System.Int32)
zh: 参数、共享参数
source: html/64a3ad4d-f2b9-632b-c99b-f09bd4d635ee.htm
---
# Autodesk.Revit.DB.Parameter.Set Method

**中文**: 参数、共享参数

Sets the parameter to a new integer value.

## Syntax (C#)
```csharp
public bool Set(
	int value
)
```

## Parameters
- **value** (`System.Int32`) - The new integer value to which the parameter is to be set.

## Returns
The Set method will return True if the parameter was successfully set to the new value, otherwise false.

## Remarks
You should only use this method if the StorageType property reports the type of the
parameter as an integer.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The parameter is read-only.

