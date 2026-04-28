---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarFreeFormAccessor.RemoveUpdatingSharedParameter(Autodesk.Revit.DB.ElementId)
source: html/17cac627-4846-e71d-b181-6ea6ef7d5257.htm
---
# Autodesk.Revit.DB.Structure.RebarFreeFormAccessor.RemoveUpdatingSharedParameter Method

Remove existing shared parameter as a dependency for the calculation of the rebar curves.

## Syntax (C#)
```csharp
public void RemoveUpdatingSharedParameter(
	ElementId parameterId
)
```

## Parameters
- **parameterId** (`Autodesk.Revit.DB.ElementId`) - ElementId of the shared parameter to be removed.

## Remarks
The input parameter needs to be bound to the Rebar element The rebar element needs to have a valid external server

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This RebarFreeFormAccessor Rebar doesn't contain a valid server GUID.
 -or-
 parameterId is a parameter that is not bound to the Rebar element category.

