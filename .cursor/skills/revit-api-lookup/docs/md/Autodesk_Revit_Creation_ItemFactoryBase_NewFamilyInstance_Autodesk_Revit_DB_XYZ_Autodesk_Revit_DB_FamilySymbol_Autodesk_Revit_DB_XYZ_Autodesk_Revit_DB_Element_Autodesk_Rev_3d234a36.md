---
kind: method
id: M:Autodesk.Revit.Creation.ItemFactoryBase.NewFamilyInstance(Autodesk.Revit.DB.XYZ,Autodesk.Revit.DB.FamilySymbol,Autodesk.Revit.DB.XYZ,Autodesk.Revit.DB.Element,Autodesk.Revit.DB.Structure.StructuralType)
source: html/7febcfdb-dbfa-317a-1c5e-882621f3e846.htm
---
# Autodesk.Revit.Creation.ItemFactoryBase.NewFamilyInstance Method

Inserts a new instance of a family into the document,
using a location, type/symbol, the host element and a reference direction.

## Syntax (C#)
```csharp
public FamilyInstance NewFamilyInstance(
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
- **host** (`Autodesk.Revit.DB.Element`) - A host object into which the instance will be embedded
- **structuralType** (`Autodesk.Revit.DB.Structure.StructuralType`) - If structural then specify the type of the component.

## Returns
If creation was successful then an instance to the new object is returned, otherwise Nothing nullptr a null reference ( Nothing in Visual Basic) .

## Remarks
This method allows you to create FamilyInstance objects that require both a location and direction. 
If the instance fails to be created an exception may be thrown. 
 The type/symbol that is used must be loaded into the document
before this method is called. Families and their symbols can be loaded using the Document.LoadFamily
or Document.LoadFamilySymbol methods. Some Families, such as Beams, have more than one endpoint and
are inserted in the same manner as single point instances. Once inserted these linear family instances
can have their endpoints changed by using the instance's Element.Location property. Note: if the created family instance includes nested instances, the API framework will automatically regenerate 
the document during this method call.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown if The symbol is not active.

