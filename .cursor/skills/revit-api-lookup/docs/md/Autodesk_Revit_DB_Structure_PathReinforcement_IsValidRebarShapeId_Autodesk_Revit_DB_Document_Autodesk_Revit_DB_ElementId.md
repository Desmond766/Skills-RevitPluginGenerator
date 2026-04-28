---
kind: method
id: M:Autodesk.Revit.DB.Structure.PathReinforcement.IsValidRebarShapeId(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId)
source: html/0d570de9-c041-3bf2-dff7-47720ee6ace7.htm
---
# Autodesk.Revit.DB.Structure.PathReinforcement.IsValidRebarShapeId Method

Identifies whether an element id corresponds to a Rebar Shape element which can be used in Path Reinforcement.

## Syntax (C#)
```csharp
public static bool IsValidRebarShapeId(
	Document aDoc,
	ElementId elementId
)
```

## Parameters
- **aDoc** (`Autodesk.Revit.DB.Document`) - The document.
- **elementId** (`Autodesk.Revit.DB.ElementId`) - An element id.

## Returns
True if the specified element id corresponds to a Rebar Shape element.

## Remarks
The Rebar Shape has to be two dimensional shape only
 and its neighbouring segments may form only right angles.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

