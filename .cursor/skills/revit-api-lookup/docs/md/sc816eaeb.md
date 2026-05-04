---
kind: method
id: M:Autodesk.Revit.DB.Parameter.Set(System.String)
zh: 参数、共享参数
source: html/956a1e23-cfe5-a60b-1ff9-0e8e33812774.htm
---
# Autodesk.Revit.DB.Parameter.Set Method

**中文**: 参数、共享参数

Sets the parameter to a new string of text.

## Syntax (C#)
```csharp
public bool Set(
	string value
)
```

## Parameters
- **value** (`System.String`) - The new text value to which the parameter is to be set.

## Returns
The Set method will return True if the parameter was successfully set to the new value, otherwise false.

## Remarks
You should only use this method if the StorageType property reports the type of the
parameter as a String.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The parameter is read-only.

