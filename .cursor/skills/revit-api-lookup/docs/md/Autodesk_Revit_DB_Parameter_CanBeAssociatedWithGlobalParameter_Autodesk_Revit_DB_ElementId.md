---
kind: method
id: M:Autodesk.Revit.DB.Parameter.CanBeAssociatedWithGlobalParameter(Autodesk.Revit.DB.ElementId)
zh: 参数、共享参数
source: html/f14bfd98-34de-ea9a-e34f-55631d23d466.htm
---
# Autodesk.Revit.DB.Parameter.CanBeAssociatedWithGlobalParameter Method

**中文**: 参数、共享参数

Tests whether this parameter can be associated with the given global parameter.

## Syntax (C#)
```csharp
public bool CanBeAssociatedWithGlobalParameter(
	ElementId gpId
)
```

## Parameters
- **gpId** (`Autodesk.Revit.DB.ElementId`) - Id of a global parameter contained in this parameter's document

## Returns
True if this parameter can be associated with the given global parameter; False otherwise.

## Remarks
Only properties defined as parametrizable can be associated with global parameters.
 That excludes any read-only and formula-driven parameters, as well as those that
 have other explicit or implicit restrictions imposed by Revit.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The input gpId is not of a valid global parameter of the given document.
 -or-
 This parameter does not exist in the document anymore.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was NULL

