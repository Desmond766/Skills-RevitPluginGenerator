---
kind: method
id: M:Autodesk.Revit.DB.Document.SeparateElements(Autodesk.Revit.DB.CombinableElementArray)
zh: 文档、文件
source: html/3611bd74-e12a-ac93-0d33-6b5d23500bc5.htm
---
# Autodesk.Revit.DB.Document.SeparateElements Method

**中文**: 文档、文件

Separate a set of combinable elements out of combinations they currently belong to.

## Syntax (C#)
```csharp
public void SeparateElements(
	CombinableElementArray members
)
```

## Parameters
- **members** (`Autodesk.Revit.DB.CombinableElementArray`) - A list of combinable elements to be separated.

## Remarks
If geometry combination elements are passed as input, they will be completely separated and deleted.
If generic forms that happen to belong to combination elements are passed, these forms will be removed from 
their geometry combination. The handles of geometry combinations completely removed by this operation are no longer valid.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when the input argument is Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when members is empty.
Thrown when members contains Nothing nullptr a null reference ( Nothing in Visual Basic) elements.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when separation failed.

