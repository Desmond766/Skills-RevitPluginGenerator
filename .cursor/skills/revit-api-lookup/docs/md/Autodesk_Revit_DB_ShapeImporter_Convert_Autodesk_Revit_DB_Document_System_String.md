---
kind: method
id: M:Autodesk.Revit.DB.ShapeImporter.Convert(Autodesk.Revit.DB.Document,System.String)
source: html/be3a172d-dc86-2a49-50ec-fd88d250de87.htm
---
# Autodesk.Revit.DB.ShapeImporter.Convert Method

Converts the geometry stored in the external format into a collection of Revit geometry objects.

## Syntax (C#)
```csharp
public IList<GeometryObject> Convert(
	Document document,
	string filename
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The Revit document where the resulting Revit geometry objects will be used. This document may need to be modified
 to store dependent elements such as graphics styles and/or materials.
- **filename** (`System.String`) - The full path to the input file.

## Returns
A collection of Revit geometry objects created from the incoming data.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.FileArgumentNotFoundException** - The given filename does not exist.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Data conversion service is not available.

