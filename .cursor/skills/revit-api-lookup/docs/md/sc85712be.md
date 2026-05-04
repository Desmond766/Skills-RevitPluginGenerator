---
kind: method
id: M:Autodesk.Revit.DB.Document.GetSubelement(System.String)
zh: 文档、文件
source: html/9fd1a0fa-17f1-95a0-6feb-e9609fe0c7f1.htm
---
# Autodesk.Revit.DB.Document.GetSubelement Method

**中文**: 文档、文件

Gets the subelement referenced by a unique id string.

## Syntax (C#)
```csharp
public Subelement GetSubelement(
	string uniqueId
)
```

## Parameters
- **uniqueId** (`System.String`) - The unique id that identifies element or subelement.
 UniqueId

## Returns
The subelement referenced by the input argument.

## Remarks
Nothing nullptr a null reference ( Nothing in Visual Basic) will be returned if the input id string doesn't reference to a valid element or subelement.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

