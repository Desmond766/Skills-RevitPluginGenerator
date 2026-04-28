---
kind: method
id: M:Autodesk.Revit.DB.Structure.PathReinforcement.ConvertRebarInSystemToRebars(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.Structure.PathReinforcement)
source: html/860c0773-13e2-00be-eeb8-25afa57fe2be.htm
---
# Autodesk.Revit.DB.Structure.PathReinforcement.ConvertRebarInSystemToRebars Method

Converts all RebarInSystem elements owned by the input PathReinforcement to equivalent Rebar elements.

## Syntax (C#)
```csharp
public static IList<ElementId> ConvertRebarInSystemToRebars(
	Document doc,
	PathReinforcement system
)
```

## Parameters
- **doc** (`Autodesk.Revit.DB.Document`) - The document.
- **system** (`Autodesk.Revit.DB.Structure.PathReinforcement`) - A PathReinforcement element in the document.

## Returns
The ids of the newly created Rebar elements.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The element system was not found in the given document.
 -or-
 system does not host Rebar.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

