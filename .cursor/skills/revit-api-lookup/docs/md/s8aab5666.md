---
kind: method
id: M:Autodesk.Revit.Creation.ItemFactoryBase.NewFamilyInstance(Autodesk.Revit.DB.XYZ,Autodesk.Revit.DB.FamilySymbol,Autodesk.Revit.DB.View)
source: html/7499013d-e0d1-df16-92d0-ceefe7cf5c2a.htm
---
# Autodesk.Revit.Creation.ItemFactoryBase.NewFamilyInstance Method

Add a new family instance into the Autodesk Revit document, 
using an origin and a view where the instance should be placed.

## Syntax (C#)
```csharp
public FamilyInstance NewFamilyInstance(
	XYZ origin,
	FamilySymbol symbol,
	View specView
)
```

## Parameters
- **origin** (`Autodesk.Revit.DB.XYZ`) - The origin of family instance. If created on a ViewPlan , 
the origin will be projected onto the ViewPlan .
- **symbol** (`Autodesk.Revit.DB.FamilySymbol`) - A family symbol object that represents the type of the instance that is to be inserted.
- **specView** (`Autodesk.Revit.DB.View`) - The 2D view in which to place the family instance.

## Returns
If creation was successful then an instance to the new object is returned.

## Remarks
This overload applies only to 2D family symbols (detail components, annotation symbols, titleblocks, etc.).
The type/symbol that is used must be loaded into the document before this method is called. 
Families and their symbols can be loaded using the Document.LoadFamily or Document.LoadFamilySymbol methods.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - One or more required arguments was Nothing nullptr a null reference ( Nothing in Visual Basic)
- **Autodesk.Revit.Exceptions.ArgumentException** - The input family PlacementType was not ViewBased, the input view was not 2D, 
Thrown if The symbol is not active.
or instances of the input FamilySymbol are not permitted on a view of this type.

