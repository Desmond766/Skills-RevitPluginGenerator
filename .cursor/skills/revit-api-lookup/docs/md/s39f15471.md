---
kind: method
id: M:Autodesk.Revit.DB.DirectShape.CreateElementInstance(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.ElementId,System.String,Autodesk.Revit.DB.Transform)
source: html/2a44c4e3-5056-eb56-f849-a7e9dcc478da.htm
---
# Autodesk.Revit.DB.DirectShape.CreateElementInstance Method

Creates a DirectShape object and adds it to document.

## Syntax (C#)
```csharp
public static DirectShape CreateElementInstance(
	Document document,
	ElementId typeId,
	ElementId categoryId,
	string definitionId,
	Transform trf
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - Document to which the created element will be added.
- **typeId** (`Autodesk.Revit.DB.ElementId`) - Element id of a DirectShapeType element.
- **categoryId** (`Autodesk.Revit.DB.ElementId`) - Id of the category assigned to this DirectShape. Must be a valid category id.
- **definitionId** (`System.String`) - Id of the shape definition that was created earlier and stored via DirectShapeLibrary.
- **trf** (`Autodesk.Revit.DB.Transform`) - Transform to be applied to the definition.

## Returns
The created DirectShape object.

## Remarks
This function is included for convenience. It essentially combines CreateGeometryInstance and CreateElement.
 The shape stored in the element is either a reference or a copy of a definition shape that was created earlier.
 How the definitions are stored will determine whether an instance or a copy of the shape will be created.
 The intended use is to support a definition/instance pattern common in CAD formats - DWG blocks, STEP MAPPED_ITEM, IFC IfcMappedItem.
 Use DirectShapeLibrary class to store definitions prior to using them here.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Document document may not contain DirectShape or DirectShapeType objects.
 -or-
 Element id categoryId may not be used as a DirectShape category.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

