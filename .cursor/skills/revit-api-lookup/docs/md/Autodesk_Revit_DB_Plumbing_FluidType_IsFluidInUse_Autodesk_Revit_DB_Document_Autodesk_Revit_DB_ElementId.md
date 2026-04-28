---
kind: method
id: M:Autodesk.Revit.DB.Plumbing.FluidType.IsFluidInUse(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId)
source: html/8cbe2182-6144-a90a-26c6-41526bff00f4.htm
---
# Autodesk.Revit.DB.Plumbing.FluidType.IsFluidInUse Method

Identifies if the fluid type is in use.

## Syntax (C#)
```csharp
public static bool IsFluidInUse(
	Document document,
	ElementId fluidId
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document.
- **fluidId** (`Autodesk.Revit.DB.ElementId`) - The id of the fluid type.

## Returns
True if the fluid type is in use.
 False if the fluid type is not in use.

## Remarks
If a fluid type is in use, it cannot be deleted.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

