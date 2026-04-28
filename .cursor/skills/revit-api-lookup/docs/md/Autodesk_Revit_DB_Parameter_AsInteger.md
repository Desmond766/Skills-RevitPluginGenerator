---
kind: method
id: M:Autodesk.Revit.DB.Parameter.AsInteger
zh: 参数、共享参数
source: html/507608fe-47fc-1441-acdc-5ce9c3c5da03.htm
---
# Autodesk.Revit.DB.Parameter.AsInteger Method

**中文**: 参数、共享参数

Provides access to the integer number within the parameter.

## Syntax (C#)
```csharp
public int AsInteger()
```

## Returns
The integer value contained in the parameter.

## Remarks
The AsInteger method should only be used if the StorageType property returns that the
internal contents of the parameter is an integer.

