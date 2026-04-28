---
kind: method
id: M:Autodesk.Revit.Creation.FamilyInstanceCreationData.#ctor(Autodesk.Revit.DB.XYZ,Autodesk.Revit.DB.FamilySymbol,Autodesk.Revit.DB.Element,Autodesk.Revit.DB.Structure.StructuralType)
source: html/aedebc4c-7452-2550-a986-70e4cd339a69.htm
---
# Autodesk.Revit.Creation.FamilyInstanceCreationData.#ctor Method

Initializes a new instance of the FamilyInstanceCreationData class

## Syntax (C#)
```csharp
public FamilyInstanceCreationData(
	XYZ location,
	FamilySymbol symbol,
	Element host,
	StructuralType structuralType
)
```

## Parameters
- **location** (`Autodesk.Revit.DB.XYZ`) - The physical location where the instance is to be placed.
- **symbol** (`Autodesk.Revit.DB.FamilySymbol`) - A FamilySymbol object that represents the type of the instance that is to be inserted.
- **host** (`Autodesk.Revit.DB.Element`) - The object into which the FamilyInstance is to be inserted, often known as the host.
- **structuralType** (`Autodesk.Revit.DB.Structure.StructuralType`) - If structural then specify the type of the component.

