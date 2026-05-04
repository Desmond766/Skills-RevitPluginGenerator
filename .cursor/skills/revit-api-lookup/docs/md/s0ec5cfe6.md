---
kind: method
id: M:Autodesk.Revit.DB.Mechanical.MechanicalSystem.Create(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId)
zh: 创建、新建、生成、建立、新增
source: html/51d03162-ca4f-11ad-cc8c-f3cefeee4499.htm
---
# Autodesk.Revit.DB.Mechanical.MechanicalSystem.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates a new instance of a mechanical system and adds it to the document.

## Syntax (C#)
```csharp
public static MechanicalSystem Create(
	Document ADocument,
	ElementId typeId
)
```

## Parameters
- **ADocument** (`Autodesk.Revit.DB.Document`) - The document where the element will be created and added.
- **typeId** (`Autodesk.Revit.DB.ElementId`) - The identifier of this mechanical system element's type.

## Returns
The newly created mechanical system element.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The typeId is not an element id for a valid mechanical system type.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.DisabledDisciplineException** - None of the following disciplines is enabled: Mechanical Electrical Piping.

