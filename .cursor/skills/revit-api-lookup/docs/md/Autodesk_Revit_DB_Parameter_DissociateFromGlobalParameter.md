---
kind: method
id: M:Autodesk.Revit.DB.Parameter.DissociateFromGlobalParameter
zh: 参数、共享参数
source: html/060e7402-6c92-06c2-d95b-1a79a3fad44a.htm
---
# Autodesk.Revit.DB.Parameter.DissociateFromGlobalParameter Method

**中文**: 参数、共享参数

Dissociates this parameter from a global parameter.

## Syntax (C#)
```csharp
public void DissociateFromGlobalParameter()
```

## Remarks
It is assumed this parameter has been previously associated with the global parameter 
 by using the [!:AssociateWithGlobalParameter(Revit::DB::ElementId^)] method.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - This parameter does not exist in the document anymore.
 -or-
 This parameter is either not parameterizable or does not match the type of the global parameter.

