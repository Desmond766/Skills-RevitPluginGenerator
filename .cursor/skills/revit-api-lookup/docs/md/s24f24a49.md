---
kind: method
id: M:Autodesk.Revit.Creation.ItemFactoryBase.NewFamilyInstance(Autodesk.Revit.DB.XYZ,Autodesk.Revit.DB.FamilySymbol,Autodesk.Revit.DB.Element,Autodesk.Revit.DB.Structure.StructuralType)
source: html/61601fe7-6d7e-e600-192d-207aa31c381c.htm
---
# Autodesk.Revit.Creation.ItemFactoryBase.NewFamilyInstance Method

Inserts a new instance of a family into the document,
using a location, type/symbol, and the host element.

## Syntax (C#)
```csharp
public FamilyInstance NewFamilyInstance(
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

## Returns
If creation was successful then an instance to the new object is returned, otherwise Nothing nullptr a null reference ( Nothing in Visual Basic) .

## Remarks
This method is used to insert one family instance into another element, such as inserting a
window into a wall. If the instance fails to be created an exception may be thrown. 
 The type/symbol that is used must be loaded into the document
before this method is called. Families and their symbols can be loaded using the Document.LoadFamily
or Document.LoadFamilySymbol methods. The host object must be one that supports insertion of
instances otherwise this method will fail. Some Families, such as Beams, have more than one endpoint
and are inserted in the same manner as single point instances. Once inserted these linear family
instances can have their endpoints changed by using the instance's Element.Location property. Note: ForbiddenForDynamicUpdateException might be thrown during a dynamic update if the inserted instance establishes a mutual dependency with another structure. Note: if the created family instance includes nested instances, the API framework will automatically regenerate 
the document during this method call.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown if The symbol is not active.

