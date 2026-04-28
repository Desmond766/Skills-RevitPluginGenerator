---
kind: method
id: M:Autodesk.Revit.DB.DirectShape.CreateGeometryInstance(Autodesk.Revit.DB.Document,System.String,Autodesk.Revit.DB.Transform)
source: html/8a5a08cc-14ea-9c69-26b4-5f1b0562bf53.htm
---
# Autodesk.Revit.DB.DirectShape.CreateGeometryInstance Method

Creates a copy of a definition shape that was created earlier.

## Syntax (C#)
```csharp
public static IList<GeometryObject> CreateGeometryInstance(
	Document document,
	string definition_id,
	Transform trf
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - Document to which the created element will be added
- **definition_id** (`System.String`) - ID of the shape definition that was created earlier and stored via DirectShapeLibrary
- **trf** (`Autodesk.Revit.DB.Transform`) - Transform to be applied to the definition

## Returns
A collection of GeometryObjects representing a placed instance of the pre-defined shape
 The caller function takes ownership

## Remarks
Use DirectShapeLibrary class to store definitions prior to using them here.
 How the definitions are stored will determine whether an instance or a copy of the shape will be created.
 Use the output of this function as input to CreateElement to make the created shape persistent.
 This is intended to support a definition/instance pattern common in CAD formats - DWG blocks, STEP MAPPED_ITEM, IFC IfcMappedItem.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

