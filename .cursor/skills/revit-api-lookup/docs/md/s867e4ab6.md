---
kind: method
id: M:Autodesk.Revit.DB.Document.GetElement(System.String)
zh: 文档、文件
source: html/b5a1473c-21c4-6c29-f1cf-26822c955260.htm
---
# Autodesk.Revit.DB.Document.GetElement Method

**中文**: 文档、文件

Gets the Element referenced by a unique id string.

## Syntax (C#)
```csharp
public Element GetElement(
	string uniqueId
)
```

## Parameters
- **uniqueId** (`System.String`) - The element unique id, whose referenced Element will be retrieved from the model.
 UniqueId

## Returns
The element referenced by the input argument.

## Remarks
Nothing nullptr a null reference ( Nothing in Visual Basic) will be returned if the input id string doesn't reference to a valid Element.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

