---
kind: method
id: M:Autodesk.Revit.Creation.FamilyInstanceCreationData.#ctor(Autodesk.Revit.DB.Curve,Autodesk.Revit.DB.FamilySymbol,Autodesk.Revit.DB.Level,Autodesk.Revit.DB.Structure.StructuralType)
source: html/a166bf08-1e02-7e57-cfe7-3885dd373036.htm
---
# Autodesk.Revit.Creation.FamilyInstanceCreationData.#ctor Method

Initializes a new instance of the FamilyInstanceCreationData class

## Syntax (C#)
```csharp
public FamilyInstanceCreationData(
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

