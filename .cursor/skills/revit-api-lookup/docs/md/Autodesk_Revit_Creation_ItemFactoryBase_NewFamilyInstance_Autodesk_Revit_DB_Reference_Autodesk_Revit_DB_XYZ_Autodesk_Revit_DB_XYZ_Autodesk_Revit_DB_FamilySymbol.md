---
kind: method
id: M:Autodesk.Revit.Creation.ItemFactoryBase.NewFamilyInstance(Autodesk.Revit.DB.Reference,Autodesk.Revit.DB.XYZ,Autodesk.Revit.DB.XYZ,Autodesk.Revit.DB.FamilySymbol)
source: html/be4b822c-829a-7e7b-8c03-a3a324bfb75b.htm
---
# Autodesk.Revit.Creation.ItemFactoryBase.NewFamilyInstance Method

Inserts a new instance of a family onto a face referenced by the input Reference instance,
 using a location, reference direction, and a type/symbol.

## Syntax (C#)
```csharp
public FamilyInstance NewFamilyInstance(
	Reference reference,
	XYZ location,
	XYZ referenceDirection,
	FamilySymbol symbol
)
```

## Parameters
- **reference** (`Autodesk.Revit.DB.Reference`) - A reference to a face.
- **location** (`Autodesk.Revit.DB.XYZ`) - Point on the face where the instance is to be placed.
- **referenceDirection** (`Autodesk.Revit.DB.XYZ`) - A vector that defines the direction of the family instance.
Note that this direction defines the rotation of the instance on the face, and thus cannot be parallel
to the face normal.
- **symbol** (`Autodesk.Revit.DB.FamilySymbol`) - A FamilySymbol object that represents the type of the instance that is to be inserted.
Note that this symbol must represent a family whose FamilyPlacementType 
is WorkPlaneBased.

## Returns
An instance of the new object if creation was successful, otherwise Nothing nullptr a null reference ( Nothing in Visual Basic) .

## Remarks
Use this method to insert one family instance on a face of another element, 
using a point on the face and a vector to define the position and direction of the new symbol.
 The type/symbol that is used must be loaded into the document before this method is called.
Families and their symbols can be loaded using the Document.LoadFamily or
Document.LoadFamilySymbol methods. The host object must support insertion of instances, otherwise this method 
will fail. If the instances fails to be created an exception may be thrown. Some Families, such as Beams, have more than one endpoint and are inserted 
in the same manner as single point instances. Once inserted, these linear family instances
can have their endpoints changed by using the instance's Element.Location property. Note: if the created family instance includes nested instances, the API framework will automatically regenerate 
the document during this method call.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when a non-optional argument was null.
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when the function cannot get the face from
the reference, or, when the Family cannot be placed as line-based on an input face reference, because its FamilyPlacementType 
is not WorkPlaneBased
- **Autodesk.Revit.Exceptions.ArgumentsInconsistentException** - Thrown when reference direction is 
parallel to face normal at insertion point.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when Revit is unable to place the family
instance.
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown if The symbol is not active.

