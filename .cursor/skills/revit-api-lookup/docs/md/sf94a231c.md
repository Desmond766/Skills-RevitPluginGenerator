---
kind: method
id: M:Autodesk.Revit.DB.Parameter.ClearValue
zh: 参数、共享参数
source: html/14658620-d5d5-d8f2-1b6c-343180951d63.htm
---
# Autodesk.Revit.DB.Parameter.ClearValue Method

**中文**: 参数、共享参数

Clears the parameter to its initial value.

## Syntax (C#)
```csharp
public bool ClearValue()
```

## Returns
The ClearValue method will return True if the parameter was successfully cleared to its initial value, otherwise false.

## Remarks
This method will only succeed for Shared parameters that have their HideWhenNoValue property set to true.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The parameter is read-only, or the parameter is not a shared parameter, 
or the shared parameter has HideWhenNoValue set to false.

