---
kind: method
id: M:Autodesk.Revit.DB.Document.CombineElements(Autodesk.Revit.DB.CombinableElementArray)
zh: 文档、文件
source: html/5c33a711-2891-f353-5f39-24ba175be452.htm
---
# Autodesk.Revit.DB.Document.CombineElements Method

**中文**: 文档、文件

Combine a set of combinable elements into a geometry combination.

## Syntax (C#)
```csharp
public GeomCombination CombineElements(
	CombinableElementArray members
)
```

## Parameters
- **members** (`Autodesk.Revit.DB.CombinableElementArray`) - A list of combinable elements to be combined.

## Returns
If successful, the newly created geometry combination is returned, otherwise an
exception with error information will be thrown.

## Remarks
If one or more existing geometry combinations are included as input, the return value may be one of those pre-existing 
combinations. The rest of the pre-existing geometry combinations will be consumed into the new combination; those handles are no longer valid.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when the input argument is Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when members contains less than two elements.
Thrown when members contains Nothing nullptr a null reference ( Nothing in Visual Basic) elements.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when creation of the combination failed.

