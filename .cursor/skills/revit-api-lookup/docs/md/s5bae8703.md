---
kind: method
id: M:Autodesk.Revit.DB.Parameter.Set(Autodesk.Revit.DB.ElementId)
zh: 参数、共享参数
source: html/992097b4-0477-249f-581d-7903dfafd66d.htm
---
# Autodesk.Revit.DB.Parameter.Set Method

**中文**: 参数、共享参数

Sets the parameter to a new element id.

## Syntax (C#)
```csharp
public bool Set(
	ElementId value
)
```

## Parameters
- **value** (`Autodesk.Revit.DB.ElementId`) - The new element id to which the parameter is to be set.

## Returns
The Set method will return True if the parameter was successfully set to the new value, otherwise false.

## Remarks
You should only use this method if the StorageType property reports the type of the
parameter as an ElementId.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The parameter is read-only.

