---
kind: method
id: M:Autodesk.Revit.DB.Parameter.CanBeAssociatedWithGlobalParameters
zh: 参数、共享参数
source: html/fdbfc683-adc4-b722-c466-a605216a0ee4.htm
---
# Autodesk.Revit.DB.Parameter.CanBeAssociatedWithGlobalParameters Method

**中文**: 参数、共享参数

Tests whether this parameter can be associated with any global parameter.

## Syntax (C#)
```csharp
public bool CanBeAssociatedWithGlobalParameters()
```

## Returns
True if the given parameter can be associated (is parametrizable); False otherwise.

## Remarks
Only properties defined as parametrizable can be associated with global parameters.
 That excludes any read-only and formula-driven parameters, as well as those that
 have other explicit or implicit restrictions imposed by Revit.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - This parameter does not exist in the document anymore.

