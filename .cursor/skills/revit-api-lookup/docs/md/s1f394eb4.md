---
kind: method
id: M:Autodesk.Revit.DB.Plumbing.PipingSystem.Create(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId,System.String)
zh: 创建、新建、生成、建立、新增
source: html/bdfb862c-8547-1f6b-50fe-f28b40a50689.htm
---
# Autodesk.Revit.DB.Plumbing.PipingSystem.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates a new instance of a piping system and adds it to the document.

## Syntax (C#)
```csharp
public static PipingSystem Create(
	Document ADocument,
	ElementId typeId,
	string name
)
```

## Parameters
- **ADocument** (`Autodesk.Revit.DB.Document`) - The document where the element will be created and added.
- **typeId** (`Autodesk.Revit.DB.ElementId`) - The identifier of this piping system element's type.
- **name** (`System.String`) - The name of the piping system to be created.

## Returns
The newly created piping system element.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The typeId is not an element id for a valid piping system type.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.DisabledDisciplineException** - None of the following disciplines is enabled: Mechanical Electrical Piping.

