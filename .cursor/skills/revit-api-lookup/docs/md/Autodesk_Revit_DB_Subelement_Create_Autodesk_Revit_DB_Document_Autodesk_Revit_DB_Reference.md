---
kind: method
id: M:Autodesk.Revit.DB.Subelement.Create(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.Reference)
zh: 创建、新建、生成、建立、新增
source: html/2df166ab-238b-1690-bd3e-2033778b9542.htm
---
# Autodesk.Revit.DB.Subelement.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates an object representing element or subelement.

## Syntax (C#)
```csharp
public static Subelement Create(
	Document aDoc,
	Reference reference
)
```

## Parameters
- **aDoc** (`Autodesk.Revit.DB.Document`) - The document.
- **reference** (`Autodesk.Revit.DB.Reference`) - The reference that identifies element or subelement.

## Returns
The newly created subelement.

## Remarks
If %reference% points to linked document:
 The GetReference () () () method of the newly created subelement will return the local reference in the linked document. The Document property of the newly created subelement will return the linked document.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - reference does not identify a valid element or subelement.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

