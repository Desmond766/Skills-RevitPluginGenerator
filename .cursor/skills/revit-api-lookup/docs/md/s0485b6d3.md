---
kind: method
id: M:Autodesk.Revit.Creation.FamilyInstanceCreationData.#ctor(Autodesk.Revit.DB.XYZ,Autodesk.Revit.DB.FamilySymbol,Autodesk.Revit.DB.XYZ,Autodesk.Revit.DB.Element,Autodesk.Revit.DB.Structure.StructuralType)
source: html/f2130da0-8676-74e2-6239-7c218ced4723.htm
---
# Autodesk.Revit.Creation.FamilyInstanceCreationData.#ctor Method

Initializes a new instance of the FamilyInstanceCreationData class

## Syntax (C#)
```csharp
public FamilyInstanceCreationData(
	XYZ location,
	FamilySymbol symbol,
	XYZ referenceDirection,
	Element host,
	StructuralType structuralType
)
```

## Parameters
- **location** (`Autodesk.Revit.DB.XYZ`) - The physical location where the instance is to be placed.
- **symbol** (`Autodesk.Revit.DB.FamilySymbol`) - A FamilySymbol object that represents the type of the instance that is to be inserted.
- **referenceDirection** (`Autodesk.Revit.DB.XYZ`) - A vector that dictates the direction of certain family instances.
- **host** (`Autodesk.Revit.DB.Element`) - The object into which the FamilyInstance is to be inserted, often known as the host.
- **structuralType** (`Autodesk.Revit.DB.Structure.StructuralType`) - If structural then specify the type of the component.

