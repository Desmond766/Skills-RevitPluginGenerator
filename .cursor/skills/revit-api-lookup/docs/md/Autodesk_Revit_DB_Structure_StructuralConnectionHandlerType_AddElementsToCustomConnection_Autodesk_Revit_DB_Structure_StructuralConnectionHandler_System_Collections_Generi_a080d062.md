---
kind: method
id: M:Autodesk.Revit.DB.Structure.StructuralConnectionHandlerType.AddElementsToCustomConnection(Autodesk.Revit.DB.Structure.StructuralConnectionHandler,System.Collections.Generic.IList{Autodesk.Revit.DB.Reference})
source: html/4ce5c475-c74a-c5aa-0724-8df7c1a0cacb.htm
---
# Autodesk.Revit.DB.Structure.StructuralConnectionHandlerType.AddElementsToCustomConnection Method

Modifies StructuralConnectionHandlerType of input StructuralConnectionHandler by adding representors of input elements or subelements.

## Syntax (C#)
```csharp
public static void AddElementsToCustomConnection(
	StructuralConnectionHandler structuralConnectionHandler,
	IList<Reference> references
)
```

## Parameters
- **structuralConnectionHandler** (`Autodesk.Revit.DB.Structure.StructuralConnectionHandler`) - The existing StructuralConnectionHandler having custom StructuralConnectionHandlerType which is about to be modified.
- **references** (`System.Collections.Generic.IList < Reference >`) - References to elements or subelements which are to be used to modify custom StructuralConnectionHandlerType by adding their representors.

## Remarks
Elements or subelements added to a custom connection are deleted and transformed in subelements of the connection. They could be:
 FamilyInstance (structural beams and columns). StructuralConnectionHandler elements associated to the connection. Specific steel connection elements (bolts, anchors, plates, etc). These connection elements will be of type element but with categories related to structural connections, for example:
 OST_StructConnectionWelds OST_StructConnectionHoles OST_StructConnectionModifiers OST_StructConnectionShearStuds OST_StructConnectionBolts OST_StructConnectionAnchors OST_StructConnectionPlates 
 You cannot add: elements connected by any connection handler, generic connections, holes and modifiers that are not on the connected elements.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Input StructuralConnectionHandler must have custom type.
 -or-
 All the input Elements should be of the following structural categories: framings, columns, profiles, plates, bolts, anchors, shear studs, welds or structural connections.
 -or-
 Total number of different input elements of input StructuralConnectionHandlers must be lower or equal to 3.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

