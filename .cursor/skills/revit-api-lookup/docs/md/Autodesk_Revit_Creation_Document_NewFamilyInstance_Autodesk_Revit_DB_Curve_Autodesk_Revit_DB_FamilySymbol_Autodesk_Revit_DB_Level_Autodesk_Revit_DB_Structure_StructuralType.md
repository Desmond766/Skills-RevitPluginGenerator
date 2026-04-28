---
kind: method
id: M:Autodesk.Revit.Creation.Document.NewFamilyInstance(Autodesk.Revit.DB.Curve,Autodesk.Revit.DB.FamilySymbol,Autodesk.Revit.DB.Level,Autodesk.Revit.DB.Structure.StructuralType)
zh: 文档、文件
source: html/d8e0a91a-b062-3a86-6d8e-779534459ff4.htm
---
# Autodesk.Revit.Creation.Document.NewFamilyInstance Method

**中文**: 文档、文件

Inserts a new instance of a family into the document, 
using a curve, type/symbol and reference level.

## Syntax (C#)
```csharp
public FamilyInstance NewFamilyInstance(
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

## Returns
If creation was successful then an instance to the new object is returned, otherwise Nothing nullptr a null reference ( Nothing in Visual Basic) .

## Remarks
This method is used to insert one family instance into another element along the geometry of a curve. 
If the instance fails to be created an
exception may be thrown. 
 The type/symbol that is used must be loaded into the document before this
method is called. Families and their symbols can be loaded using the Document.LoadFamily or
Document.LoadFamilySymbol methods. The host object must be one that supports insertion of
instances otherwise this method will fail. All levels within the document can be found by iterating
over the entire document and searching for objects of type Autodesk.Revit.Elements.Level. Note: if the created family instance includes nested instances, the API framework will automatically regenerate 
the document during this method call.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown if the family symbol does not exist in the given document.
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown if the level does not exist in the given document.
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown if The symbol is not active.

