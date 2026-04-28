---
kind: method
id: M:Autodesk.Revit.Creation.ItemFactoryBase.NewFamilyInstance(Autodesk.Revit.DB.Reference,Autodesk.Revit.DB.Line,Autodesk.Revit.DB.FamilySymbol)
source: html/4545a04f-b5e8-1921-5a4c-d734bc4874ca.htm
---
# Autodesk.Revit.Creation.ItemFactoryBase.NewFamilyInstance Method

Inserts a new instance of a family onto a face referenced by the input Reference instance,
 using a line on that face for its position, and a type/symbol.

## Syntax (C#)
```csharp
public FamilyInstance NewFamilyInstance(
	Reference reference,
	Line position,
	FamilySymbol symbol
)
```

## Parameters
- **reference** (`Autodesk.Revit.DB.Reference`) - A reference to a face.
- **position** (`Autodesk.Revit.DB.Line`) - A line on the face defining where the symbol is to be placed.
- **symbol** (`Autodesk.Revit.DB.FamilySymbol`) - A FamilySymbol object that represents the type of the instance that is to be inserted. 
Note that this symbol must represent a family whose FamilyPlacementType 
is WorkPlaneBased or CurveBased.

## Returns
An instance of the new object if creation was successful, otherwise Nothing nullptr a null reference ( Nothing in Visual Basic) .

## Remarks
Use this method to insert one family instance on a face of another element, 
using a line on the face to define the position and direction of the new symbol.
 The type/symbol that is used must be loaded into the document before this method
is called. Families and their symbols can be loaded using the Document.LoadFamily or
Document.LoadFamilySymbol methods. The host object must support insertion of instances, otherwise this method 
will fail. If the instance fails to be created an exception may be thrown. Note: if the created family instance includes nested instances, the API framework will automatically regenerate 
the document during this method call.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when a non-optional argument was null.
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when the function
cannot get a face from the reference, or, when the family 
cannot be placed as line-based on an input face reference, because its FamilyPlacementType is not WorkPlaneBased or 
CurveBased
- **Autodesk.Revit.Exceptions.ArgumentsInconsistentException** - Thrown when the family cannot be placed on 
this line as it does not coincide with the input face.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when Revit is unable to place the family
instance.
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown if The symbol is not active.

