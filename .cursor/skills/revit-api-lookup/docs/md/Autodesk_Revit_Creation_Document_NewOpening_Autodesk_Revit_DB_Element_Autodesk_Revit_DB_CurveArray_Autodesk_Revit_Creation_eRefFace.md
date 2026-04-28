---
kind: method
id: M:Autodesk.Revit.Creation.Document.NewOpening(Autodesk.Revit.DB.Element,Autodesk.Revit.DB.CurveArray,Autodesk.Revit.Creation.eRefFace)
zh: 文档、文件
source: html/73c9751f-df8c-04cc-e628-81e582f5c777.htm
---
# Autodesk.Revit.Creation.Document.NewOpening Method

**中文**: 文档、文件

Creates a new opening in a beam, brace and column.

## Syntax (C#)
```csharp
public Opening NewOpening(
	Element famInstElement,
	CurveArray profile,
	eRefFace iFace
)
```

## Parameters
- **famInstElement** (`Autodesk.Revit.DB.Element`) - host element of the opening, can be a beam, brace and column.
- **profile** (`Autodesk.Revit.DB.CurveArray`) - profile of the opening.
- **iFace** (`Autodesk.Revit.Creation.eRefFace`) - face on which opening is based on.

## Returns
If successful, an Opening object is returned.

## Remarks
This method forms opening on a beam, brace and column.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown if the family instance element does not exist in the given document.

