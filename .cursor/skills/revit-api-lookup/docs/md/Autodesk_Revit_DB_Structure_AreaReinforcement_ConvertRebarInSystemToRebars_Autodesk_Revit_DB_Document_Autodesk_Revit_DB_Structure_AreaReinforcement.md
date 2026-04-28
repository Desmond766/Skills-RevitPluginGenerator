---
kind: method
id: M:Autodesk.Revit.DB.Structure.AreaReinforcement.ConvertRebarInSystemToRebars(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.Structure.AreaReinforcement)
source: html/0b655f89-d5c2-eef1-8900-67601a478b1a.htm
---
# Autodesk.Revit.DB.Structure.AreaReinforcement.ConvertRebarInSystemToRebars Method

Converts all RebarInSystem elements owned by the input AreaReinforcement to equivalent Rebar elements.

## Syntax (C#)
```csharp
public static IList<ElementId> ConvertRebarInSystemToRebars(
	Document doc,
	AreaReinforcement system
)
```

## Parameters
- **doc** (`Autodesk.Revit.DB.Document`) - The document.
- **system** (`Autodesk.Revit.DB.Structure.AreaReinforcement`) - An AreaReinforcement element in the document.

## Returns
The ids of the newly created Rebar elements.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The element system was not found in the given document.
 -or-
 system does not host Rebar.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

