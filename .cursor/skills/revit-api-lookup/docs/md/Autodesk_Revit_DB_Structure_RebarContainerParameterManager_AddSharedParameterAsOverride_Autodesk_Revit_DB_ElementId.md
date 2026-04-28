---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarContainerParameterManager.AddSharedParameterAsOverride(Autodesk.Revit.DB.ElementId)
source: html/0e4551e0-d6c6-3c71-812b-8ea6a82a9ea9.htm
---
# Autodesk.Revit.DB.Structure.RebarContainerParameterManager.AddSharedParameterAsOverride Method

Adds a shared parameter as one of the parameter overrides stored by this Rebar Container element.

## Syntax (C#)
```csharp
public void AddSharedParameterAsOverride(
	ElementId paramId
)
```

## Parameters
- **paramId** (`Autodesk.Revit.DB.ElementId`) - The id of the shared parameter element

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - paramId is not a valid Element identifier.
 -or-
 paramId is not the id of a shared parameter in the current document,
 or its name was already used by another shared parameter of the element.
 -or-
 paramId is already a Rebar Container parameter
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

