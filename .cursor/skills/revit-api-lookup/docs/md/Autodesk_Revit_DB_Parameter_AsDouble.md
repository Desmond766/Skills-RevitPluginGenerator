---
kind: method
id: M:Autodesk.Revit.DB.Parameter.AsDouble
zh: 参数、共享参数
source: html/8831936d-965b-ec90-7e96-b2933c80b88e.htm
---
# Autodesk.Revit.DB.Parameter.AsDouble Method

**中文**: 参数、共享参数

Provides access to the double precision number within the parameter.

## Syntax (C#)
```csharp
public double AsDouble()
```

## Returns
The double value contained in the parameter.

## Remarks
The AsDouble method should only be used if the StorageType property returns that the
internal contents of the parameter is a double.

