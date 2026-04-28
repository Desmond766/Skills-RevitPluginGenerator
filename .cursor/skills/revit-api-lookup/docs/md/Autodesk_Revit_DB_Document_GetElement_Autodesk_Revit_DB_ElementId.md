---
kind: method
id: M:Autodesk.Revit.DB.Document.GetElement(Autodesk.Revit.DB.ElementId)
zh: 文档、文件
source: html/d9848d7d-5917-2433-8454-f65f5ac03964.htm
---
# Autodesk.Revit.DB.Document.GetElement Method

**中文**: 文档、文件

Gets the Element referenced by the input ElementId.

## Syntax (C#)
```csharp
public Element GetElement(
	ElementId id
)
```

## Parameters
- **id** (`Autodesk.Revit.DB.ElementId`) - The ElementId, whose referenced Element will be retrieved from the model.

## Returns
The element referenced by the input argument.

## Remarks
Nothing nullptr a null reference ( Nothing in Visual Basic) will be returned if the input ElementId doesn't reference to a valid Element.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

