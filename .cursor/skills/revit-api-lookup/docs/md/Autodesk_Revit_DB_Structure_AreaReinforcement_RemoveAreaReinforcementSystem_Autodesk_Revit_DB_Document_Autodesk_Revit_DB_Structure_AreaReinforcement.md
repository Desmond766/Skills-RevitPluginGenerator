---
kind: method
id: M:Autodesk.Revit.DB.Structure.AreaReinforcement.RemoveAreaReinforcementSystem(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.Structure.AreaReinforcement)
source: html/497ef418-b0cc-e0a2-34d1-67ef49274801.htm
---
# Autodesk.Revit.DB.Structure.AreaReinforcement.RemoveAreaReinforcementSystem Method

Deletes the specified AreaReinforcement, and converts its RebarInSystem
 elements to equivalent Rebar elements.

## Syntax (C#)
```csharp
public static IList<ElementId> RemoveAreaReinforcementSystem(
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

