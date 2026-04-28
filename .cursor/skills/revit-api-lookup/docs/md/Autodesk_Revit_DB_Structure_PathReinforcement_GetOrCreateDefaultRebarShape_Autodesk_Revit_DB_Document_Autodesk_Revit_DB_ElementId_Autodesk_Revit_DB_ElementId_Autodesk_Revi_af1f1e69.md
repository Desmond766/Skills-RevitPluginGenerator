---
kind: method
id: M:Autodesk.Revit.DB.Structure.PathReinforcement.GetOrCreateDefaultRebarShape(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.ElementId)
source: html/4db777aa-4687-e1c1-3104-0fa1c8d9e576.htm
---
# Autodesk.Revit.DB.Structure.PathReinforcement.GetOrCreateDefaultRebarShape Method

Creates a new RebarShape object with a default name or
 returns existing one which fulfills Path Reinforcement bending data requirements.

## Syntax (C#)
```csharp
public static ElementId GetOrCreateDefaultRebarShape(
	Document document,
	ElementId rebarBarTypeId,
	ElementId startRebarHookTypeId,
	ElementId endRebarHookTypeId
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document.
- **rebarBarTypeId** (`Autodesk.Revit.DB.ElementId`) - The id of the RebarBarType.
- **startRebarHookTypeId** (`Autodesk.Revit.DB.ElementId`) - The id of the RebarHookType for the start of the bar.
 If this parameter is InvalidElementId, it means to create a rebar with no start hook.
- **endRebarHookTypeId** (`Autodesk.Revit.DB.ElementId`) - The id of the RebarHookType for the end of the bar.
 If this parameter is InvalidElementId, it means to create a rebar with no end hook.

## Returns
Rebar Shape id.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - rebarBarTypeId should refer to an RebarBarType element.
 -or-
 startRebarHookTypeId should be invalid or refer to an RebarHookType element.
 -or-
 endRebarHookTypeId should be invalid or refer to an RebarHookType element.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

