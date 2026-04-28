---
kind: method
id: M:Autodesk.Revit.DB.Plumbing.PipeSegment.Create(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.ElementId,System.Collections.Generic.ICollection{Autodesk.Revit.DB.MEPSize})
zh: 创建、新建、生成、建立、新增
source: html/94bde5f7-312c-2ef0-5812-54ffe54ba3ce.htm
---
# Autodesk.Revit.DB.Plumbing.PipeSegment.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates a new instance of a PipeSegment and adds it to the document.

## Syntax (C#)
```csharp
public static PipeSegment Create(
	Document ADocument,
	ElementId MaterialId,
	ElementId ScheduleId,
	ICollection<MEPSize> sizeSet
)
```

## Parameters
- **ADocument** (`Autodesk.Revit.DB.Document`) - The document where the PipeSegment will be created and added.
- **MaterialId** (`Autodesk.Revit.DB.ElementId`) - The ElementId of the MaterialElem of the pipe segment.
- **ScheduleId** (`Autodesk.Revit.DB.ElementId`) - The ElementId of the PipeScheduleType of the pipe segment.
- **sizeSet** (`System.Collections.Generic.ICollection < MEPSize >`) - A set of one or more sizes.

## Returns
The newly created pipe segment element.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The size list is empty.
 -or-
 The MaterialId and ScheduleId was already used by another pipe segment. Please use a new Material, a new Schedule/Type, or both.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.DisabledDisciplineException** - None of the following disciplines is enabled: Mechanical Electrical Piping.

