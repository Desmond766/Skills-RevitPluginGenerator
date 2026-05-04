---
kind: method
id: M:Autodesk.Revit.Creation.Application.NewFamilyInstanceCreationData(Autodesk.Revit.DB.XYZ,Autodesk.Revit.DB.FamilySymbol,Autodesk.Revit.DB.Element,Autodesk.Revit.DB.Structure.StructuralType)
source: html/138058a1-cbf3-da64-636f-e2e353abfcd4.htm
---
# Autodesk.Revit.Creation.Application.NewFamilyInstanceCreationData Method

Creates an object which wraps the arguments of NewFamilyInstance() for batch creation.

## Syntax (C#)
```csharp
public FamilyInstanceCreationData NewFamilyInstanceCreationData(
	XYZ location,
	FamilySymbol symbol,
	Element host,
	StructuralType structuralType
)
```

## Parameters
- **location** (`Autodesk.Revit.DB.XYZ`) - The physical location where the instance is to be placed.
- **symbol** (`Autodesk.Revit.DB.FamilySymbol`) - A FamilySymbol object that represents the type of the instance that is to be inserted.
- **host** (`Autodesk.Revit.DB.Element`) - The object into which the family instance is to be inserted, often known as the host.
- **structuralType** (`Autodesk.Revit.DB.Structure.StructuralType`) - If structural then specify the type of the component.

