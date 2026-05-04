---
kind: method
id: M:Autodesk.Revit.DB.Document.GetElement(Autodesk.Revit.DB.Reference)
zh: 文档、文件
source: html/4d674a3e-cd18-6b3d-b1b2-247713fe3c9f.htm
---
# Autodesk.Revit.DB.Document.GetElement Method

**中文**: 文档、文件

Gets the Element referenced by the input reference.

## Syntax (C#)
```csharp
public Element GetElement(
	Reference reference
)
```

## Parameters
- **reference** (`Autodesk.Revit.DB.Reference`) - The reference, whose referenced Element will be retrieved from the model.

## Returns
The element referenced by the input argument.

## Remarks
Nothing nullptr a null reference ( Nothing in Visual Basic) will be returned if the input reference doesn't reference to a valid Element.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

