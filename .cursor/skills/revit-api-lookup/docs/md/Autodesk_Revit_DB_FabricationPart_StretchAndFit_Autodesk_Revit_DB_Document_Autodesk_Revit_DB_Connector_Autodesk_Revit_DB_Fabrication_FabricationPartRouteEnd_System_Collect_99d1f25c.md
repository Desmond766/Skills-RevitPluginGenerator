---
kind: method
id: M:Autodesk.Revit.DB.FabricationPart.StretchAndFit(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.Connector,Autodesk.Revit.DB.Fabrication.FabricationPartRouteEnd,System.Collections.Generic.ISet{Autodesk.Revit.DB.ElementId}@)
source: html/2f5031a2-f07c-761d-2f88-c16674b070a7.htm
---
# Autodesk.Revit.DB.FabricationPart.StretchAndFit Method

Stretch the fabrication part from the specified connector and fit to the target routing end.

## Syntax (C#)
```csharp
public static FabricationPartFitResult StretchAndFit(
	Document document,
	Connector stretchConnector,
	FabricationPartRouteEnd target,
	out ISet<ElementId> newPartIds
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document in which to perform the stretch and fit.
- **stretchConnector** (`Autodesk.Revit.DB.Connector`) - The connector of the fabrication part to be stretched.
- **target** (`Autodesk.Revit.DB.Fabrication.FabricationPartRouteEnd`) - The target routing end to align and fit to.
- **newPartIds** (`System.Collections.Generic.ISet < ElementId > %`) - New fabrication part element identifiers.

## Returns
Returns FabricationPartFitResult::Success if successful.

## Remarks
Cannot stretch and fit fabrication part straight, tap or hanger.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Connector does not belong to a fabrication part with a valid fabrication service.
 -or-
 Connector is connected.
 -or-
 Connector belongs to a fabrication part straight, tap, or hanger.
 -or-
 Routing end is valid to route to.
 -or-
 stretch target end type must be a supported type.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - fabrication part is not connected at one end only.
 -or-
 cannot stretch fabrication part to a different service.

