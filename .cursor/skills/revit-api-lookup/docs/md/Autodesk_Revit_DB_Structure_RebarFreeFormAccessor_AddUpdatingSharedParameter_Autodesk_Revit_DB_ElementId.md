---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarFreeFormAccessor.AddUpdatingSharedParameter(Autodesk.Revit.DB.ElementId)
source: html/6401f06c-476d-bacd-6173-9c7948d286ce.htm
---
# Autodesk.Revit.DB.Structure.RebarFreeFormAccessor.AddUpdatingSharedParameter Method

Add existing shared parameter as a dependency for the calculation of the rebar curves.

## Syntax (C#)
```csharp
public void AddUpdatingSharedParameter(
	ElementId parameterId
)
```

## Parameters
- **parameterId** (`Autodesk.Revit.DB.ElementId`) - ElementId of the shared parameter to be added.

## Remarks
The input parameter needs to be bound to the Rebar element The rebar element needs to have a valid external server

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This RebarFreeFormAccessor Rebar doesn't contain a valid server GUID.
 -or-
 parameterId is a parameter that is not bound to the Rebar element category.

