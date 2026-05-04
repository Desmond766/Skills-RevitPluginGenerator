---
kind: method
id: M:Autodesk.Revit.DB.Structure.StructuralConnectionHandlerType.RemoveMainSubelementsFromCustomConnection(Autodesk.Revit.DB.Structure.StructuralConnectionHandler,System.Collections.Generic.IList{Autodesk.Revit.DB.Subelement})
source: html/09882898-b699-9b91-742b-ea6bd75942a1.htm
---
# Autodesk.Revit.DB.Structure.StructuralConnectionHandlerType.RemoveMainSubelementsFromCustomConnection Method

Removes one or more subelements from a StructuralConnectionHandlerType. The subelements will be erased.

## Syntax (C#)
```csharp
public static void RemoveMainSubelementsFromCustomConnection(
	StructuralConnectionHandler structuralConnectionHandler,
	IList<Subelement> subelements
)
```

## Parameters
- **structuralConnectionHandler** (`Autodesk.Revit.DB.Structure.StructuralConnectionHandler`) - The existing StructuralConnectionHandler having custom StructuralConnectionHandlerType which is about to be modified.
- **subelements** (`System.Collections.Generic.IList < Subelement >`) - The main Subelements of input StructuralConnectionHandler which are to be used to modify custom StructuralConnectionHandlerType.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Input StructuralConnectionHandler must have custom type.
 -or-
 All the input Subelements must belong to input StructuralConnectionHandler.
 After modification of StructuralConnectionHandlerType there must remain at least one subelement of structural connections category in StructuralConnectionHandler.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

