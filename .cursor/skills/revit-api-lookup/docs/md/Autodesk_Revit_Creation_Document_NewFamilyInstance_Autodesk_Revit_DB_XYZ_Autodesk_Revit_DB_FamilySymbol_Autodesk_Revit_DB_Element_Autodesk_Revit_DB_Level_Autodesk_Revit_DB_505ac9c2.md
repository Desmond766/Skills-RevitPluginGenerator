---
kind: method
id: M:Autodesk.Revit.Creation.Document.NewFamilyInstance(Autodesk.Revit.DB.XYZ,Autodesk.Revit.DB.FamilySymbol,Autodesk.Revit.DB.Element,Autodesk.Revit.DB.Level,Autodesk.Revit.DB.Structure.StructuralType)
zh: 文档、文件
source: html/168d4c67-73dd-d7c8-4969-12846eeaddfa.htm
---
# Autodesk.Revit.Creation.Document.NewFamilyInstance Method

**中文**: 文档、文件

Inserts a new instance of a family into the document,
using a location, type/symbol, the host element and a base level.

## Syntax (C#)
```csharp
public FamilyInstance NewFamilyInstance(
	XYZ location,
	FamilySymbol symbol,
	Element host,
	Level level,
	StructuralType structuralType
)
```

## Parameters
- **location** (`Autodesk.Revit.DB.XYZ`) - The physical location where the instance is to be placed on the specified level.
- **symbol** (`Autodesk.Revit.DB.FamilySymbol`) - A FamilySymbol object that represents the type of the instance that is to be inserted.
- **host** (`Autodesk.Revit.DB.Element`) - A host object into which the instance will be embedded
- **level** (`Autodesk.Revit.DB.Level`) - A Level object that is used as the base level for the object.
- **structuralType** (`Autodesk.Revit.DB.Structure.StructuralType`) - If structural then specify the type of the component.

## Returns
If creation was successful then an instance to the new object is returned, otherwise Nothing nullptr a null reference ( Nothing in Visual Basic) .

## Remarks
This form of NewFamilyInstance is the most commonly used in Autodesk Revit since there are
a large number of elements that use levels, such as Walls, Columns etc. If the instance fails to
be created an exception may be thrown. 
 The type/symbol that is used must be loaded into the document
before this method is called. Families and their symbols can be loaded using the Document.LoadFamily
or Document.LoadFamilySymbol methods. All levels within the document can be found by iterating over
the entire document and searching for objects of type Autodesk.Revit.Elements.Level. Some Families, such as Beams, have more than one endpoint and are inserted in the same manner as single point
instances. Once inserted these linear family instances can have their endpoints changed by using
the instance's Element.Location property. Note: ForbiddenForDynamicUpdateException might be thrown during a dynamic update if the inserted instance establishes a mutual dependency with another structure. Note: if the created family instance includes nested instances, the API framework will automatically regenerate 
the document during this method call.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown if the family symbol does not exist in the given document.
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown if the host does not exist in the given document.
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown if the level does not exist in the given document.
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown if The symbol is not active.

