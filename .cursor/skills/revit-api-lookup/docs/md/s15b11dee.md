---
kind: method
id: M:Autodesk.Revit.Creation.Application.NewFamilyInstanceCreationData(Autodesk.Revit.DB.Face,Autodesk.Revit.DB.XYZ,Autodesk.Revit.DB.XYZ,Autodesk.Revit.DB.FamilySymbol)
source: html/d6ba9437-5aeb-1eee-9720-2903913ad8b6.htm
---
# Autodesk.Revit.Creation.Application.NewFamilyInstanceCreationData Method

Creates an object which wraps the arguments of NewFamilyInstance() for batch creation.

## Syntax (C#)
```csharp
public FamilyInstanceCreationData NewFamilyInstanceCreationData(
	Face face,
	XYZ location,
	XYZ referenceDirection,
	FamilySymbol symbol
)
```

## Parameters
- **face** (`Autodesk.Revit.DB.Face`) - A face of a geometry object.
- **location** (`Autodesk.Revit.DB.XYZ`) - Point on the face where the instance is to be placed.
- **referenceDirection** (`Autodesk.Revit.DB.XYZ`) - A vector that defines the direction of the family instance.
- **symbol** (`Autodesk.Revit.DB.FamilySymbol`) - A FamilySymbol object that represents the type of the instance that is to be inserted.

