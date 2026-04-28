---
kind: method
id: M:Autodesk.Revit.DB.Parameter.AsString
zh: 参数、共享参数
source: html/7aff8476-0396-fc08-27b4-467e4017f6a7.htm
---
# Autodesk.Revit.DB.Parameter.AsString Method

**中文**: 参数、共享参数

Provides access to the string contents of the parameter.

## Syntax (C#)
```csharp
public string AsString()
```

## Returns
The string contained in the parameter.

## Remarks
The AsString method should only be used if the StorageType property returns that the
internal contents of the parameter is a string.

