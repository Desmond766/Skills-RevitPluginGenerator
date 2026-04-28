---
kind: method
id: M:Autodesk.Revit.Creation.FamilyInstanceCreationData.#ctor(Autodesk.Revit.DB.Face,Autodesk.Revit.DB.XYZ,Autodesk.Revit.DB.XYZ,Autodesk.Revit.DB.FamilySymbol)
source: html/d0042c25-fd41-565b-ccd2-8d8fe2355b40.htm
---
# Autodesk.Revit.Creation.FamilyInstanceCreationData.#ctor Method

Initializes a new instance of the FamilyInstanceCreationData class

## Syntax (C#)
```csharp
public FamilyInstanceCreationData(
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

