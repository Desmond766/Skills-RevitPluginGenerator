---
kind: method
id: M:Autodesk.Revit.DB.Structure.PathReinforcement.RemovePathReinforcementSystem(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.Structure.PathReinforcement)
source: html/f363e5b7-056b-4fa2-7b0f-388614effd85.htm
---
# Autodesk.Revit.DB.Structure.PathReinforcement.RemovePathReinforcementSystem Method

Deletes the specified PathReinforcement, and converts its RebarInSystem
 elements to equivalent Rebar elements.

## Syntax (C#)
```csharp
public static IList<ElementId> RemovePathReinforcementSystem(
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

