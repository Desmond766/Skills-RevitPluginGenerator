---
kind: method
id: M:Autodesk.Revit.Creation.Application.NewFamilyInstanceCreationData(Autodesk.Revit.DB.Curve,Autodesk.Revit.DB.FamilySymbol,Autodesk.Revit.DB.Level,Autodesk.Revit.DB.Structure.StructuralType)
source: html/ab83d4b2-e27a-c2e8-56aa-324c7061cccf.htm
---
# Autodesk.Revit.Creation.Application.NewFamilyInstanceCreationData Method

Creates an object which wraps the arguments of NewFamilyInstance() for batch creation.

## Syntax (C#)
```csharp
public FamilyInstanceCreationData NewFamilyInstanceCreationData(
	Curve curve,
	FamilySymbol symbol,
	Level level,
	StructuralType structuralType
)
```

## Parameters
- **curve** (`Autodesk.Revit.DB.Curve`) - The curve where the instance is based.
- **symbol** (`Autodesk.Revit.DB.FamilySymbol`) - A FamilySymbol object that represents the type of the instance that is to be inserted.
- **level** (`Autodesk.Revit.DB.Level`) - A Level object that is used as the base level for the object.
- **structuralType** (`Autodesk.Revit.DB.Structure.StructuralType`) - If structural then specify the type of the component.

