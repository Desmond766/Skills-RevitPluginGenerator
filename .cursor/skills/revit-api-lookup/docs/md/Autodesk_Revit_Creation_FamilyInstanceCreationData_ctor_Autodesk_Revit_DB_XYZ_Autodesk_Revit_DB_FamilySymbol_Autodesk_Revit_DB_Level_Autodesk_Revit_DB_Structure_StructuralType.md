---
kind: method
id: M:Autodesk.Revit.Creation.FamilyInstanceCreationData.#ctor(Autodesk.Revit.DB.XYZ,Autodesk.Revit.DB.FamilySymbol,Autodesk.Revit.DB.Level,Autodesk.Revit.DB.Structure.StructuralType)
source: html/fe68c1c1-d00e-bb96-f891-5ed987f11353.htm
---
# Autodesk.Revit.Creation.FamilyInstanceCreationData.#ctor Method

Initializes a new instance of the FamilyInstanceCreationData class

## Syntax (C#)
```csharp
public FamilyInstanceCreationData(
	XYZ location,
	FamilySymbol symbol,
	Level level,
	StructuralType structuralType
)
```

## Parameters
- **location** (`Autodesk.Revit.DB.XYZ`) - The physical location where the instance is to be placed.
- **symbol** (`Autodesk.Revit.DB.FamilySymbol`) - A FamilySymbol object that represents the type of the instance that is to be inserted.
- **level** (`Autodesk.Revit.DB.Level`) - A Level object that is used as the base level for the object.
- **structuralType** (`Autodesk.Revit.DB.Structure.StructuralType`) - If structural then specify the type of the component.

