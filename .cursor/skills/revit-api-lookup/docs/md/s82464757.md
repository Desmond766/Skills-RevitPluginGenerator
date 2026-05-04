---
kind: method
id: M:Autodesk.Revit.DB.Parameter.GetAssociatedGlobalParameter
zh: 参数、共享参数
source: html/af5f333f-0d47-5f51-db38-bd6886905cf6.htm
---
# Autodesk.Revit.DB.Parameter.GetAssociatedGlobalParameter Method

**中文**: 参数、共享参数

Returns a global parameter, if any, currently associated with this parameter.

## Syntax (C#)
```csharp
public ElementId GetAssociatedGlobalParameter()
```

## Returns
Id of a global parameter or InvalidElemetnId.

## Remarks
InvalidElementId is returned in case this parameter is not associated with any global parameter.
 InvalidElementId is also returned if called for a parameter that cannot even be associated
 with a global parameters (i.e. a non-parametrizable parameter or parameter with a formula).

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - This parameter does not exist in the document anymore.

