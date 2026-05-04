---
kind: method
id: M:Autodesk.Revit.DB.DeleteElements.Create(Autodesk.Revit.DB.Document,System.Collections.Generic.ISet{Autodesk.Revit.DB.ElementId})
zh: 创建、新建、生成、建立、新增
source: html/ced03565-a412-1df0-e65c-6eabfc3dbf00.htm
---
# Autodesk.Revit.DB.DeleteElements.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates an instance of the DeleteElements resolution.

## Syntax (C#)
```csharp
public static FailureResolution Create(
	Document document,
	ISet<ElementId> ids
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document which owns the elements to delete.
- **ids** (`System.Collections.Generic.ISet < ElementId >`) - The ids of the elements that will be deleted when this resolution is chosen.

## Returns
The instance of the DeleteElements resolution.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The input ids is empty or contains an invalid element id.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

