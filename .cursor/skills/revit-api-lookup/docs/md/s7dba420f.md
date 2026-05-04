---
kind: method
id: M:Autodesk.Revit.DB.Parameter.AssociateWithGlobalParameter(Autodesk.Revit.DB.ElementId)
zh: 参数、共享参数
source: html/796f3d95-956e-a2a9-7f8e-e8efd2a0eea0.htm
---
# Autodesk.Revit.DB.Parameter.AssociateWithGlobalParameter Method

**中文**: 参数、共享参数

Associates this parameter with a global parameter in the same document.

## Syntax (C#)
```csharp
public void AssociateWithGlobalParameter(
	ElementId gpId
)
```

## Parameters
- **gpId** (`Autodesk.Revit.DB.ElementId`) - Id of a global parameter contained in this parameter's document

## Remarks
The parameter must be parameterizable, meaning it cannot be read-only,
 driven by a formula, or have any other restrictions imposed by Revit. The parameter's value type must match the type of the global parameter. Once associated property can be later dissociated by calling the
 DissociateFromGlobalParameter () () () method

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The input gpId is not of a valid global parameter of the given document.
 -or-
 This parameter does not exist in the document anymore.
 -or-
 This parameter is either not parameterizable or does not match the type of the global parameter.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was NULL

