---
kind: method
id: M:Autodesk.Revit.DB.Document.GetSubelement(Autodesk.Revit.DB.ElementId,System.Int32)
zh: 文档、文件
source: html/61f62003-12e1-6806-dcb6-3781c54ca830.htm
---
# Autodesk.Revit.DB.Document.GetSubelement Method

**中文**: 文档、文件

Gets the subelement referenced by a parent id and subelement id.

## Syntax (C#)
```csharp
public Subelement GetSubelement(
	ElementId id,
	int subId
)
```

## Parameters
- **id** (`Autodesk.Revit.DB.ElementId`) - Id of the element.
- **subId** (`System.Int32`) - Id of the sub element.

## Returns
The subelement referenced by the input argument.

## Remarks
Nothing nullptr a null reference ( Nothing in Visual Basic) will be returned if the input id string doesn't reference to a valid element or subelement.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

