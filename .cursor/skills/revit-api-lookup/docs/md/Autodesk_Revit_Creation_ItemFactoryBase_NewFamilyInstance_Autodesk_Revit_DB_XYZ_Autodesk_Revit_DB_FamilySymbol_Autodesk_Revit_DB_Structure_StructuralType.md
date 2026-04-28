---
kind: method
id: M:Autodesk.Revit.Creation.ItemFactoryBase.NewFamilyInstance(Autodesk.Revit.DB.XYZ,Autodesk.Revit.DB.FamilySymbol,Autodesk.Revit.DB.Structure.StructuralType)
source: html/4a037d33-8251-2a50-5470-c98320e2faff.htm
---
# Autodesk.Revit.Creation.ItemFactoryBase.NewFamilyInstance Method

Inserts a new instance of a family into the document, using a location and a
type/symbol.

## Syntax (C#)
```csharp
public FamilyInstance NewFamilyInstance(
	XYZ location,
	FamilySymbol symbol,
	StructuralType structuralType
)
```

## Parameters
- **location** (`Autodesk.Revit.DB.XYZ`) - The physical location where the instance is to be placed.
- **symbol** (`Autodesk.Revit.DB.FamilySymbol`) - A FamilySymbol object that represents the type of the instance that is to be inserted.
- **structuralType** (`Autodesk.Revit.DB.Structure.StructuralType`) - If structural then specify the type of the component.

## Returns
A valid instance of the given family if the creation is successful. An exception will be thrown otherwise.

## Remarks
Use this method to insert a family instance that does not require a host element or level.
For creating instances of level-based families use one of the NewFamilyInstance methods of the Revit.Creation.Document class.
 The type/symbol that is used must be loaded into the document before this method is called.
Families and their symbols can be loaded using the Document.LoadFamily or
Document.LoadFamilySymbol methods. Some Families, such as Beams, have more than one endpoint
and are inserted in the same manner as single point instances. Once inserted these linear family
instances can have their endpoints changed by using the instance's Element.Location property. Note: if the created family instance includes nested instances, the API framework will automatically regenerate 
the document during this method call.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown if the symbol is not active.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown if the family is level-based, for new instances of such families require a valid level to be supplied at the time of creation.

