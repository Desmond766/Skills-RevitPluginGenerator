---
kind: method
id: M:Autodesk.Revit.Creation.ItemFactoryBase.NewFamilyInstance(Autodesk.Revit.DB.Line,Autodesk.Revit.DB.FamilySymbol,Autodesk.Revit.DB.View)
source: html/899076fd-73d2-5be0-8872-b8f389d4ba49.htm
---
# Autodesk.Revit.Creation.ItemFactoryBase.NewFamilyInstance Method

Add a line based detail family instance into the Autodesk Revit document, 
using an line and a view where the instance should be placed.

## Syntax (C#)
```csharp
public FamilyInstance NewFamilyInstance(
	Line line,
	FamilySymbol symbol,
	View specView
)
```

## Parameters
- **line** (`Autodesk.Revit.DB.Line`) - The line location of family instance. The line must in the plane of the view.
- **symbol** (`Autodesk.Revit.DB.FamilySymbol`) - A family symbol object that represents the type of the instance that is to be inserted.
- **specView** (`Autodesk.Revit.DB.View`) - A 2D view in which to display the family instance.

## Remarks
This overload applies only to 2D family line based detail symbols.
The type/symbol that is used must be loaded into the document before this method is called. 
Families and their symbols can be loaded using the Document.LoadFamily 
or Document.LoadFamilySymbol methods.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when input argument line or symbol or specView is Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when input argument line or symbol or specView is invalid,
or cannot make such type in the specView,
or the line is not in the plane of specView.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when failed to create the instance.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when attempting to place a model-based family. Only 2D detail families can be placed in views.
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown if The symbol is not active.

