---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarContainer.Create(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.Element,Autodesk.Revit.DB.ElementId)
zh: 创建、新建、生成、建立、新增
source: html/48da4e91-7ce6-5636-458f-bc7287ad98b0.htm
---
# Autodesk.Revit.DB.Structure.RebarContainer.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates a new instance of a Rebar Container element within the project.

## Syntax (C#)
```csharp
public static RebarContainer Create(
	Document aDoc,
	Element hostElement,
	ElementId rebarContainerTypeId
)
```

## Parameters
- **aDoc** (`Autodesk.Revit.DB.Document`) - A document.
- **hostElement** (`Autodesk.Revit.DB.Element`) - The element that will host the RebarContainer.
- **rebarContainerTypeId** (`Autodesk.Revit.DB.ElementId`) - The id of the RebarContainerType.

## Returns
The newly created Rebar Container instance.

## Remarks
Created Rebar Container starts out empty.
 Use appendItemFromRebar, appendItemFromCurves, appendItemFromRebarShape, appendItemFromCurvesAndShape to fill its content.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The element hostElement was not found in the given document.
 -or-
 hostElement is not a valid rebar host.
 -or-
 the ElementId rebarContainerTypeId is either invalid or not a RebarContainerType.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

