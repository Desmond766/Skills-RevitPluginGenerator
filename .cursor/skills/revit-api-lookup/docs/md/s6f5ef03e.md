---
kind: method
id: M:Autodesk.Revit.DB.Structure.Rebar.CreateFromRebarShape(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.Structure.RebarShape,Autodesk.Revit.DB.Structure.RebarBarType,Autodesk.Revit.DB.Element,Autodesk.Revit.DB.XYZ,Autodesk.Revit.DB.XYZ,Autodesk.Revit.DB.XYZ)
zh: 钢筋、配筋
source: html/5e58e3f3-dea6-79cb-9de4-475e6fe5c28b.htm
---
# Autodesk.Revit.DB.Structure.Rebar.CreateFromRebarShape Method

**中文**: 钢筋、配筋

Creates a new shape driven Rebar, as an instance of a RebarShape.
 The instance will have the default shape parameters from the RebarShape,
 and its location is based on the bounding box of the shape in the shape definition.
 Hooks are removed from the shape before computing its bounding box.
 If appropriate hooks can be found in the document, they will be assigned arbitrarily.

## Syntax (C#)
```csharp
public static Rebar CreateFromRebarShape(
	Document doc,
	RebarShape rebarShape,
	RebarBarType barType,
	Element host,
	XYZ origin,
	XYZ xVec,
	XYZ yVec
)
```

## Parameters
- **doc** (`Autodesk.Revit.DB.Document`) - A document.
- **rebarShape** (`Autodesk.Revit.DB.Structure.RebarShape`) - A RebarShape element that defines the shape of the rebar.
- **barType** (`Autodesk.Revit.DB.Structure.RebarBarType`) - A RebarBarType element that defines bar diameter, bend radius and material of the rebar.
- **host** (`Autodesk.Revit.DB.Element`) - The element to which the rebar belongs. The element must support rebar hosting;
 [!:Autodesk::Revit::DB::Structure::RebarHostData] .
- **origin** (`Autodesk.Revit.DB.XYZ`) - The lower-left corner of the shape's bounding box will be placed at this point in the project.
- **xVec** (`Autodesk.Revit.DB.XYZ`) - The x-axis in the shape definition will be mapped to this direction in the project.
- **yVec** (`Autodesk.Revit.DB.XYZ`) - The y-axis in the shape definition will be mapped to this direction in the project.

## Returns
The newly created Rebar instance, or Nothing nullptr a null reference ( Nothing in Visual Basic) if the operation fails.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The element host was not found in the given document.
 -or-
 host is not a valid rebar host.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - xVec has zero length.
 -or-
 yVec has zero length.

